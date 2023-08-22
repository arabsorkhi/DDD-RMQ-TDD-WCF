using System;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Command
{
    public class RegisterUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
