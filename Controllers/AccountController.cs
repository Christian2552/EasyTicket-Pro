using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
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
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            Console.WriteLine($"REGISTRATION ATTEMPT: {user.Email}");

            if (ModelState.IsValid)
            {
                // 1. First, check if the email already exists in the database
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    Console.WriteLine("EMAIL ALREADY EXISTS!");
                    return RedirectToAction("Index", "Home");
                }

                // 2. Hash the password before saving to the database
                user.Password = _passwordHasher.HashPassword(user, user.Password);

                // Save the user to the database
                _context.Users.Add(user);
                _context.SaveChanges();
                Console.WriteLine("USER CREATED IN DATABASE!");

                // 3. Автоматично влизане в профила след успешна регистрация
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim("FullName", $"{user.FirstName} {user.LastName}")
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // ТОВА ЩЕ ИЗПИШЕ ВСИЧКИ ГРЕШКИ ОТ ВАЛИДАЦИЯТА В КОНЗОЛАТА НА ТЕРМИНАЛА:
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"VALIDATION ERROR in [{state.Key}]: {error.ErrorMessage}");
                    }
                }

                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["LoginError"] = "Molya, popolnete vsichki poleta.";
                return RedirectToAction("Index", "Home");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

                if (result == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
            }

            // If we reach this point, the login attempt failed
            TempData["LoginError"] = "Invalid email or password.";
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}