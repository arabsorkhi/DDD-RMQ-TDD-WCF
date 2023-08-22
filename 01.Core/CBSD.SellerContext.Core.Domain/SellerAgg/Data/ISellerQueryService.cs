using CBSD.Seller.Core.Domain.SellerAgg.DTO;
using CBSD.Seller.Core.Domain.SellerAgg.Queries;

namespace CBSD.Seller.Core.Domain.SellerAgg.Data
{
    //DataService for query
    public interface ISellerQueryService
    {
        SellerDetailDTO Query(GetActiveSeller query);
        SellerSummaryDTO Query(GetActiveSellerList query);
        SellerSummaryDTO Query(GetSpecificSeller query);
    }
}
