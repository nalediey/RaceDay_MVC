using Microsoft.AspNetCore.Mvc;
using RaceDay_MVC.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace RaceDay_MVC.Controllers
{
    public class OrganiserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // INJECT THE HTTP CLIENT FACTORY HERE
        public OrganiserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OrganiserDashboard()
        {
            var client = _httpClientFactory.CreateClient("RaceDayApi");

            // Fetch the events from the API
            var response = await client.GetAsync("api/events");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return RedirectToAction("Login", "Home");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Failed to load events.";
                return View(new List<EventDto>());
            }

            var events = await response.Content.ReadFromJsonAsync<List<EventDto>>();
            return View(events);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient("RaceDayApi");

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(model.Name), "Name");
            content.Add(new StringContent(model.Description), "Description");
            content.Add(new StringContent(model.Date.ToString("o")), "Date");
            content.Add(new StringContent(model.Location), "Location");
            content.Add(new StringContent(model.Distance), "Distance");
            content.Add(new StringContent(model.EventType), "EventType");

            if (model.BannerImage != null)
            {
                var fileContent = new StreamContent(model.BannerImage.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(model.BannerImage.ContentType);
                content.Add(fileContent, "BannerImage", model.BannerImage.FileName);
            }

            var response = await client.PostAsync("api/events", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = await response.Content.ReadAsStringAsync();
            return View(model);
        }
    }
}