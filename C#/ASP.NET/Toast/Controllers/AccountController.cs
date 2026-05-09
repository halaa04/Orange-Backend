using Microsoft.AspNetCore.Mvc;
using ToastApp.Models;

namespace ToastApp.Controllers
{
    public class AccountController : Controller
    {
        // Show login form
        public IActionResult Login()
        {
            return View();
        }

        // Login POST ❌ Error Toast
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Fake check - only this email/password works
                if (model.Email == "admin@test.com" && model.Password == "123456")
                {
                    TempData["Success"] = "Welcome back!";
                    return RedirectToAction("Index", "Product");
                }

                TempData["Error"] = "Invalid email or password!";
                return View(model);
            }

            TempData["Error"] = "Please fill all fields!";
            return View(model);
        }
    }
}