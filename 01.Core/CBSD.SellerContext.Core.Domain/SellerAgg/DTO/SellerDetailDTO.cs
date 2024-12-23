using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.SellerAgg.DTO
{
    //try to use the record keyword as much as I can. I often use
    // it on Data Transfert Object (DTO) to carry data between layers because they must not
    // mutate, and I can enforce immutability easily


    public record SellerDetailDTO
    {
        
            public Guid SellerId { get; set; }
            public string Title { get; set; }
            public long Price { get; set; }
            public string Text { get; set; }
            public string SellersDisplayName { get; set; }
            public string[] PhotoUrls { get; set; }
        }
    }
 
