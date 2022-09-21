using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.Data.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; } 
    }
}
