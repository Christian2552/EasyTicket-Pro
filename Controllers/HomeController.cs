using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EasyTicket_Pro.Models;

namespace EasyTicket_Pro.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Just a simple action method that returns the HomePage view when the user navigates to the /Home/HomePage URL.
    // GET: /Home/HomePage
    public IActionResult Index()
    {
        return View("HomePage");
    }

    // Method that returns the EventPageConcert view when the user navigates to the /Home/EventPage URL.    
    [HttpGet("/concerts")]
    public IActionResult EventPageConcert()
    {
        return View("EventPageConcert");
    }

    // Method that returns the EventPageSport view when the user navigates to the /Home/EventPage URL.
    [HttpGet("/sports")]
    public IActionResult EventPageSport()
    {
        return View("EventPageSport");
    }

    // Method that returns the EventPageTheater view when the user navigates to the /Home/EventPage URL.
    [HttpGet("/theaters")]
    public IActionResult EventPageTheater()
    {
        return View("EventPageTheater");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
