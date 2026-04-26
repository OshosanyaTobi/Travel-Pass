using ADODB;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TravelPass.Properties;

namespace TravelPass
{
    class _DateTime
    {
        public static String NowString
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public static String TodayString
        {
            get { return DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public static String GivenDateString(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
