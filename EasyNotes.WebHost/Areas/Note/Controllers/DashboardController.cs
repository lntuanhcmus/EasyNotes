using EasyNotes.WebHost.Areas.Note.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Controllers.Note
{
    [Area("Note")]
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var listEvent = new Event[]{
                new Event{Id = 1,Title = "Video for Marisa",StartDate = "2022-03-10"},
                new Event{ Id = 2, Title = "Preparation", StartDate = "2022-03-11" },
            };

            return View(listEvent);
        }
    }
}
