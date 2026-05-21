using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CompanySystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Identity using Employee as the user model
builder.Services.AddIdentity<Employee, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// When a non-logged-in user tries to access a protected page → send to /Account/Login
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();   // ← must come before UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Seed roles and manager account
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Employee>>();

    // Create roles if they don't exist
    if (!await roleManager.RoleExistsAsync("Manager"))
        await roleManager.CreateAsync(new IdentityRole("Manager"));

    if (!await roleManager.RoleExistsAsync("Employee"))
        await roleManager.CreateAsync(new IdentityRole("Employee"));

    // Create default manager account
    string managerEmail = "manager@company.com";
    if (await userManager.FindByEmailAsync(managerEmail) == null)
    {
        var manager = new Employee
        {
            FullName = "System Manager",
            UserName = managerEmail,
            Email = managerEmail,
            EntryDate = DateTime.Now,
            NationalId = "0000000000"
        };

        var result = await userManager.CreateAsync(manager, "Manager@123");
        if (result.Succeeded)
            await userManager.AddToRoleAsync(manager, "Manager");
    }
}

app.Run();