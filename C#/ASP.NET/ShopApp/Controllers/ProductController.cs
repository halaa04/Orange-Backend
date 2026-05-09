using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // Show all products
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Show create form
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        // Save new product
        [HttpPost]
        public IActionResult Create(Product product, IFormFile? ImageFile)
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
                product.ImagePath = "/images/" + fileName;
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}