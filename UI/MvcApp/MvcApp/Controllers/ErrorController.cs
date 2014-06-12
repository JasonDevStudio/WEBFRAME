using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.StringItemDict;
using Library.Common;

namespace MvcApp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string msgTitle = null,string msgDetail = null)
        {
            
            var messageTitle = !string.IsNullOrWhiteSpace(msgTitle) ? Server.UrlDecode(msgTitle) : BaseDict.ServiceErrorTitle;
            var messageDetail = !string.IsNullOrWhiteSpace(msgDetail) ? Server.UrlDecode(msgDetail) : string.Empty;
            ViewData["Msg"] = messageTitle;
            ViewData["MsgDetail"] = messageDetail;
            return View();
        }

        public ActionResult test()
        {
            //var userInfo = this.CurrentUser;
            var path = Server.MapPath("~/authority.xml");
            var authorityHelper = new AuthorityHelper();
            var menulist = authorityHelper.ReadAuthorityAll();
            var userId = "0505";
            var currentUrl = Request.Url.AbsolutePath;
            var list = authorityHelper.AuthorityFilterByUser(menulist, userId, currentUrl);
            return View();
        }

    }
}
