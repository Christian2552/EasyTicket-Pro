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
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Потребител с този имейл вече съществува.");
                    return View(user);
                }

                user.Password = _passwordHasher.HashPassword(user, user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}