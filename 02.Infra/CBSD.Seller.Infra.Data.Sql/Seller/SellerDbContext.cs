using CBSD.Seller.Core.Domain.UserProfileAgg.Entities;
using Microsoft.EntityFrameworkCore;

namespace CBSD.Seller.Infra.Data.Sql.Seller
{
    public class SellerDbContext:DbContext
    {
        public DbSet<Core.Domain.SellerAgg.Entities.Seller> Seller { get; set; }
        public DbSet<Core.Domain.UserProfileAgg.Entities.UserProfile> UserProfiles { get; set; }
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
