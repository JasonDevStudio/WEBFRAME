using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models.EBooks;
using Library.Criterias.CustomsCriterias;
using MvcApp.Helpers;
using Library.Common;
using Library.StringItemDict;
using Library.Facades.Customs.Interfaces;
using Library.Facades.Customs.Classes;
using System.Data;
using DevExpress.XtraReports.UI;
using System.IO;
using MvcApp.Report.Common;
using ILIMS.DxUI.UI.Report.ReportWarehouseBillManage;
using System.Text; 
using System.Net;
using System.Threading; 
using System.Web.Script.Serialization; 

namespace MvcApp.Controllers.EBooks
{
    /// <summary>
    /// Created by：cz，2014-5-27，核扣查询
    /// </summary>
    public class NuclearButtonController : BaseController
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
                var model = new PagerQuery<PagerInfo, CriteriaNuclearButton, IEnumerable<NuclearButtonListModel>>(new PagerInfo(this.HttpContext), new CriteriaNuclearButton(), null);
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Index(PagerQuery<PagerInfo, CriteriaNuclearButton, IEnumerable<NuclearButtonListModel>> pagerQuery = null)
        {
            
            try
            {
                //权限验证
                this.HasActionPower();

                return View(this.GetData(pagerQuery));
            }
            catch (Exception ex)
            {
                var model = new PagerQuery<PagerInfo, CriteriaNuclearButton, IEnumerable<NuclearButtonListModel>>(new PagerInfo(this.HttpContext), new CriteriaNuclearButton(), null);
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                return View(model);
            }
        }
        public ActionResult Details(string id)
        {
            NuclearButtonEditModel model = new NuclearButtonEditModel();
            List<NuclearButtonEditInfoModel> list = new List<NuclearButtonEditInfoModel>();
            model.infoModel = new List<NuclearButtonEditInfoModel>();
            try
            {
                //权限验证
                //this.HasActionPower();

                if (!string.IsNullOrWhiteSpace(id))
                {
                    DataTable out_head = new DataTable();
                    DataTable out_list = new DataTable();
                    this.facadeVHk.GetDetailsData(id, out out_head, out out_list);
                    if (out_head != null && out_head.Rows.Count > 0)
                    {
                        model = out_head.ToList<NuclearButtonEditModel>().First();
                        if (out_list != null && out_list.Rows.Count > 0)
                        {
                            foreach (DataRow row in out_list.Rows)
                            {
                                NuclearButtonEditInfoModel infoModel = new NuclearButtonEditInfoModel();
                                infoModel.in_bill_id = row["in_bill_id"].ToString();
                                infoModel.in_g_no =row["in_g_no"]!=DBNull.Value?Convert.ToDecimal(row["in_g_no"]):0;
                                infoModel.cust_in_bill_id = row["cust_in_bill_id"].ToString();
                                infoModel.code_t = row["code_t"].ToString();
                                infoModel.mg_name = row["mg_name"].ToString();
                                infoModel.mg_spec = row["mg_spec"].ToString();
                                infoModel.g_qty = Convert.ToDecimal(row["g_qty"]);
                                infoModel.g_unit = Universal.GetStatusName(_Dictionary.CreatStoreUnit, row["g_unit"].ToString());
                                infoModel.curr_code = Universal.GetStatusName(_Dictionary.ParaExchrate, row["curr_code"].ToString());
                                infoModel.unit_price = Convert.ToDecimal(row["unit_price"]);
                                infoModel.trade_ttl = Convert.ToDecimal(row["trade_ttl"]);
                                infoModel.orign_coun = Universal.GetCcodesDisplayName(_Pccode.SourceDestination, row["orign_coun"].ToString());
                                infoModel.zm_code = Universal.GetCcodesDisplayName(_Pccode.ExemptWay, row["zm_code"].ToString());
                                infoModel.baxh = row["baxh"].ToString();
                                infoModel.code_s = row["code_s"].ToString();
                                infoModel.rate = Convert.ToDecimal(row["rate"]);
                                infoModel.rate_id = row["rate_id"].ToString();
                                infoModel.pkgs = Convert.ToDecimal(row["pkgs"]);
                                infoModel.gross = Convert.ToDecimal(row["gross"]);
                                infoModel.net = Convert.ToDecimal(row["net"]);
                                infoModel.qty_1 = Convert.ToDecimal(row["qty_1"]);
                                infoModel.unit_code1 = Universal.GetStatusName(_Dictionary.CreatStoreUnit, row["unit_code1"].ToString());
                                infoModel.usd_unit_price = Convert.ToDecimal(row["usd_unit_price"]);
                                infoModel.usd_trade_ttl = Convert.ToDecimal(row["usd_trade_ttl"]);
                                infoModel.version_num = row["version_num"].ToString();
                                infoModel.qty_2 = Convert.ToDecimal(row["qty_2"]);
                                infoModel.unit_code2 = Universal.GetStatusName(_Dictionary.CreatStoreUnit, row["unit_code2"].ToString());
                                infoModel.loc = row["loc"].ToString();
                                list.Add(infoModel);
                            }
                            model.infoModel = list;
                            JavaScriptSerializer json = new JavaScriptSerializer();
                            model.jsonList = json.Serialize(list);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
            } 
            return View(model);
        }

        /// <summary>
        /// 报关单打印
        /// </summary>
        /// <param name="id">订单号</param>
        public void CustomsPrint(string id)
        {
            try
            {
                //权限验证
                //this.HasActionPower();

                if (string.IsNullOrWhiteSpace(id))
                {
                    var msgT = Server.UrlEncode("参数传输错误!");
                    var msgD = Server.UrlEncode(string.Empty);
                    UrlHelper url = new UrlHelper(this.Request.RequestContext);
                    this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                }

                var dateFormat = DateTime.Now.ToString("yyyyMMdd");
                var rootPath = Server.MapPath("~/FileTemp");
                var dirPath = rootPath + "/" + dateFormat + "/";

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                  
                string condition = "bill_id=" + "\'" + id + "\'";
                var Store_out_headInfo = Customs.BLL.BLLFactory<Customs.BLL.Store_out_head>.Instance.FindSingle(condition);
                var CurOutList = Customs.BLL.BLLFactory<Customs.BLL.Store_out_list>.Instance.Find(condition, "order by g_no");
                CommonPrint print = new CommonPrint() { CurOutHead = Store_out_headInfo, CurOutList = CurOutList };
                  
                var filePath = string.Empty;
                print.OutPrint(id,out filePath);
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    RespWrite(filePath);
                } 
            }
            catch (Exception ex)
            {
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
            }
        }
         
        /// <summary>
        /// 复核表打印
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="lading_type">货物类型</param> 
        public void ReviewPrint(string id, string lading_type)
        {
            try
            {
                //权限验证
                this.HasActionPower();

                if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(lading_type))
                {
                    var msgT = Server.UrlEncode("参数传输错误!");
                    var msgD = Server.UrlEncode(string.Empty);
                    UrlHelper url = new UrlHelper(this.Request.RequestContext);
                    this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                }

                var dateFormat = DateTime.Now.ToString("yyyyMMdd");
                var rootPath = Server.MapPath("~/FileTemp");
                var dirPath = rootPath + "/" + dateFormat + "/";

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                var fileName = id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
                var filePath = dirPath + fileName;

                #region 生成pdf
                
                //取出当前点中的行的核扣单号
                //取出当前点中的行的核增单号
                string sCurrentRowBillCode = id;
                string LadingType = lading_type;

                DataTable dtbEnterprise001 = new DataTable();     //监管仓仓租企业
                DataTable dtbEnterprise500 = new DataTable();     //保税仓仓租企业
                DataTable dtbOutType001 = new DataTable();        //监管仓核扣方式
                DataTable dtbOutType500 = new DataTable();        //保税仓核扣方式
                DataTable _allSPBCODES = new DataTable();

                dtbEnterprise001 = BasicData.BLL.BLLFactory<BasicData.BLL.B_custom_info>.Instance.GetEnterpriseFromDepot("1", true);
                dtbEnterprise500 = BasicData.BLL.BLLFactory<BasicData.BLL.B_custom_info>.Instance.GetEnterpriseFromDepot("2", true);
                dtbOutType001 = BasicData.BLL.BLLFactory<BasicData.BLL.B_datacategory>.Instance.GetOutType("001", true);
                dtbOutType500 = BasicData.BLL.BLLFactory<BasicData.BLL.B_datacategory>.Instance.GetOutType("500", true);
                _allSPBCODES = BasicData.BLL.BLLFactory<BasicData.BLL.C_codes>.Instance.GetAllToDataTable();

                Customs.Entity.Store_out_headInfo Store_Out_head = Customs.BLL.BLLFactory<Customs.BLL.Store_out_head>.Instance.FindSingle(" Bill_id='" + sCurrentRowBillCode + "'");

                

                

                DataTable dstOutHead = Customs.BLL.BLLFactory<Customs.BLL.Store_out_head>.Instance.SelectSimpleStoreOutHead(sCurrentRowBillCode);
                DataTable dstOutList = Customs.BLL.BLLFactory<Customs.BLL.Store_out_list>.Instance.SelectSimpleStoreOutList(sCurrentRowBillCode);

                dstOutHead.Rows[0]["dec_type"] = CommonReport.GetDecCodeName(dstOutHead.Rows[0]["dec_type"].ToString());
                if (dstOutList != null)
                {
                    dstOutList.Columns.Add("ColNo", typeof(string));
                    //增加汇总行
                    decimal TotalNet = 0;
                    decimal TotalGross = 0;
                    decimal TotalPrice = 0;
                    decimal TotalPkgs = 0;

                    if (dstOutList != null && dstOutList.Rows.Count > 0)
                    {

                        DataRow dr = null;
                        int m = 0;
                        for (int i = 0; i < dstOutList.Rows.Count; i++)
                        {

                            if (dstOutList.Rows[i]["BILL_ID"] != null && dstOutList.Rows[i]["BILL_ID"].ToString().Trim() != "")
                            {
                                TotalNet += string.IsNullOrEmpty(dstOutList.Rows[i]["NET"].ToString().Trim()) ? 0 : decimal.Parse(dstOutList.Rows[i]["NET"].ToString().Trim());
                                TotalGross += string.IsNullOrEmpty(dstOutList.Rows[i]["GROSS"].ToString().Trim()) ? 0 : decimal.Parse(dstOutList.Rows[i]["GROSS"].ToString().Trim());
                                TotalPrice += string.IsNullOrEmpty(dstOutList.Rows[i]["USD_TRADE_TTL"].ToString().Trim()) ? 0 : decimal.Parse(dstOutList.Rows[i]["USD_TRADE_TTL"].ToString().Trim());
                                TotalPkgs += string.IsNullOrEmpty(dstOutList.Rows[i]["PKGS"].ToString().Trim()) ? 0 : decimal.Parse(dstOutList.Rows[i]["PKGS"].ToString().Trim());
                                m++;

                                if (m % 20 == 0 && m != 0)
                                {
                                    dr = dstOutList.NewRow();
                                    dr["NET"] = TotalNet;
                                    dr["GROSS"] = TotalGross;
                                    dr["USD_TRADE_TTL"] = TotalPrice;
                                    dr["PKGS"] = TotalPkgs;
                                    dr["ColNo"] = i + 1;
                                    dr["QTY_2"] = 0;
                                    dr["ORIGN_COUN"] = "";
                                    dr["Curr_code"] = "";


                                    dstOutList.Rows.InsertAt(dr, i + 1);
                                    TotalNet = 0;
                                    TotalGross = 0;
                                    TotalPrice = 0;
                                    TotalPkgs = 0;
                                }
                                else
                                {
                                    dstOutList.Rows[i]["ColNo"] = i + 1;
                                }
                            }

                        }

                        if (TotalNet != 0)//如果非21倍数
                        {
                            dr = dstOutList.NewRow();
                            dr["NET"] = TotalNet;
                            dr["GROSS"] = TotalGross;
                            dr["USD_TRADE_TTL"] = TotalPrice;
                            dr["PKGS"] = TotalPkgs;
                            dr["ColNo"] = "小计";
                            dr["QTY_2"] = 0;
                            dr["ORIGN_COUN"] = "";
                            dr["Curr_code"] = "";
                            dstOutList.Rows.InsertAt(dr, dstOutList.Rows.Count);
                        }
                    }

                }
                //获得列表中商品内容
                string CODE_TS = "";

                foreach (DataRow drw in dstOutList.Rows)
                {
                    CODE_TS += drw["CODE_T"].ToString().Trim() + "|";
                }


                DataTable dstComplexys = new DataTable();
                if (!string.IsNullOrEmpty(CODE_TS))
                {
                    dstComplexys = BasicData.BLL.BLLFactory<BasicData.BLL.C_complex>.Instance.GetListByCodes(CODE_TS);
                }


                DataSet dstReport = new DataSet(); 
                dtbEnterprise001 = BasicData.BLL.BLLFactory<BasicData.BLL.B_custom_info>.Instance.GetEnterpriseFromDepot(string.Empty);
                 
                XtraReport reportClass =  new Rpt_Customs_OutWarehouseBill(Store_Out_head, dstOutList, _allSPBCODES, dtbEnterprise001, dtbOutType001, dtbOutType500, dstComplexys);
                reportClass.DataSource = dstReport;
                reportClass.DataMember = "STORE_OUT_HEAD";
                reportClass.ExportToPdf(filePath);
                #endregion

                //写出文件
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    RespWrite(filePath);
                }                 
            }
            catch (Exception ex)
            {
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
            }
        }

