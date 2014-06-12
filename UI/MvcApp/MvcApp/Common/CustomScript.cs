using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.StringItemDict;
using System.Web.Routing;

namespace MvcApp.Common
{
    public class CustomScript
    {
        public static string GetCustomScriptContent(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                return string.Empty;
            }

            object tempObj = viewContext.TempData[BaseDict.CustomScript];
            string tempRawMessage = tempObj == null ? string.Empty : tempObj.ToString();

            if (!string.IsNullOrEmpty(tempRawMessage))
            {
                return tempRawMessage;
            }

            if (viewContext.HttpContext != null && viewContext.HttpContext.Session != null &&
               viewContext.HttpContext.Session[BaseDict.CustomScript] != null)
            {
                string rawMessage = viewContext.HttpContext.Session[BaseDict.CustomScript].ToString();
                viewContext.HttpContext.Session.Remove(BaseDict.CustomScript);
                return rawMessage;
            }

            return string.Empty;
        } 
    }
}