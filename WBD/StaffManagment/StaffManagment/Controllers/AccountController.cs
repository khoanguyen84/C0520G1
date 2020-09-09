using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StaffManagment.Models;
using StaffManagment.Models.ViewModels;

namespace StaffManagment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ExtendIdentityUser> userManager;
        private readonly SignInManager<ExtendIdentityUser> signInManager;

        public AccountController(UserManager<ExtendIdentityUser> userManager,
                                SignInManager<ExtendIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(userName: model.Email, 
                                    password: model.Password, 
                                    isPersistent: model.RememberMe, 
                                    lockoutOnFailure: false);
                if (loginResult.Succeeded)
                {
                    HttpContext.Session.SetString("email", model.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attemp");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ExtendIdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var registerResult = await userManager.CreateAsync(newUser, model.Password);
                if (registerResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in registerResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
