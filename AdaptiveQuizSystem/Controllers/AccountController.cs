using AdaptiveQuizSystem.Data;
using AdaptiveQuizSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace AdaptiveQuizSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Mật khẩu không khớp");
                    return View(model);
                }

                if (_context.Users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    return View(model);
                }

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

                var user = new User
                {
                    Username = model.Username,
                    PasswordHash = passwordHash,
                    Email = model.Email,
                    Role = "user", // ✅ Mặc định role
                    GradeLevel = model.GradeLevel,
                    CurrentLevel = model.CurrentLevel,
                    CreatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: /Account/Login
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.Role);

                    // Nếu là admin, chuyển hướng đến trang Admin trong AccountController
                    if (user.Role.ToLower() == "admin")
                    {
                        return RedirectToAction("Admin", "Account");
                    }

                    // Nếu không phải admin, chuyển về trang chủ
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Admin()
        {
            // Có thể kiểm tra quyền tại đây nếu cần
            var role = HttpContext.Session.GetString("Role");
            if (role?.ToLower() != "admin")
            {
                return RedirectToAction("Login");
            }

            return View(); // sẽ trả về Views/Account/Admin.cshtml
        }
    }
}
