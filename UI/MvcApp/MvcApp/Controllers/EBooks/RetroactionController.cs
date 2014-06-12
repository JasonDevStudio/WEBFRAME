using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models.EBooks;
using Library.Criterias.CustomsCriterias;
using Library.Facades.Customs.Interfaces;
using Library.Facades.Customs.Classes;


using System.Data;
using MvcApp.Helpers;
namespace MvcApp.Controllers.EBooks
{
    public class RetroactionController : BaseController
    {
        #region Action
        public ActionResult Index()
        {
            try
            {
                //权限验证
                this.HasActionPower();

                return View(GetData());
            }
            catch (Exception ex)
            {
                var model = new PagerQuery<PagerInfo, CriteriaRetroaction, IEnumerable<RetroactionListModel>>(new PagerInfo(this.HttpContext), new CriteriaRetroaction(), null);
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                return View(model);
            } 
            
        }
        [HttpPost]
        public ActionResult Index(PagerQuery<PagerInfo, CriteriaRetroaction, IEnumerable<RetroactionListModel>> pagerQuery = null)
        {
            try
            {
                //权限验证
                this.HasActionPower();

                return View(GetData(pagerQuery));
            }
            catch (Exception ex)
            {
                var model = new PagerQuery<PagerInfo, CriteriaRetroaction, IEnumerable<RetroactionListModel>>(new PagerInfo(this.HttpContext), new CriteriaRetroaction(), null);
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                return View(GetData(pagerQuery));
            } 
            
        } 
        #endregion
        #region Methods
        private IFacadeWebproCusreturn facade = new FacadeWebproCusreturn();
        private object GetData(PagerQuery<PagerInfo, CriteriaRetroaction, IEnumerable<RetroactionListModel>> pagerQuery = null)
        {
            var pageInfo = new PagerInfo(this.HttpContext);
            if (pagerQuery == null)
            {
                pagerQuery = new PagerQuery<PagerInfo, CriteriaRetroaction, IEnumerable<RetroactionListModel>>(pageInfo, new CriteriaRetroaction(), null);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(pagerQuery.Search.lease_holder) && this.CurrentUser.Userid != "0505")
                {
                    pagerQuery.Search.lease_holder = this.CurrentUser.Userid;
                }
                int recordCount = 0;
                int TotalPages = 0;
                var resultMsg = string.Empty;
                var data = this.facade.QueryWebproCusreturnListPager(out resultMsg, out recordCount, out TotalPages, pagerQuery.Search, pageInfo.PageSize, pageInfo.CurrentPageIndex).ToList<RetroactionListModel>();
                pageInfo.RecordCount = recordCount;
                pagerQuery.Pager = pageInfo;
                pagerQuery.Pager.TotalPages = TotalPages;
                pagerQuery.DataList = data;
            }
            pagerQuery.Search.CustomerNameList = DropDownListFor.GetCustomerNameSelect(this.CurrentUser.Userid, "", null, true);
            return pagerQuery;
        }
        #endregion
    }
}
