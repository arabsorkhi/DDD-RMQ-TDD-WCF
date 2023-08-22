using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Events
{
    public class UserRegistered : IEvent
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
