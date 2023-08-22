using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain.Events;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class SellerSentReceipt : IEvent
    {
        public Guid id { get; set; }

    }
}
