using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Identity.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
    }
}
