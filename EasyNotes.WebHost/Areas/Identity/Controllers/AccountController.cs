using EasyNotes.WebHost.Areas.Identity.ViewModels;
using EasyNotes.WebHost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    ViewBag.ErrorMessage = "There is an error when creating account. Please try again";
                }
                AppUser user = await _userManager.FindByNameAsync(model.Username);
                if(user == null)
                {
                    user = new AppUser()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Username,
                    };
                    IdentityResult result = await _userManager.CreateAsync(user,model.Password);
                }    
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                throw;
            }
            return View();
        }
    }
}
