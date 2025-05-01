using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginSuccess(RegisteredUser model)
        {
            if(model.Username == "raihan" &&  model.Password == "Raihan123")
            {
                return RedirectToAction("Index", "Home");
            }
            else if(model.Username == "alamin" && model.Password == "Alamin321")
            {
                return RedirectToAction("Index", "Managers");
            }
            else if(model.Username == "Priyontoni" && model.Password == "Priyontoni95")
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(RegisteredUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.RegisteredUsers
                .FirstOrDefaultAsync(u => u.Username == model.Username);

                if (user == null)
                {
                    return NotFound();
                }
                if (user != null && user.Password == model.Password && user.Username == model.Username)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisteredUser model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
