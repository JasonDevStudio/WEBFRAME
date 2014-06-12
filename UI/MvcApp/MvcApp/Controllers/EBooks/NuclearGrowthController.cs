using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Library.Criterias.CustomsCriterias;
using MvcApp.Models.EBooks;
using Library.StringItemDict;
using Library.Facades.BasicData.Interfaces;
using Library.Facades.BasicData.Classes;
//using Library.Common;
using MvcApp.Helpers;
using Library.Facades.Customs.Interfaces;
using Library.Facades.Customs.Classes;
using MvcApp.Models.Customs;
using MvcApp.Report.Common;
using ILIMS.DxUI.UI.Report.ReportWarehouseBillManage;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using ILIMS.Common;

namespace MvcApp.Controllers.EBooks
{
    /// <summary>
    /// Created by：cz，2014-5-21，核增查询
    /// </summary>
    public class NuclearGrowthController : BaseController
    {

        #region Action
        public ActionResult Index()
        {
            try
            {
                //权限验证
                this.HasActionPower();

                return View(this.GetData());
            }
            catch (Exception ex)
            {
                var model = new PagerQuery<PagerInfo, CriteriaNuclearGrowth, IEnumerable<NuclearGrowthListModel>>(new PagerInfo(this.HttpContext), new CriteriaNuclearGrowth(), null);
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                return View(model);
            } 
        }
        [HttpPost]
        public ActionResult Index(PagerQuery<PagerInfo, CriteriaNuclearGrowth, IEnumerable<NuclearGrowthListModel>> pagerQuery = null)
        {
            try
            {
                //权限验证
                this.HasActionPower();

                return View(this.GetData(pagerQuery));
            }
            catch (Exception ex)
            {
                var model = new PagerQuery<PagerInfo, CriteriaNuclearGrowth, IEnumerable<NuclearGrowthListModel>>(new PagerInfo(this.HttpContext), new CriteriaNuclearGrowth(), null);
                var msgT = Server.UrlEncode("系统出现错误,请联系客服或管理员处理!");
                var msgD = Server.UrlEncode(ex.Message);
                UrlHelper url = new UrlHelper(this.Request.RequestContext);
                this.Response.Redirect(url.Action("Index", "Error", new { msgTitle = msgT, msgDetail = msgD }));
                return View(model);
            } 
            
        }
        public ActionResult Details(string id)
        {
            NuclearGrowthEditModel model = new NuclearGrowthEditModel();
            List<NuclearGrowthEditInfoModel> list = new List<NuclearGrowthEditInfoModel>();
            model.infoModel = new List<NuclearGrowthEditInfoModel>();
            try
            {
                //权限验证
                //this.HasActionPower();

                if (!string.IsNullOrWhiteSpace(id))
                {
                    DataTable in_head = new DataTable();
                    DataTable in_list = new DataTable();
                    this.facadeVHz.GetDetailsData(id, out in_head, out in_list);
                    if (in_head != null && in_head.Rows.Count > 0)
                    {
                        model = in_head.ToList<NuclearGrowthEditModel>().First();
                        if (in_list != null && in_list.Rows.Count > 0)
                        {
                            foreach (DataRow row in in_list.Rows)
                            {
                                NuclearGrowthEditInfoModel infoModel = new NuclearGrowthEditInfoModel();
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
                                infoModel.mass_no = Convert.ToDecimal(row["mass_no"]);
                                infoModel.pcs = row["pcs"].ToString();
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

                var fileName = id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
                var filePath = dirPath + fileName;

                string condition = "bill_id=" + "\'" + id + "\'";
                var Store_in_headInfo = Customs.BLL.BLLFactory<Customs.BLL.Store_in_head>.Instance.FindSingle(condition);
                var CurInList = Customs.BLL.BLLFactory<Customs.BLL.Store_in_list>.Instance.Find(condition, "order by g_no");
                CommonPrint print = new CommonPrint() { CurInHead = Store_in_headInfo, CurInList = CurInList };
                print.InPrint(id,out filePath);

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
                //this.HasActionPower();

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
                //取出当前点中的行的核增单号
                string sCurrentRowBillCode = id;
                string LadingType = lading_type;

                DataTable dtbEnterprise001 = new DataTable();     //监管仓仓租企业
                DataTable dtbEnterprise500 = new DataTable();     //保税仓仓租企业
                DataTable dtbInType001 = new DataTable();        //监管仓核增方式
                DataTable dtbInType500 = new DataTable();        //保税仓核增方式 
                DataTable dtbSPBCODES = new DataTable();

                dtbInType001 = BasicData.BLL.BLLFactory<BasicData.BLL.B_datacategory>.Instance.GetInWarehouseTypeFromDepot("001", true);
                dtbInType500 = BasicData.BLL.BLLFactory<BasicData.BLL.B_datacategory>.Instance.GetInWarehouseTypeFromDepot("500", true);
                dtbSPBCODES = BasicData.BLL.BLLFactory<BasicData.BLL.C_codes>.Instance.GetAllToDataTable();

                Customs.Entity.Store_in_headInfo Store_in_head = Customs.BLL.BLLFactory<Customs.BLL.Store_in_head>.Instance.FindSingle(" BILL_ID='" + sCurrentRowBillCode + "'");
                DataTable dstInHead = Customs.BLL.BLLFactory<Customs.BLL.Store_in_head>.Instance.SelectSimpleStoreInHead(sCurrentRowBillCode);
                DataTable dstInList = Customs.BLL.BLLFactory<Customs.BLL.Store_in_list>.Instance.SelectSimpleStoreInList(sCurrentRowBillCode);
                dstInHead.Rows[0]["dec_type"] = CommonReport.GetDecCodeName(dstInHead.Rows[0]["dec_type"].ToString());
                if (LadingType == "MCC" && dstInList.Rows.Count > 20)
                {
                    if (dstInList != null)
                    {
                        dstInList.Columns.Add("ColNo", typeof(string));
                        //增加汇总行
                        decimal TotalNet = 0;
                        decimal TotalGross = 0;
                        decimal TotalPrice = 0;
                        decimal TotalPkgs = 0;

                        #region
                        if (dstInList != null)
                        {
                            if (dstInList.Rows.Count > 0)
                            {
                                DataRow dr = null;
                                int m = 0;
                                for (int i = 0; i < dstInList.Rows.Count; i++)
                                {
                                    if (dstInList.Rows[i]["BILL_ID"] != null && dstInList.Rows[i]["BILL_ID"].ToString().Trim() != "")
                                    {
                                        TotalNet += string.IsNullOrEmpty(dstInList.Rows[i]["NET"].ToString().Trim()) ? 0 : decimal.Parse(dstInList.Rows[i]["NET"].ToString().Trim());
                                        TotalGross += string.IsNullOrEmpty(dstInList.Rows[i]["GROSS"].ToString().Trim()) ? 0 : decimal.Parse(dstInList.Rows[i]["GROSS"].ToString().Trim());
                                        TotalPrice += string.IsNullOrEmpty(dstInList.Rows[i]["TRADE_TTL"].ToString().Trim()) ? 0 : decimal.Parse(dstInList.Rows[i]["TRADE_TTL"].ToString().Trim());
                                        TotalPkgs += string.IsNullOrEmpty(dstInList.Rows[i]["PKGS"].ToString().Trim()) ? 0 : decimal.Parse(dstInList.Rows[i]["PKGS"].ToString().Trim());
                                        m++;

                                        if (m % 20 == 0 && m != 0)
                                        {
                                            dr = dstInList.NewRow();
                                            dr["NET"] = TotalNet;
                                            dr["GROSS"] = TotalGross;
                                            dr["TRADE_TTL"] = TotalPrice;
                                            dr["PKGS"] = TotalPkgs;
                                            dr["ColNo"] = i + 1;
                                            dr["QTY_2"] = 0;
                                            dr["ORIGN_COUN"] = "";
                                            dr["Curr_code"] = "";
                                            dstInList.Rows.InsertAt(dr, i + 1);
                                            TotalNet = 0;
                                            TotalGross = 0;
                                            TotalPrice = 0;
                                            TotalPkgs = 0;
                                        }
                                        else
                                        {
                                            dstInList.Rows[i]["ColNo"] = i + 1;
                                        }
                                    }

                                }

                                if (TotalNet != 0)//如果非21倍数
                                {
                                    dr = dstInList.NewRow();
                                    dr["NET"] = TotalNet;
                                    dr["GROSS"] = TotalGross;
                                    dr["TRADE_TTL"] = TotalPrice;
                                    dr["PKGS"] = TotalPkgs;
                                    dr["ColNo"] = "小计";
                                    dr["ORIGN_COUN"] = "";
                                    dr["Curr_code"] = "";
                                    dr["QTY_2"] = 0;

                                    dstInList.Rows.InsertAt(dr, dstInList.Rows.Count);
                                }
                            }
                        }
                        #endregion
                    }
                }

                //获得列表中商品内容

                string CODE_TS = "";
                foreach (DataRow drw in dstInList.Rows)
                {
                    CODE_TS += drw["CODE_T"].ToString().Trim() + "|";
                }

                //List<Customs.Entity.Store_in_listInfo> dtbSTORE_IN_LIST = Customs.BLL.BLLFactory<Customs.BLL.Store_in_list>.Instance.Find(" BILL_ID='" + Store_in_head.Bill_id + "'", " order by g_no ");

                DataTable dstComplexys = BasicData.BLL.BLLFactory<BasicData.BLL.C_complex>.Instance.GetListByCodes(CODE_TS);
                DataSet dstReport = new DataSet();
                DataTable dtbHead = new DataTable("STORE_IN_HEAD");
                DataTable dtbList = new DataTable("STORE_IN_LIST");
                DataTable dtbSpbComplexys = new DataTable("SPBCOMPLEXYS");
                dtbHead = dstInHead.Copy();
                dtbList = dstInList.Copy();
                dtbSpbComplexys = dstComplexys.Copy();
                dstReport.Tables.Add(dtbHead);
                //dstReport.Tables.Add(dtbList);
                //dstReport.Tables.Add(dtbSpbComplexys);

                DataTable Enterprise = null;
                DataTable InType = null;
                if (Store_in_head.Lading_type == "保税")
                {
                    InType = dtbInType500;
                }
                else
                {
                    InType = dtbInType001;
                }
                Enterprise = BasicData.BLL.BLLFactory<BasicData.BLL.B_custom_info>.Instance.GetEnterpriseFromDepot(string.Empty);

                XtraReport reportClass = new Rpt_Customs_InWarehouseBil(Store_in_head, dstInList, dtbSPBCODES, Enterprise, InType, dstComplexys);
                reportClass.DataSource = dstReport;
                reportClass.DataMember = "STORE_IN_HEAD";
                reportClass.ExportToPdf(filePath);
                #endregion
                 
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
        private IFacadeVHz facadeVHz = new FacadeVHz();
        private object GetData(PagerQuery<PagerInfo, CriteriaNuclearGrowth, IEnumerable<NuclearGrowthListModel>> pagerQuery = null)
        {
            var pageInfo = new PagerInfo(this.HttpContext);
            if (pagerQuery == null)
            {
                pagerQuery = new PagerQuery<PagerInfo, CriteriaNuclearGrowth, IEnumerable<NuclearGrowthListModel>>(pageInfo, new CriteriaNuclearGrowth(), null);
                pagerQuery.Search.WarehousingStartTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
                pagerQuery.Search.WarehousingEndTime = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                int recordCount = 0;
                int TotalPages=0;
                var resultMsg = string.Empty;

                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.WarehousingStartTime))
                {
                    pagerQuery.Search.WarehousingStartTime += " 00:00:00";
                }
                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.WarehousingEndTime))
                {
                    pagerQuery.Search.WarehousingEndTime += " 23:59:59";
                }
                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.CargoType))
                {
                    pagerQuery.Search.CargoTypeTest = Universal.GetStatusName(_Dictionary.CargoType,pagerQuery.Search.CargoType);
                }
                if (!string.IsNullOrWhiteSpace(pagerQuery.Search.ApprovalStatus))
                {
                    decimal status = Convert.ToDecimal(pagerQuery.Search.ApprovalStatus);
                    pagerQuery.Search.ApprovalStatus = ((int)status).ToString();
                }
                var data =this.facadeVHz.QueryV_HZListPager(out resultMsg, out recordCount, out TotalPages, pagerQuery.Search, pageInfo.PageSize, pageInfo.CurrentPageIndex).ToList<NuclearGrowthListModel>();
                pageInfo.RecordCount = recordCount;
                pagerQuery.Pager = pageInfo;
                pagerQuery.Pager.TotalPages = TotalPages;
                pagerQuery.DataList = data;
               
            }
            pagerQuery.Search.CargoTypeList = DropDownListFor.GetCargoTypeSelect(null, true);
            pagerQuery.Search.TradeList = DropDownListFor.GetTradeSelect(null, true);
            pagerQuery.Search.ApprovalStatusList = DropDownListFor.GetApprovalStatusSelect(null, true);
            pagerQuery.Search.WarehousingApproachList = DropDownListFor.GetWarehousingApproachSelect(null, true);
            pagerQuery.Search.CustomerNameList = DropDownListFor.GetCustomerNameSelect(this.CurrentUser.Userid, pagerQuery.Search.CargoType, null, true);
            pagerQuery.Search.LockStatusList = DropDownListFor.GetLockingStatusSelect(null, false);
            return pagerQuery;
        }

        /// <summary>
        /// 构造查询SQL条件
        /// </summary> 
        /// <param name="sCargoType">货物类型</param> 
        /// <param name="bllid">订单号</param> 
        /// <returns>Sql</returns>
        private string GetSQLCondition(string sCargoType = "",string bllid="")
        {  
            string sSQLWhere = string.Empty;
            //获取查询的货物类型 
            sCargoType = CommonReport.InputText(sCargoType, sCargoType.Length);
            if (!string.IsNullOrWhiteSpace(sCargoType))
            {
                sSQLWhere += " lading_type ='" + sCargoType + "'";
            }
             
            if (!string.IsNullOrWhiteSpace(bllid))
            {
                sSQLWhere += " AND bill_id = '" + bllid + "'";
            } 
             
            return sSQLWhere;
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
