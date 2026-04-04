using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegisterForm.Models;
using LoginRegisterForm.Data;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using LoginRegisterForm.ViewModels;

namespace LoginRegisterForm.Controllers;

public class AccountController : Controller
{
   private readonly AuthDbContext _db;

   public AccountController(AuthDbContext db)
   {
      _db = db;
   }

   // get Index -> View()
   [HttpGet]
   public IActionResult SignUp()
   {
      return View();
   }

   [HttpGet]
   public IActionResult SignIn()
   {
      return View();
   }

   [HttpGet]
   public IActionResult Index()
   {
      return View();
   }

   // post Index -> registration -> DB 

   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> SignUp(RegisterViewModel model)
   {
      if (!ModelState.IsValid)
      {
         return View(model);
      }

      if (_db.UserData.Any(u => u.Email == model.Email))
      {
         ModelState.AddModelError("Email", "Email already used");
         return View(model);
      }

      if (_db.UserData.Any(u => u.Login == model.Login))
      {
         ModelState.AddModelError("Login", "Login already used");
         return View(model);
      }

      var user = new User
      {
         Login = model.Login, Email = model.Email,
         PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
      };

      _db.UserData.Add(user);

      await _db.SaveChangesAsync();
      return RedirectToAction(nameof(SignIn));

   }

   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> SignInMethod(LoginViewModel model)
   {
      if (!ModelState.IsValid)
      {
         return View(nameof(SignIn));
      }

      var user = _db.UserData.FirstOrDefault(u => u.Login == model.Login); // null

      if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
      {
         ModelState.AddModelError(string.Empty, "Login or Password incorrect");
         return View(nameof(SignIn));
      }

      // await HttpContext.SignInAsync("CookieAuth", principal, authProps);
      return RedirectToAction(nameof(Index));
   }
}