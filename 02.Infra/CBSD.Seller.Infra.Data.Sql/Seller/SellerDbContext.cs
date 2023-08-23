using Microsoft.EntityFrameworkCore;

namespace CBSD.Infra.Data.Sql.Seller
{
    public class SellerDbContext:DbContext
    {
        public DbSet<CBSD.Seller.Core.Domain.SellerAgg.Entities.Seller> Seller { get; set; }
        public DbSet<CBSD.Seller.Core.Domain.UserProfileAgg.Entities.UserProfile> UserProfiles { get; set; }
        public SellerDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)  
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
