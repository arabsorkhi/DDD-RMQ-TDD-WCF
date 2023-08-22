using Microsoft.AspNetCore.Mvc;

namespace CBSD.Seller.EndPoints.API.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
