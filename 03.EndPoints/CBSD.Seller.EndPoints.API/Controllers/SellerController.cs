using CBSD.Core.ApplicationServices.Sellers.CommandHandlers;
using CBSD.Seller.Core.Domain.SellerAgg.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CBSD.Seller.EndPoints.API.Controllers
{
    //grasp:cotroller Pattern
    //Facade pattern
    //
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {


        [HttpPost]
        public IActionResult Post([FromServices] CreateHandler handler, CreateCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("title")]
        [HttpPut]
        public IActionResult Put([FromServices] SetPriceHandler handler, SetPriceCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public IActionResult Put([FromServices] SetProductHandler handler, SetProductCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("price")]
        [HttpPut]
        public IActionResult Put([FromServices] SentRecieptHandler handler, SentRecieptCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

       
    }
}
     