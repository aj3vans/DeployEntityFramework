using Microsoft.AspNetCore.Mvc;

namespace DeployEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("MVC..");
        }
    }
}
