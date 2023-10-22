using CBSD.Seller.Core.Domain.DomainEvent.Queries;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using Microsoft.AspNetCore.Mvc;

namespace CBSD.Seller.EndPoints.API.Controllers
{
    public class SellerQueryController : Controller
    {
        private readonly ISellerQueryService  _sellerQueryService;

        public SellerQueryController(ISellerQueryService  sellerQueryService)
        {
            this._sellerQueryService = sellerQueryService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetActiveSeller request)
        {
            return new OkObjectResult(_sellerQueryService.Query(request));
        }
        [HttpGet]
        public IActionResult Get([FromQuery] GetActiveSellerList request)
        {
            return new OkObjectResult(_sellerQueryService.Query(request));
        }
    }
}
