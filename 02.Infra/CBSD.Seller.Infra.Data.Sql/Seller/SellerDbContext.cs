using Microsoft.EntityFrameworkCore;

namespace CBSD.Seller.Infra.Data.Sql.Seller
{
    public class SellerDbContext:DbContext
    {
        public DbSet<Core.Domain.Entities.Seller> Seller { get; set; }
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
