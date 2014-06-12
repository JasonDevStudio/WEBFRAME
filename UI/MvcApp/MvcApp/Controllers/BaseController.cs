using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Common;
using System.Web.Routing;
using Library.Models.PowerSystemModels;
using Library.StringItemDict;

namespace MvcApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Created by Jason , 提示信息框
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="title">标题</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="isSuccess">成功 or 警告 类型的信息  true: 成功类型提示  false:警告类型提示</param>
        /// <param name="funName">调用的JS函数名</param>
        protected void ShowMessage(string content, string title = null, int width = 260, int height = 100, bool isSuccess = false, string funName = null)
        {
            TempData[BaseDict.CustomScript] = UtilityScript.ShowMessage(content, title, width, height, isSuccess, funName);
        }



        /// <summary>
        /// 当前登录用户
        /// </summary>
        protected ModelSysUser CurrentUser { get; set; }

        /// <summary>
        /// 页面初始化函数
        /// </summary>
        /// <param name="requestContext">上下文</param>
        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["UserInfo"] == null)
            {
                UrlHelper url = new UrlHelper(requestContext);
                var urlPath = url.Action("LoginOut", "Login");
                requestContext.HttpContext.Response.Redirect(urlPath);
            }

            CurrentUser = (ModelSysUser)requestContext.HttpContext.Session["UserInfo"];

            base.Initialize(requestContext);
        }

        /// <summary>
        /// 验证是否有权限访问该页面
        /// </summary>
        protected void HasActionPower(string msg = "您没有权限访问该页面!")
        {
            string userId = this.CurrentUser.Userid;
            string controller = Request.RequestContext.RouteData.Values["controller"].ToString();
            string action = Request.RequestContext.RouteData.Values["action"].ToString();

            var autHelper = new AuthorityHelper();
            var isPower = autHelper.HasActionPower(userId, controller, action);
            if (!isPower)
            {
                var msgT = Server.UrlEncode(msg);
                var msgD = Server.UrlEncode(string.Empty);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));

            }
        }

        protected bool HasActionPower(bool isShowMsg,string msg = "您没有权限访问该页面!", int width = 260, int height = 100)
        {
            string userId = this.CurrentUser.Userid;
            string controller = Request.RequestContext.RouteData.Values["controller"].ToString();
            string action = Request.RequestContext.RouteData.Values["action"].ToString();

            var autHelper = new AuthorityHelper();
            var isPower = autHelper.HasActionPower(userId, controller, action);
            if (!isPower)
            {
                this.ShowMessage(msg, "系统提示", width: width, height: height);
            }

            return isPower;
        }

    }
}
