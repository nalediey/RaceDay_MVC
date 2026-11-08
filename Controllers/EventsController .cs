using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using RaceDay_MVC.Models;

namespace RaceDay_MVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("RaceDayApi");

            // Matches GET: api/events in your API
            var response = await client.GetAsync("api/events");

            if (!response.IsSuccessStatusCode)
            {
                // If it fails (e.g. 401 Unauthorized), you can redirect to login
                return RedirectToAction("Login", "Home");
            }

            // Since your API returns the exact DB model, we can use a simple DTO
            var events = await response.Content.ReadFromJsonAsync<List<EventDto>>();
            return View(events);
        }
    }
}