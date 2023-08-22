using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.SellerAgg.DTO
{
    public class SellerDetailDTO
    {
        
            public Guid SellerId { get; set; }
            public string Title { get; set; }
            public long Price { get; set; }
            public string Text { get; set; }
            public string SellersDisplayName { get; set; }
            public string[] PhotoUrls { get; set; }
        }
    }
 
