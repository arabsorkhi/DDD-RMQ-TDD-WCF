using CBSD.Core.ApplicationServices.UserProfile.CommandHandler;
using CBSD.Seller.Core.Domain.UserProfileAgg.Command;
using CBSD.Seller.EndPoints.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CBSD.Seller.EndPoints.API.Controllers
{
    [ApiController]
    [Route("/profile")]
    public class UserProfileController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromServices] RegisterUserHandler registerUserHandler,
            RegisterUser request)
        {
            return RequestHandler.HandleRequest(request, registerUserHandler.Handle);
        }
        [Route("name")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateUserNameHandler updateUserNameHandler,
            UpdateUserName request)
        {
            return RequestHandler.HandleRequest(request, updateUserNameHandler.Handle);
        }
        [Route("displayname")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateUserDisplayNameHandler updateUserDisplayNameHandler,
            UpdateUserDisplayName request)
        {
            return RequestHandler.HandleRequest(request, updateUserDisplayNameHandler.Handle);
        }

        [Route("email")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateUserEmailHandler updateUserEmailHandler,
            UpdateUserEmail request)
        {
            return RequestHandler.HandleRequest(request, updateUserEmailHandler.Handle);
        }
    }
}
