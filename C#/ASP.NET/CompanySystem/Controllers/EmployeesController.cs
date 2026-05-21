using CompanySystem.Models;
using CompanySystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem.Controllers
{
    [Authorize(Roles = "Manager")]
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly AppDbContext _context;

        public EmployeesController(UserManager<Employee> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: /Employees — List all with optional name filter
        public async Task<IActionResult> Index(string? searchName)
        {
            var employees = _context.Users
                .Include(e => e.Department)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
                employees = employees.Where(e => e.FullName.Contains(searchName));

            ViewBag.SearchName = searchName;
            return View(await employees.ToListAsync());
        }

        // GET: /Employees/Create
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: /Employees/Create
        [HttpPost]
        public async Task<IActionResult> Create(RegisterEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
                return View(model);
            }

            // Handle photo upload
            string photoPath = "default.jpg";
            if (model.Photo != null && model.Photo.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.Photo.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/photos", fileName);
                using var stream = new FileStream(savePath, FileMode.Create);
                await model.Photo.CopyToAsync(stream);
                photoPath = fileName;
            }

            var employee = new Employee
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email,
                Birthdate = model.Birthdate,
                PhoneNumber = model.PhoneNumber,
                NationalId = model.NationalId,
                Nationality = model.Nationality,
                MaritalStatus = model.MaritalStatus,
                EntryDate = model.EntryDate,
                DepartmentId = model.DepartmentId,
                PhotoPath = photoPath
            };

            var result = await _userManager.CreateAsync(employee, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(employee, "Employee");
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            return View(model);
        }

        // GET: /Employees/Details/id
        public async Task<IActionResult> Details(string id)
        {
            var employee = await _context.Users
                .Include(e => e.Department)
                .Include(e => e.Tasks)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null) return NotFound();
            return View(employee);
        }
    }
}