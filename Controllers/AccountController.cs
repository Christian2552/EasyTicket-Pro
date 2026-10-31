using Microsoft.AspNetCore.Mvc;
using EasyTicket_Pro.Models;

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


            return RedirectToAction("Index", "Home");
        }
    }
}