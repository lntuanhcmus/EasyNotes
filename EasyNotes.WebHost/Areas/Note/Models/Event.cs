using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Note.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
    }
}
