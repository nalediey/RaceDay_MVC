using Microsoft.AspNetCore.Mvc;

namespace RaceDay_MVC.Controllers
{
    public class OrganiserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
