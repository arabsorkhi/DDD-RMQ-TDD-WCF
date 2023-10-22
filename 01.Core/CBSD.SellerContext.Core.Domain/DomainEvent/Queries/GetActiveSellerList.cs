using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.DomainEvent.Queries
{
    public class GetActiveSellerList
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
