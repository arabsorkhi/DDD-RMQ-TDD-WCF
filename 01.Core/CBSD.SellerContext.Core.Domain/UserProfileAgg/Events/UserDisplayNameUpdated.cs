using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Events
{

    public class UserDisplayNameUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
