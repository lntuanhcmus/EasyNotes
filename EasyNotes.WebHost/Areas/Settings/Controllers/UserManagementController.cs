using EasyNotes.Data.Models;
using EasyNotes.WebHost.Areas.Settings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public UserManagementController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> Info()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var result = new UserViewModel()
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber
                    };
                    return View(result);
                }

                return View();
            }

            catch(Exception ex)
            {
                throw;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Info(UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ErrorMessage = "There is an error when updating user";
                    return View(model);
                }
                var user = await _userManager.FindByNameAsync(model.Username);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                await _userManager.UpdateAsync(user);
                ViewBag.SaveSuccess = true;
                ViewBag.Message = "Update profile successfully";
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
