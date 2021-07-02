using System;
using System.Collections.Generic;
using System.Text;

namespace ApexChat.Helpers.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToTimeString(this DateTime date)
        {
            return date.ToString("hh:mm:ss tt");
        }
        public static DateTime ToLocalTimeZone(this DateTime date)
        {
            return date.ToLocalTime();
           
        }
        public static string ToDashedDateTimeString(this DateTime date)
        {
            string yy = date.Year.ToString();
            string mo = date.Month.ToString().PadLeft(2, '0');
            string dd = date.Day.ToString().PadLeft(2, '0');
            string hh = date.Hour.ToString().PadLeft(2, '0');
            string mm = date.Minute.ToString().PadLeft(2, '0');
            return yy + "-" + mo + "-" + dd + " " + hh + ":" + mm;

        }
        /// <summary>
        /// Convert UTC datetime to representation of string to be used for mobile app chat visitor
        /// </summary>
        /// <param name="dtUtc"></param>
        /// <returns></returns>
        public static string GetVisitorChatDateTime(this DateTime dtUtc)
        {
            return dtUtc.ToString("MMMM dd hh:mm tt");
        }
        public static string ToShortDate(this DateTime dtUtc)
        {
            return dtUtc.ToString("MM/dd/yyyy");
        }

        public static string ToDurationInString(this TimeSpan timeElapsed)
        {
            return timeElapsed.TotalSeconds > 1 ? timeElapsed.ToString("ss") + " sec" : timeElapsed.ToString("fff") + " ms";
        }
    }
}
