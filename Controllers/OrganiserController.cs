using Microsoft.AspNetCore.Mvc;

namespace RaceDay_MVC.Controllers
{
    public class OrganiserController : Controller
    {
        public IActionResult OrganiserDashboard()
        {
            return View();
        }
    }
}
