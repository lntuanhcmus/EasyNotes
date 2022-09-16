using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Models
{
    public class AppUser: IdentityUser<int>
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { set; get; }
        [Required]
        [MaxLength(255)]
        public string LastName { set; get; }
    }
}
