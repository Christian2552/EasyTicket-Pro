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

    // Контролиране на концертните събития от базата
    public IActionResult Concerts()
    {
        var concertEvents = _context.Events
                                    .Where(e => e.Category == "Concerts")
                                    .ToList();
        return View(concertEvents);
    }

    // Контролиране на спортните събития от базата
    public IActionResult Sports()
    {
        var sportsEvents = _context.Events
                                   .Where(e => e.Category == "Sports")
                                   .ToList();
        return View(sportsEvents);
    }

    // Контролиране на театралните събития от базата
    public IActionResult Theater()
    {
        var theaterEvents = _context.Events
                                    .Where(e => e.Category == "Theater")
                                    .ToList();
        return View(theaterEvents);
    }

    // Начална страница (Home/HomePage)
    public IActionResult Index()
    {
        return View("HomePage");
    }

    // Страница за концерти с custom рутиране
    [HttpGet("/concerts")]
    public IActionResult EventPageConcert()
    {
        var concertEvents = _context.Events
                                    .Where(e => e.Category == "Concerts")
                                    .ToList();
        return View("EventPageConcert", concertEvents);
    }

    // Страница за спорт с custom рутиране
    [HttpGet("/sports")]
    public IActionResult EventPageSport()
    {
        var sportsEvents = _context.Events
                                   .Where(e => e.Category == "Sports")
                                   .ToList();
        return View("EventPageSport", sportsEvents);
    }

    // Страница за театър с custom рутиране
    [HttpGet("/theaters")]
    public IActionResult EventPageTheater()
    {
        var theaterEvents = _context.Events
                                    .Where(e => e.Category == "Theater")
                                    .ToList();
        return View("EventPageTheater", theaterEvents);
    }

    // Логика за запазване / купуване на билет
    [HttpPost]
    public IActionResult BookTicket(int eventId)
    {
        // Vzimame imeyla na veche vleznalia potrebitel ot cookie-to (identifikaciyata)
        var userEmail = User.Identity?.Name;

        if (string.IsNullOrEmpty(userEmail))
        {
            // Ako ne e vleznal, go prashtame kum nachalnoto myasto
            return RedirectToAction("Index", "Home");
        }

        var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
        var evnt = _context.Events.Find(eventId);

        if (user == null || evnt == null)
        {
            return NotFound();
        }

        // Suzdavame bilet v bazata danni
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

        // Sled uspeshno kupuvane, prenasochvame go kym profila da si vidi istoriyata
        return RedirectToAction("ProfilePage", "Account");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}