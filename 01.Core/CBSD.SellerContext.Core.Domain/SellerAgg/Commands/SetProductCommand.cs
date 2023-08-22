using CBSD.Seller.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CBSD.Seller.Core.Domain.SellerAgg.Commands
{
    public class SetProductCommand
    {
        public Guid Id { get; set; }
        public string productName { get; set; }

    }
}
