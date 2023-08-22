using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.SellerAgg.DTO
{
    public class SellerSummaryDTO
    {
        public Guid SellerId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}
