using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Events
{
    public class UserNameUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
 
