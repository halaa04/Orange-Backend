using CompanySystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Employee> _userManager;

        public TasksController(AppDbContext context, UserManager<Employee> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Manager: view all tasks
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {
            var tasks = await _context.EmployeeTasks
                .Include(t => t.Employee)
                .ToListAsync();
            return View(tasks);
        }

        // Manager: assign new task
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(_context.Users.ToList(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(EmployeeTask task)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Employees = new SelectList(_context.Users.ToList(), "Id", "FullName");
                return View(task);
            }

            _context.EmployeeTasks.Add(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Employee: view only their own tasks
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> MyTasks()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var tasks = await _context.EmployeeTasks
                .Where(t => t.EmployeeId == currentUser.Id)
                .ToListAsync();
            return View(tasks);
        }
    }
}