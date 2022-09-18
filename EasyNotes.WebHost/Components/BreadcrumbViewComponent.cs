using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Components
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        public BreadcrumbViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
