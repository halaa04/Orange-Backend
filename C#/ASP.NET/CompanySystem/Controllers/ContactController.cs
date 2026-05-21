using CompanySystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // Anyone can submit contact form
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactMessage model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.ContactMessages.Add(model);
            await _context.SaveChangesAsync();
            ViewBag.Success = "Your message has been sent!";
            return View();
        }

        // Only Manager can view messages
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Messages()
        {
            var messages = await _context.ContactMessages
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
            return View(messages);
        }
    }
}