        #endregion
        #region AJAX
        /// <summary>
        /// 获取用户下拉
        /// </summary>
        /// <param name="server_type"></param>
        /// <returns></returns>
        public JsonResult CustomerNameChange(string server_type)
        {

            IEnumerable<SelectListItem> CustomerNameList = DropDownListFor.GetCustomerNameSelect(this.CurrentUser.Userid, server_type, null, true);
            return Json(CustomerNameList, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Methods
        private IFacadeVHk facadeVHk = new FacadeVHk();
        private object GetData(PagerQuery<PagerInfo, CriteriaNuclearButton, IEnumerable<NuclearButtonListModel>> pagerQuery = null)
        {
            var pageInfo = new PagerInfo(this.HttpContext);
            if (pagerQuery == null)
            {
                pagerQuery = new PagerQuery<PagerInfo, CriteriaNuclearButton, IEnumerable<NuclearButtonListModel>>(pageInfo, new CriteriaNuclearButton(), null);
                pagerQuery.Search.WayOutStartTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
                pagerQuery.Search.WayOutEndTime = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                int recordCount = 0;
                int TotalPages = 0;
                var resultMsg = string.Empty;
                if (string.IsNullOrWhiteSpace(pagerQuery.Search.CustomerName)&&this.CurrentUser.Userid!="0505")
                {
                    pagerQuery.Search.CustomerName = this.CurrentUser.Userid;
                }
                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.WayOutStartTime))
                {
                    pagerQuery.Search.WayOutStartTime += " 00:00:00";
                }
                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.WayOutEndTime))
                {
                    pagerQuery.Search.WayOutEndTime += " 23:59:59";
                }
                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.CargoType))
                {
                    pagerQuery.Search.CargoTypeTest = Universal.GetStatusName(_Dictionary.CargoType, pagerQuery.Search.CargoType);
                }
                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.ApprovalStatus))
                {
                    decimal status = Convert.ToDecimal(pagerQuery.Search.ApprovalStatus);
                    pagerQuery.Search.ApprovalStatus = ((int)status).ToString();
                }
                var data = this.facadeVHk.QueryV_HKListPager(out resultMsg, out recordCount, out TotalPages, pagerQuery.Search, pageInfo.PageSize, pageInfo.CurrentPageIndex).ToList<NuclearButtonListModel>();
                pageInfo.RecordCount = recordCount;
                pagerQuery.Pager = pageInfo;
                pagerQuery.Pager.TotalPages = TotalPages;
                pagerQuery.DataList = data;
            }
            pagerQuery.Search.CargoTypeList = DropDownListFor.GetCargoTypeSelect(null, true);
            pagerQuery.Search.CustomerNameList = DropDownListFor.GetCustomerNameSelect(this.CurrentUser.Userid, pagerQuery.Search.CargoType, null, true);
            pagerQuery.Search.WayOutList = DropDownListFor.GetWayOutSelect(null, true);
            pagerQuery.Search.LockStatusList = DropDownListFor.GetLockingStatusSelect(null, false);
            pagerQuery.Search.ApprovalStatusList = DropDownListFor.GetApprovalStatusSelect(null, true);
            return pagerQuery;
        }

        /// <summary>
        /// 写出文件
        /// </summary>
        /// <param name="filePath"></param>
        private void RespWrite(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            Response.Clear();
            Response.AddHeader("Content-disposition", "attachment;filename=" + fileName);
            //Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/pdf";
            Response.Charset = "UTF8";
            Response.WriteFile(filePath);
            Response.Flush();
            Response.End();
        }
        #endregion
    }
}   
