using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.SellerAgg.Queries
{
    public class GetSpecificSeller
    {
        public Guid OwneruserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
