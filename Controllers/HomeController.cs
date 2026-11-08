using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RaceDay_MVC.Models;
using System.Net.Http.Json;

namespace RaceDay_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        // Inject HttpClient here
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }
        public IActionResult Results()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        //REGISTER

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient("RaceDayApi");

            // Send data to the API
            var response = await client.PostAsJsonAsync("api/auth/Register", model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Registration successful! Please log in.";
                return RedirectToAction("Login");
            }

            // If the API fails (e.g., email exists), show the error
            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", "Registration failed: " + error);
            return View(model);
        }

    
        //LOGIN
    
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient("RaceDayApi");

            // Send login data to the API
            var response = await client.PostAsJsonAsync("api/auth/Login", model);

            if (response.IsSuccessStatusCode)
            {
                // Get the token from the API
                var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

                // Save the token in a Cookie so we can use it later!
                Response.Cookies.Append("JwtToken", result.token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddHours(2)
                });

                // Save the role so we know if they are Organiser or Participant
                Response.Cookies.Append("UserRole", result.role, new CookieOptions { Secure = true });

                // --- ROLE BASED REDIRECT ---
                if (result.role == "Organiser")
                {
                    // Redirect to Organiser Dashboard
                    return RedirectToAction("OrganiserDashboard", "Organiser");
                }
                else if (result.role == "Participant")
                {
                    // Redirect to Participant Dashboard
                    return RedirectToAction("ParticipantDashboard", "Participant");
                }

                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }


        //LOGOUT

        public IActionResult Logout()
        {
            Response.Cookies.Delete("JwtToken");
            Response.Cookies.Delete("UserRole");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}