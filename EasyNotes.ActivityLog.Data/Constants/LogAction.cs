using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.ActivityLog.Data.Constants
{
    public class LogAction
    {
        public const string View = "View";
        public const string Search = "Search";
        public const string List = "List";
        public const string Listing = "Listing";

        public const string Create = "Create";
        public const string Edit = "Edit";
        public const string Detail = "Get detail";
        public const string Delete = "Delete";
        public const string Deactivate = "Deactivate";
        public const string Active = "Activate";
        public const string LockAccount = "Lock Account";
        public const string UnlockAccount = "Unlock Account";
        public const string Account = "LockAccount";
        public const string Login = "Log In";
        public const string Logout = "LogOut";
        public const string Export = "Export";
        public const string Retry = "Retry";

        public const string OrderUp = "Order Up";
        public const string OrderDown = "Order Down";

        public const string CallApi = "Call API";

        public const string ChangePassword = "Change Password";
    }
}
