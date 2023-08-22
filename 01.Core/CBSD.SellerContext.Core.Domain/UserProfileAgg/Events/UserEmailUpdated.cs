using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Events
{
    public class UserEmailUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
