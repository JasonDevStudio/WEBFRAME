using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Library.Common;
using Library.StringItemDict;
using System.IO;

namespace MvcApp
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        protected void Application_Start()
        {
            // 计时器
            System.Timers.Timer objTimer = new System.Timers.Timer(1800000);//1800000
            objTimer.Elapsed += new System.Timers.ElapsedEventHandler(objTimer_Elapsed);
            objTimer.Start();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// 计时器 事件
        /// </summary> 
        void objTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var timeHour = DateTime.Now.Hour;
            if (timeHour == 1)
            {
                
                var dateFormat = DateTime.Now.ToString("yyyyMMdd");
                var rootPath = HttpRuntime.AppDomainAppPath + ("FileTemp/");
                var dirPath = rootPath + dateFormat + "/";

                DirectoryInfo dir = new DirectoryInfo(rootPath);
                var dirs = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);
                foreach (var item in dirs)
                {
                    if (!item.Name.Equals(dateFormat))
                    {
                        try
                        {
                            item.Delete(true);
                        }
                        catch (DirectoryNotFoundException)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is System.Web.HttpRequestValidationException)
            {
                var msgT = Server.UrlEncode("系统检测到非法字符存在,请重新输入!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
            }
            else
            {
                var msgT = Server.UrlEncode(BaseDict.ServiceErrorTitle);
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
            }
        }
    }
}