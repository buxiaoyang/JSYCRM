using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Common
{
    public class Variables
    {
        public static string MENU_ON_TOP_NAV = "TOPNAV";
        public static string MENU_ON_SYS_NAV = "SYSNAV";
        public static string MENU_NOT_SHOW = "NOTSHOW";

        public static int WORKER_STATUS_IN_POOL = 1;
        public static int WORKER_STATUS_ON_HOLD = 2;
        public static int WORKER_STATUS_IS_DELIVERY = 3;
        public static int WORKER_STATUS_PASS_INTERVIEW = 4;
        public static int WORKER_STATUS_IS_ONBOARD = 5;
        public static int WORKER_STATUS_IS_RESIGNATION = 6;
        public static int WORKER_STATUS_ERROR = 100;
    }
}