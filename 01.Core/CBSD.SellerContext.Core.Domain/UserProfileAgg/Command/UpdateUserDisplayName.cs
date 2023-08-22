using System;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Command
{
    public class UpdateUserDisplayName
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
