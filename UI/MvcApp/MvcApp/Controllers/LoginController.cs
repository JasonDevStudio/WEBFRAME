using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.PowerSystemModels;
using Library.Facades.PowerSystem;
using Library.StringItemDict;
using Library.Common;
using System.Configuration;

namespace MvcApp.Controllers
{
    public class LoginController : Controller
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
        /// 登录
        /// </summary> 
        public ActionResult Index()
        {
            Session["UserInfo"] = null; 
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>  
        [HttpPost]
        public ActionResult Index(FormCollection fc, ModelSysUser model)
        {
            IFacadeSysUser fakSysUser = new FacadeSysUser();
            var userId = string.Empty;
            var userFullName = string.Empty;
            var resultMsg = string.Empty;
            string identity = fakSysUser.VerifyUser(model.Uname, model.Upassword, Guid.NewGuid().ToString(), out userId, out userFullName, out resultMsg); // Guid.NewGuid().ToString()
            if (!string.IsNullOrWhiteSpace(identity) && string.IsNullOrWhiteSpace(resultMsg))
            {
                model.Userid = userId;
                model.Fullname = userFullName;
                Session["UserInfo"] = model;
                Response.Redirect(Url.Action("Index","Home")); 
            }
            else
            { 
                resultMsg = "登录失败,请重新登录,如多次登录失败请联系管理员处理!";
                this.ShowMessage(resultMsg, isSuccess: false, width: 350);
            }

            ModelState.Clear();
            return View(model);
        }

        public ActionResult LoginOut()
        {
            Session["UserInfo"] = null;
            return View();
        }

    }
}
