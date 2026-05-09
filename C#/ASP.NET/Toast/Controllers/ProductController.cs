using Microsoft.AspNetCore.Mvc;
using ToastApp.Models;

namespace ToastApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
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
            return View();
        }

        // Save new product ✅ Success Toast
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["Success"] = "Product added successfully!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Something went wrong!";
            return View(product);
        }

        // Delete product ⚠️ Warning Toast
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["Warning"] = "Product deleted!";
            }
            return RedirectToAction("Index");
        }
    }
}