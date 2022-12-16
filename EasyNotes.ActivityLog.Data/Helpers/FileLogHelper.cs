using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.ActivityLog.Data.Helpers
{
    public class FileLogHelper
    {
        public static string Format(string ip, string user, string controllerName, string actionName, string logContent)
        {
            var message = new StringBuilder();
            message.Append(Environment.NewLine);
            message.Append("=============================================================");
            message.Append(Environment.NewLine);
            message.Append($"IP: {ip}");
            message.Append(Environment.NewLine);
            message.Append($"User: {user}");
            message.Append(Environment.NewLine);
            message.Append($"Action: {controllerName}.{actionName}");
            message.Append(Environment.NewLine);
            message.Append("=============================================================");
            message.Append(Environment.NewLine);
            message.Append(logContent);

            return message.ToString();
        }
    }
}
