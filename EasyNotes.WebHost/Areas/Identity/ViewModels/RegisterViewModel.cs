﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Identity.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"(^[a-zA-Z0-9\.\-_]{3,15}$)", ErrorMessage = "Username only can contain: letter, number or specific character [. _ -]")]
        public string Username { get; set; }
        [Required]
        [StringLength(450,ErrorMessage ="The {0} must be at least {2} and at max {1} characters long.",MinimumLength = 3)]
        public string FirstName { set; get; }
        [Required]
        [StringLength(450, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string LastName { set; get; }
        [Required]
        [StringLength(16,ErrorMessage ="The {0} must be at least {2} and at max {1} characters long.",MinimumLength = 3)]
        public string Password { set; get; }
        [Compare("Password",ErrorMessage ="Confirm password doesn't match, Type again")]
        public string ConfirmPassword { set; get; }
    }
}
