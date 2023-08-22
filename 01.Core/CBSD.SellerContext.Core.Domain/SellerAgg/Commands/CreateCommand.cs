using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Commands
{
    public class CreateCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
