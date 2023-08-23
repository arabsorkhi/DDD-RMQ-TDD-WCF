using CBSD.Core.ApplicationServices.Sellers.CommandHandlers;
using CBSD.Core.ApplicationServices.UserProfile.CommandHandler;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using CBSD.Seller.Core.Domain.UserProfileAgg.Data;
using CBSD.Seller.Infra.Data.Sql.Seller;
using CBSD.Seller.Infra.Data.Sql.UserProfile;
using Framework.Domain.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SellerContext",
        Description = "one of our BCs"
    });
});

//builder.Services.AddSingleton<ISellerRepository, InMemorySellerRepository>();
builder.Services.AddScoped<ISellerQueryService,  DapperSellerQueryService>();
builder.Services.AddScoped(c => new SqlConnection(builder.Configuration.GetConnectionString("SellerCnn")));
builder.Services.AddScoped<IUserProfileRepository, EFUserProfileRepository>();
builder.Services.AddScoped<ISellerRepository, EFSellerRepository>();


builder.Services.AddScoped<IUnitOfWork , SellerUnitOfWork>();
builder.Services.AddDbContext<SellerDbContext>(c => c.UseSqlServer(builder.Configuration .GetConnectionString("SellerCnn")));


builder.Services.AddScoped<CreateHandler>();
builder.Services.AddScoped<SetPriceHandler>();
builder.Services.AddScoped<SetProductHandler>();
builder.Services.AddScoped<SentRecieptHandler>();


builder.Services.AddScoped<RegisterUserHandler>();
builder.Services.AddScoped<UpdateUserNameHandler>();
builder.Services.AddScoped<UpdateUserEmailHandler>();
builder.Services.AddScoped<UpdateUserDisplayNameHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/V1/swagger.json", "Seller BC V1 18/08/2023");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
