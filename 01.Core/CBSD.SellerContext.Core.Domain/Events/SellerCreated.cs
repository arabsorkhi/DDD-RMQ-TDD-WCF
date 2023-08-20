using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.Events
{
    public class SellerCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
