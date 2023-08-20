using CBSD.Seller.Core.Domain.Entities;
using System;

namespace CBSD.Seller.Core.Domain.Commands
{
    public class SetProductCommand
    {
        public Guid Id { get; set; }
        public Product product { get; set; }
        
    }
}
