using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shows.Models;
using Shows.Api;
using System.Linq;

namespace Shows.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly GetJson _getJson;

    public HomeController(GetJson getJson, ILogger<HomeController> logger)
    {
        _getJson = getJson;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        string url = "https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/events/event-data.json";

        var data = await _getJson.GetDataAsync(url);

        ViewBag.Venues = data?.Venues;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Venue()
    {
        var formData = HttpContext.Request.Form;
        string url = "https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/events/event-data.json";
        var data = await _getJson.GetDataAsync(url);
        List<Performance>? eventsOfThisVenue = data?.Events?.Where(e => e.VenueId == int.Parse(formData["VenueId"])).ToList();
        ViewBag.Events = eventsOfThisVenue;
        ViewBag.Venue = data?.Venues?.Where(e => e.Id == int.Parse(formData["VenueId"])).ToList()[0].Name;
        return View("Venue");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

