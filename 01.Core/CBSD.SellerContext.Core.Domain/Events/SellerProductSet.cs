using Framework.Domain.Events;

namespace CBSD.Seller.Core.Domain.Events
{
    public class SellerProductSet : IEvent
    {
        public int ProductId { get; set; }

    }
}
