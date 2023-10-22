using System;

namespace CBSD.Seller.Core.Domain.DomainEvent.Queries
{
    public class GetActiveSeller
    {
        public Guid SellerId { get; set; }
    }
}
