using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models.Customs; 
using System.Data;
using Library.Criterias.CustomsCriterias;
using Library.Facades.Customs.Interfaces;
using Library.Facades.Customs.Classes;
using System.Text;
using Webdiyer.WebControls.Mvc;
using Library.Models.PowerSystemModels;
using Library.Facades.PowerSystem;
using MvcApp.Models.PowerSystem;
using Library.Common;
using Library.StringItemDict;
using DevExpress.XtraReports.UI;
using System.IO;

namespace MvcApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //权限验证
            this.HasActionPower();
            return View();
        }

        /// <summary>
        /// 导航 权限加载
        /// </summary>
        /// <returns></returns>
        public ActionResult Menu()
        {
            var userId = this.CurrentUser.Userid;
            var controller = Request.RequestContext.RouteData.Values["controller"].ToString();
            var action = Request.RequestContext.RouteData.Values["action"].ToString();
            var url = string.Format("/{0}/{1}", controller, action);

            var authorityHelper = new AuthorityHelper();
            var menulist = authorityHelper.ReadAuthorityAll();
            var list = authorityHelper.AuthorityFilterByUser(menulist, userId, url);

            return View(list);
        }


        public ActionResult Main()
        {
            var isPower = base.HasActionPower(true,msg:"您没有权限执行此操作!");
            if (isPower)
            {
                ViewData["test"] = "有权限操作";
                return View();
            }
            else
            {
                ViewData["test"] = "无权限操作";
                return View();
            }
            
        }
         
        public ActionResult List()
        {
             
            ModelSysUser userInfo = this.CurrentUser; // 控制器中 获取当前用户方式
            var model = this.GetData(); 
            return View();
        }

        [HttpPost]
        public ActionResult List(PagerQuery<PagerInfo, CriteriaDetaildata, IEnumerable<DetaildataListModel>> model = null)
        {
            this.ShowMessage("ceshi2222"); 
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Detail2()
        {
            return View();
        }

        public ActionResult Error(string msg)
        {
            var message = !string.IsNullOrWhiteSpace(msg) ? Server.UrlDecode(msg) : BaseDict.ServiceErrorTitle;
            ViewData["Msg"] = message;
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

        public void Report2()
        {
            var dateFormat =DateTime.Now.ToString("yyyyMMdd");
            var rootPath = Server.MapPath("~/FileTemp");
            var dirPath = rootPath + "/" + dateFormat + "/";
             
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var filePath = dirPath + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf"; 

            Response.Clear();
            Response.AddHeader("Content-disposition", "attachment;filename=" + dateFormat + ".pdf");  
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/pdf"; 
            Response.Charset = "gb2312";
            Response.WriteFile(filePath); 
            Response.Flush();
            Response.End(); 

        }



        #region 私有函数

        private PagerQuery<PagerInfo, CriteriaDetaildata, IEnumerable<DetaildataListModel>> GetData(PagerQuery<PagerInfo, CriteriaDetaildata, IEnumerable<DetaildataListModel>> model = null)
        {
            if (model == null)
            {
                model = new PagerQuery<PagerInfo, CriteriaDetaildata, IEnumerable<DetaildataListModel>>();
            }

            var recordCount = decimal.Zero;
            var resultMsg = string.Empty;
            var pager = new PagerInfo(this.HttpContext);
            IFacadeDetaildata dataFacade= new FacadeDetaildata();
            IEnumerable<DetaildataListModel> listModel = new List<DetaildataListModel>();
            DataSet data = dataFacade.QueryDetaildataListPager(out resultMsg, out recordCount, model.Search, pager.PageSize, pager.CurrentPageIndex);
           // todo : tolist

            pager.RecordCount = (int)recordCount;
            model.Pager = pager;
            model.DataList = listModel;
            return model; 
        }

        #endregion

    }
}
