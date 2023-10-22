using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class SellerProductSet : IEvent
    {
        public Guid ProductId { get; set; }

    }
}
