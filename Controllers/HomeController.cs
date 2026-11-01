using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EasyTicket_Pro.Models;
using EasyTicket_Pro.Data;

namespace EasyTicket_Pro.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(AppDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Controller for concert events from the database
    public IActionResult Concerts()
    {
        var concertEvents = _context.Events
                                    .Where(e => e.Category == "Concerts")
                                    .ToList();
        return View(concertEvents);
    }

    // Controller for sports events from the database
    public IActionResult Sports()
    {
        var sportsEvents = _context.Events
                                   .Where(e => e.Category == "Sports")
                                   .ToList();
        return View(sportsEvents);
    }

    // Controller for theater events from the database
    public IActionResult Theater()
    {
        var theaterEvents = _context.Events
                                    .Where(e => e.Category == "Theater")
                                    .ToList();
        return View(theaterEvents);
    }

    // Home page of the application
    public IActionResult Index()
    {
        return View("HomePage");
    }

    // Page for concert events with custom routing
    [HttpGet("/concerts")]
    public IActionResult EventPageConcert()
    {
        var concertEvents = _context.Events
                                    .Where(e => e.Category == "Concerts")
                                    .ToList();
        return View("EventPageConcert", concertEvents);
    }

    // Page for sports events with custom routing
    [HttpGet("/sports")]
    public IActionResult EventPageSport()
    {
        var sportsEvents = _context.Events
                                   .Where(e => e.Category == "Sports")
                                   .ToList();
        return View("EventPageSport", sportsEvents);
    }

    // Page for theater events with custom routing
    [HttpGet("/theaters")]
    public IActionResult EventPageTheater()
    {
        var theaterEvents = _context.Events
                                    .Where(e => e.Category == "Theater")
                                    .ToList();
        return View("EventPageTheater", theaterEvents);
    }

    // Logic for booking a ticket for a specific event
    [HttpPost]
    public IActionResult BookTicket(int eventId)
    {
        // Take the email of the currently logged-in user
        var userEmail = User.Identity?.Name;

        if (string.IsNullOrEmpty(userEmail))
        {
            // If the user is not logged in, redirect to the home page or login page
            return RedirectToAction("Index", "Home");
        }

        var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
        var evnt = _context.Events.Find(eventId);

        if (user == null || evnt == null)
        {
            return NotFound();
        }

        // Create a new ticket for the user and the selected event
        var ticket = new Ticket
        {
            UserId = user.Id,
            EventId = evnt.Id,
            Quantity = 1,
            TotalPrice = evnt.Price,
            PurchasedAt = DateTime.Now
        };

        _context.Tickets.Add(ticket);
        _context.SaveChanges();

        // After successful booking, redirect to the user's profile page to view their tickets
        return RedirectToAction("ProfilePage", "Account");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}