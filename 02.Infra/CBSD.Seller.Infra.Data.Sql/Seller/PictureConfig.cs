using CBSD.Seller.Core.Domain.Entities;
using CBSD.Seller.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBSD.Seller.Infra.Data.Sql.Seller
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
