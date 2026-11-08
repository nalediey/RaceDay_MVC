using Microsoft.AspNetCore.Mvc;

namespace RaceDay_MVC.Controllers
{
    public class ParticipantController : Controller
    {
        public IActionResult ParticipantDashboard()
        {
            return View();
        }

        public IActionResult BrowseEvents()
        {
            
            return View();
        }

        public IActionResult MyEnrolments()
        {
            return View();
        }

        public IActionResult MyResults()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
