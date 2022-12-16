using EasyNotes.ActivityLog.Data.Constants;
using EasyNotes.Infrastructure.Extensions;
using EasyNotes.WebHost.Areas.Note.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace EasyNotes.WebHost.Areas.Controllers.Note
{
    [Area("Note")]
    public class DashboardController : BaseController
    {
        private readonly string _pageName = "DashboardManagement";
        private readonly string _functionName = "Dashboard";

        public DashboardController(IConfiguration config, IHttpContextAccessor accessor): base(accessor, config)
        {

        }
        [HttpGet]
        public IActionResult Index()
        {
            var logAt = DateTime.Now;
            var logContent = new StringBuilder().Append($"{_functionName} Listing {Environment.NewLine}");

            try
            {
                
                var listEvent = new Event[]
                {
                    new Event{Id = 1,Title = "Video for Marisa",StartDate = "2022-03-10"},
                    new Event{ Id = 2, Title = "Preparation", StartDate = "2022-03-11" },
                };
                logContent.Append($"Get calendar: {listEvent.ToJsonString()} successfully {Environment.NewLine}");
                FileLog(_pageName, _functionName, LogAction.Listing, LogLevel.Error, logContent.ToString(), logAt, out var logFileName);
                return View(listEvent);
            }
            catch (Exception ex)
            {
                FileLog(_pageName, _functionName, LogAction.Listing, LogLevel.Error, logContent.ToString(), logAt, ex, out var logFileName);
                throw;
            }

            
        }
    }
}
