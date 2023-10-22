using System;

namespace CBSD.Seller.Core.Domain.DomainEvent.Commands
{
    public class SentRecieptCommand
    {
        public Guid Id { get; set; }
        public int Name { get; set; }
    }
}
