using EasyNotes.Data.Models;
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
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public List<ToDoTask> Tasks { set; get; }
    }
}
