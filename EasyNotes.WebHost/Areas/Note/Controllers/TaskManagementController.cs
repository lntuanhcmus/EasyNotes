using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Controllers.Note
{
    public class TaskManagementController : BaseController
    {

        public TaskManagementController(IConfiguration config, IHttpContextAccessor accessor) : base(accessor, config) { }
        public IActionResult Index()
        {
            return View();
        }
    }
}
