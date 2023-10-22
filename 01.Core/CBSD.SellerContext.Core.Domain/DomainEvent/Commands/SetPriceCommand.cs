using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.DomainEvent.Commands
{
    public class SetPriceCommand
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
    }
}
