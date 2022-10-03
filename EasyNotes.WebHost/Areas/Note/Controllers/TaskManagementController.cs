using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Controllers.Note
{
    public class TaskManagementController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
