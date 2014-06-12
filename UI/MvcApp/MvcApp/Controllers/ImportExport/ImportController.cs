using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Criterias.CustomsCriterias;
using MvcApp.Models.ImportExport;
using System.IO;
using Library.Facades.Customs.Interfaces;
using Library.Facades.Customs.Classes;
using System.Data;
using System.Data.OleDb;
using DevExpress.Common.Utils.v12;

namespace MvcApp.Controllers.ImportExport
{
    /// <summary>
    /// Created by：cz，2014-6-09，导入查询
    /// </summary>
    public class ImportController : BaseController
    {
        #region Action
        public ActionResult Index()
        {
            return View(GetData());
        }
        [HttpPost]
        public ActionResult Index(PagerQuery<PagerInfo, CriteriaImport, IEnumerable<ImportListModel>> pagerQuery=null)
        {
            return View(GetData(pagerQuery));
        }
        public ActionResult FileSelection()
        {
            return View();
        }
        /// <summary>
        /// EXCEL上传
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Upload(HttpPostedFileBase fileData)
        {
            try
            {
                var dateFormat = DateTime.Now.ToString("yyyyMMdd");
                var rootPath = Server.MapPath("~/FileExcel");
                var dirPath = rootPath + "/" + dateFormat + "/";
                // 文件上传后的保存路径
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                string fileName = Path.GetFileName(fileData.FileName);// 原始文件名称
                string extName = fileName.Substring(0,fileName.LastIndexOf('.'));
                string[] fileNameArry = extName.Split('_');
                if (fileNameArry.LongLength == 3 )
                {
                    if (!facadeInhead.IsExist(fileNameArry[0], fileNameArry[2]))//是否存在数据
                    {
                        fileData.SaveAs(dirPath + fileName);
                        WriteCustom(dirPath + fileName);
                    }
                    else
                    {
                        return Json(new { Success = false, Message = "该用户对应的订单号已存在", FileName = fileName });
                    }
                }
                else
                {
                    return Json(new { Success = false, Message = "命名不正确", FileName = fileName });
                }
                
                return Json(new { Success = true, FileName = fileName });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region Methods
        private IFacadePrepareInhead facadeInhead = new FacadePrepareInhead();
        private static string connectionStringFormat = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';" + "Extended Properties=Excel 8.0;";
        private object GetData(PagerQuery<PagerInfo, CriteriaImport, IEnumerable<ImportListModel>> pagerQuery = null)
        {
            var pageInfo = new PagerInfo(this.HttpContext);
            if (pagerQuery == null)
            {
                pagerQuery = new PagerQuery<PagerInfo, CriteriaImport, IEnumerable<ImportListModel>>(pageInfo, new CriteriaImport(), null);
            }
            else
            {
                int recordCount = 0;
                int TotalPages = 0;
                var resultMsg = string.Empty;
            }
            return pagerQuery;
        }
        /// <summary>
        /// 导入入仓单数据到数据库
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static bool WriteCustom(string strFilePath)
        {
            bool Result = true;
            DataSet myDs = new DataSet();
            try
            {
                string connectString = string.Format(connectionStringFormat, strFilePath);
                OleDbConnection cnnxls = new OleDbConnection(connectString);
                List<string> Sheets = ExcelHelper.GetExcelTablesName(connectString);
                for (int i = 0; i < Sheets.Count; i++)
                {
                    OleDbDataAdapter myDa = new OleDbDataAdapter(string.Format("select * from [{0}]", Sheets[i]), cnnxls);
                    myDa.Fill(myDs, Sheets[i].ToString());
                }
               
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }
        private static void WriteCus(DataSet myDs, string Order)
        {
            //数据插入
            DataRow dr = myDs.Tables[0].Rows[0];
            DataTable dt = myDs.Tables[1];
        }
        #endregion
    }
}
