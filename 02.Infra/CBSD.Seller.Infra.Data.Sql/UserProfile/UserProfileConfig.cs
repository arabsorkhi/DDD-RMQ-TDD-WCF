using CBSD.Seller.Core.Domain.Shared.ValueObject;
using CBSD.Seller.Core.Domain.UserProfileAgg.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBSD.Seller.Infra.Data.Sql.UserProfile
{
    public class UserProfileConfig : IEntityTypeConfiguration<Core.Domain.UserProfileAgg.Entities.UserProfile>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.UserProfileAgg.Entities.UserProfile> builder)
        {
            builder.Property(c => c.FirstName).HasConversion(c => c.Value, d => FirstName.FromString(d));
            builder.Property(c => c.LastName).HasConversion(c => c.Value, d => LastName.FromString(d));
            builder.Property(c => c.DisplayName).HasConversion(c => c.Value, d => DisplayName.FromString(d));
            builder.Property(c => c.Email).HasConversion(c => c.Value, d => Email.FromString(d));

        }
    }
}
