using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViMail.Data.Entities;
using ViMail.Web.ViewModel;

namespace ViMail.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return Redirect("~/");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, true, true);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError("Incorrect", "Incorrect username or password");
                return View();

            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(new User()
                {
                    Email = viewModel.Email,
                    UserName = viewModel.Username
                }, viewModel.Password);

                if (result.Succeeded)
                {
                    // login here
                    var signInResult = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("Unsuccessful", "Cannot register new user");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}