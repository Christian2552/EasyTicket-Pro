using Microsoft.AspNetCore.Mvc;
using EasyTicket_Pro.Models;
using Microsoft.AspNetCore.Identity;

namespace EasyTicket_Pro.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (!ModelState.IsValid)
            {

                return RedirectToAction("Index", "Home");
            }

            // Hash the password before saving the user to the database
            var passwordHasher = new PasswordHasher<User>();
            // Hash the password and store it in the model
            string hashedPassword = passwordHasher.HashPassword(model, model.Password);

            return RedirectToAction("Index", "Home");
        }
    }
}