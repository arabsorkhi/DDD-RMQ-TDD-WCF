using CBSD.Seller.Core.Domain.SellerAgg.Entities;
using CBSD.Seller.Core.Domain.SellerAgg.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBSD.Infra.Data.Sql.Seller
{
    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(c => c.Location).HasConversion(c => c.Url, d => PictureUrl.FromString(d));
            builder.OwnsOne(c => c.Size);
        }
    }
}
