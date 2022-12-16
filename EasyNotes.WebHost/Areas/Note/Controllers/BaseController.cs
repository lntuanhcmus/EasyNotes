using EasyNotes.ActivityLog.Data.Constants;
using EasyNotes.ActivityLog.Data.Helpers;
using EasyNotes.ActivityLog.Srinks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Areas.Controllers.Note
{
    public class BaseController : Controller
    {
        protected readonly FileActivityLog FileActivityLog;
        protected readonly IHttpContextAccessor Accessor;
        protected readonly string Ip;
        protected readonly IConfiguration Config; 
        public BaseController(IHttpContextAccessor accessor, IConfiguration config) 
        {
            Config = config;
            Accessor = accessor;
            Ip = Accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            FileActivityLog = new FileActivityLog(config);
        }

        protected void FileLog(string page, string function, string action, string level, string logContent, DateTime logAt, out string logFileName)
        {
            FileLog(page, function, action, level, logContent, logAt, null, out logFileName);
        }
        protected void FileLog(string page, string function, string action, string level, string logContent, DateTime logAt, Exception exception, out string logFileName)
        {
            var fileName = $"{action.Replace(" ", "")}_{function.Replace(" ", "")}_{DateTime.Now:yyyyMMdd}.log";
            logFileName = $"EasyNotes.WebHost\\{page}\\{fileName}";

            FileActivityLog.SetFileName(logFileName);

            var user = (User?.Identity != null) ? User.Identity.Name : "NONE";
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            var messageLog = FileLogHelper.Format(Ip, user, controllerName, actionName, logContent);

            switch (level)
            {
                case LogLevel.Info:
                    FileActivityLog.Information(messageLog);
                    break;

                case LogLevel.Success:
                    FileActivityLog.Information(messageLog);
                    break;

                case LogLevel.Warning:
                    FileActivityLog.Warning(messageLog);
                    break;

                case LogLevel.Error:
                    if (exception == null)
                    {
                        FileActivityLog.Error(messageLog);
                    }
                    else
                    {
                        FileActivityLog.Exception(exception, messageLog);
                    }
                    break;

                default: break;
            }
        }

    }
}
