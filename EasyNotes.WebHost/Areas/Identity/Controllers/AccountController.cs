using EasyNotes.WebHost.Areas.Identity.ViewModels;
using EasyNotes.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EasyNotes.WebHost.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                AppUser user = await _userManager.FindByNameAsync(model.Username);
                if(user != null)
                {
                    ModelState.AddModelError("RegisterError", $"Username '{model.Username}' is already taken.");
                    return View(model);
                }    
                else
                {
                    user = new AppUser()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Username,
                    };

                    IdentityResult result = await _userManager.CreateAsync(user,model.Password);
                    if(result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        ViewBag.Message = "Register new account successfully.";
                        return RedirectToAction("Index", "Home",new { area = ""});
                    }
                    return View(model);
                }    
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;

                return View(model);
            }
            
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _userManager.FindByNameAsync(model.Username);
                if (user == null)
                {
                    ModelState.AddModelError("LoginError", "The Username is not exist");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,false,false);

                if(!result.Succeeded)
                {
                    ModelState.AddModelError("LoginError", "Password is invalid. Try agian");
                    return View(model);
                }
                return RedirectToAction("Index","Home",new { area = ""});
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Login Failture";
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                if(_signInManager.IsSignedIn(User))
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction(nameof(Login));
                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Action Failed. There is an error when Logout account.";
                return RedirectToAction(nameof(Login));
            }
            
            
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLogin(string provider, string returnUrl = null)
        {
            var listProvider = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var providerProcess = listProvider.Find((m) => m.Name == provider);
            if (providerProcess == null)
            {
                return NotFound("Not found" + provider);
            }

            var redirectUrl = Url.RouteUrl("ExternalLoginCallback", new { returnUrl }, Request.Scheme);
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (!String.IsNullOrEmpty(remoteError))
            {
                return RedirectToAction(nameof(Login));
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return View();
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (result.Succeeded)
            {
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);

                return RedirectToAction(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return View();
            }
            return View();

        }
    }
}
