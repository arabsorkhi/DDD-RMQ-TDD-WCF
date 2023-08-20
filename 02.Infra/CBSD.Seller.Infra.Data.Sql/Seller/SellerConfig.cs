namespace CBSD.Seller.Infra.Data.Sql.Seller
{

    public class SellerConfig : IEntityTypeConfiguration<Core.Domain.Entities.Seller>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Entities.Seller> builder)
        {
            builder.Property(c => c.Price).HasConversion(c => c.Value.Value, d => Price.FromLong(d));

            builder.Property(c => c.Address).HasConversion(c => c.FullAddress.ToString(), d => AddressVO.Create("", d));
            builder.Property(c => c.Name).HasConversion(c => c.Value, d => NameVO.Create(d));
            //builder.Property(c => c. Status).HasConversion(c => c. ToString(), d => SellerStatus.FromString(d));
        }
    }
}