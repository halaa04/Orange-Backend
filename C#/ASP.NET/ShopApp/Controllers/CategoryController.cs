using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // Show all categories
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Show create form
        public IActionResult Create()
        {
            return View();
        }

        // Save new category
        [HttpPost]
        public IActionResult Create(Category category, IFormFile? ImageFile)
        {
            if (ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);
                string fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }
                category.ImagePath = "/images/" + fileName;
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}