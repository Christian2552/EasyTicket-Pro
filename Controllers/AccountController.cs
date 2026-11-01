using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EasyTicket_Pro.Data;
using EasyTicket_Pro.Models;

namespace EasyTicket_Pro.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AccountController(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // 1. First, check if the email already exists in the database
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Потребител с този имейл вече съществува.");
                    return View(user);
                }

                // 2. Hash the password before saving to the database
                user.Password = _passwordHasher.HashPassword(user, user.Password);

                // Save the user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                // 4. Going to the home page after successful registration
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}