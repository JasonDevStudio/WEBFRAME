using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.StringItemDict;

namespace MvcApp.Helpers
{
    public static class ExtensionMethod
    {
        #region ToFilter
        private static DateTime[] FilterTime = { DateTime.MinValue,DateTime.MaxValue, DateTime.Parse("1900-01-01 00:00:00") };
        public static string ToFilter(this string str)
        {
            var dateTime = DateTime.Parse(str);
            for (int i = 0; i < FilterTime.Length; i++)
            {
                if (dateTime == FilterTime[i] )
                {
                    return ""; 
                } 
            }

            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strFormat"></param>
        /// <returns></returns>
        public static string ToFilter(this DateTime? dt, string strFormat = "")
        {
            if (dt == null || dt == DateTime.MinValue || dt == DateTime.MaxValue)
            {
                return "";
            }
            if (!string.IsNullOrWhiteSpace(strFormat))
            {
                return dt.Value.ToString(strFormat);
            }
            return dt.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToLine(this DateTime dt)
        {
            if (dt == null || dt == DateTime.MinValue || dt == DateTime.MaxValue)
            {
                return "";
            }
            return dt.ToString();
        }
        #endregion
    }
}