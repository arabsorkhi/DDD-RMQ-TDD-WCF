using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class SellerPriceSet : IEvent
    {
        public Guid Id { get; set; }
        public long Price { get; set; }

    }
}
