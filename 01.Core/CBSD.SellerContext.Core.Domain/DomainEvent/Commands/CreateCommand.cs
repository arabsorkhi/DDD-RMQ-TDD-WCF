using System;

namespace CBSD.Seller.Core.Domain.DomainEvent.Commands
{
    //domain Event : agg Command
    public class CreateCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
