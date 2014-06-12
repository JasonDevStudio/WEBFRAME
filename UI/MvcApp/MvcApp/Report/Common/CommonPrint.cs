using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ILIMS.UI;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using Library.Common.Pdf;

namespace MvcApp.Report.Common
{
    public class CommonPrint
    {
        #region 初始化数据
        //入仓单明细
        public Customs.Entity.Store_in_headInfo CurInHead = null;
        public List<Customs.Entity.Store_in_listInfo> CurInList = null;
        //出仓单
        public Customs.Entity.Store_out_headInfo CurOutHead = null;
        public List<Customs.Entity.Store_out_listInfo> CurOutList = null;

         
        #endregion

        /// <summary>
        /// 如仓单打印
        /// </summary>
        public void InPrint(string id, out string filePath)
        {
            switch (CurInHead.Lading_type)
            {
                case "监管":
                    InPrintListJG(CurInList,id, out filePath);
                    break;
                case "保税":
                case "MCC":
                    InPrintListBS(CurInList,id,out filePath);
                    break;
                default:
                    filePath = string.Empty;
                    break;
            }

        }

        public void OutPrint(string id, out string filePath)
        {  
            switch (CurOutHead.Lading_type)
            {
                case "保税":
                case "MCC":
                case "监管":
                    OutPrintListJG(CurOutList, CurOutHead.Lading_type, id,out filePath);
                    break;
                default:
                    filePath = string.Empty;
                    break;
            }
        }

        #region 保税仓
        private void InPrintListBS(List<Customs.Entity.Store_in_listInfo> CurInList, string id, out string filePath)
        {
            var index = 1;
            var dateFormat = DateTime.Now.ToString("yyyyMMdd");
            var rootPath = AppDomain.CurrentDomain.BaseDirectory + "FileTemp";
            var dirPath = rootPath + "/" + dateFormat + "/";
            var fileNameF = "{0}_" + id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
            var fileName = string.Format(fileNameF, index);
            var filePathTemp = dirPath + fileName;
            var filePathArry = new List<string>();
            filePath = dirPath + id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";

            int FirstPage = 5;
            //当小于5时只打印首页
            if (CurInList.Count <= FirstPage)
            {
                Report_jkbsrc Report = new Report_jkbsrc(CurInHead, CurInList);
                ExportToPdf(Report, filePath);
                return;
            }
            else
            {
                Report_jkbsrc Report = new Report_jkbsrc(CurInHead, CurInList);
                ExportToPdf(Report, filePathTemp);
                filePathArry.Add(filePathTemp);
            }
            //当大于5时打印续页，根据总条数判断需要几个续页
            int PageSize = 10;
            int Page = (CurInList.Count - FirstPage) / PageSize;
            //最后一页有几条
            int lastPageSize = (CurInList.Count - FirstPage) % PageSize;
            for (int i = 0; i < Page; i++)
            {
                index = index + 1;
                fileName = string.Format(fileNameF, index);
                filePathTemp = dirPath + fileName;
                filePathArry.Add(filePathTemp);

                //打印续页
                Report_ExSupEx report = new Report_ExSupEx(CurInHead, CurInList, i, PageSize, false, FirstPage, "inBS");
                ExportToPdf(report, filePathTemp);
            }
            if (lastPageSize != 0)
            {
                index = index + 1;
                fileName = string.Format(fileNameF, index);
                filePathTemp = dirPath + fileName;
                filePathArry.Add(filePathTemp);

                //打印最后一页
                Report_ExSupEx report = new Report_ExSupEx(CurInHead, CurInList, Page, PageSize, true, FirstPage, "inBS");
                ExportToPdf(report, filePathTemp);
            }

            // PDF 合并
            MergerPdf(filePath, filePathArry); 
        } 

        /// <summary>
        /// 出仓 
        /// </summary>
        /// <param name="CurOutList"></param>
        private void OutPrintListJG(List<Customs.Entity.Store_out_listInfo> CurOutList, string Type, string id,out string filePath)
        {
            var index = 1;
            var dateFormat = DateTime.Now.ToString("yyyyMMdd");
            var rootPath = AppDomain.CurrentDomain.BaseDirectory + "FileTemp";
            var dirPath = rootPath + "/" + dateFormat + "/";
            var fileNameF = "{0}_"+id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
            var fileName = string.Format(fileNameF, index);
            var filePathTemp = dirPath + fileName;
            var filePathArry = new List<string>();
            filePath = dirPath + id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";

            //测试
            //Type = "保税";
            int FirstPage = 5;
            //当小于5时只打印首页
            if (CurOutList.Count <= FirstPage)
            { 
                Report_ckjgcc report = new Report_ckjgcc(CurOutHead, CurOutList, Type); 
                ExportToPdf(report, filePath); 
                return;
            }
            else
            {
                Report_ckjgcc report = new Report_ckjgcc(CurOutHead, CurOutList, Type);
                ExportToPdf(report, filePathTemp);
                filePathArry.Add(filePathTemp);
            }
            //当大于5时打印续页，根据总条数判断需要几个续页
            int PageSize = 10;
            int Page = (CurOutList.Count - FirstPage) / PageSize;
            //最后一页有几条
            int lastPageSize = (CurOutList.Count - FirstPage) % PageSize;
            for (int i = 0; i < Page; i++)
            {
                index = index + 1;
                fileName = string.Format(fileNameF, index);
                filePathTemp = dirPath + fileName;
                filePathArry.Add(filePathTemp);

                //打印续页
                Report_bscc report = new Report_bscc(CurOutHead, CurOutList, i, PageSize, false, FirstPage, Type);
                ExportToPdf(report, filePathTemp); 
            }
            if (lastPageSize != 0)
            {
                index = index + 1;
                fileName = string.Format(fileNameF, index);
                filePathTemp = dirPath + fileName;
                filePathArry.Add(filePathTemp);

                //打印最后一页
                Report_bscc report = new Report_bscc(CurOutHead, CurOutList, Page, PageSize, true, FirstPage, Type);
                ExportToPdf(report, filePathTemp);  
            }

            // PDF 合并
            MergerPdf(filePath, filePathArry); 
        }
         
        #endregion

        #region 监管仓
        /// <summary>
        /// 打印监管所有的列表
        /// </summary>
        private void InPrintListJG(List<Customs.Entity.Store_in_listInfo> CurInList, string id, out string filePath)
        {
            var index = 1;
            var dateFormat = DateTime.Now.ToString("yyyyMMdd");
            var rootPath = AppDomain.CurrentDomain.BaseDirectory + "FileTemp";
            var dirPath = rootPath + "/" + dateFormat + "/";
            var fileNameF = "{0}_" + id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
            var fileName = string.Format(fileNameF, index);
            var filePathTemp = dirPath + fileName;
            var filePathArry = new List<string>();
            filePath = dirPath + id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";

            int FirstPage = 5;
            //当小于5时只打印首页
            if (CurInList.Count <= FirstPage)
            {
                Report_ExSup Report = new Report_ExSup(CurInHead, CurInList);
                ExportToPdf(Report, filePath);
                return;
            }
            else
            {
                Report_ExSup Report = new Report_ExSup(CurInHead, CurInList);
                ExportToPdf(Report, filePathTemp);
                filePathArry.Add(filePathTemp);
            }
            //当大于5时打印续页，根据总条数判断需要几个续页
            int PageSize = 10;
            int Page = (CurInList.Count - FirstPage) / PageSize;
            //最后一页有几条
            int lastPageSize = (CurInList.Count - FirstPage) % PageSize;
            for (int i = 0; i < Page; i++)
            {
                index = index + 1;
                fileName = string.Format(fileNameF, index);
                filePathTemp = dirPath + fileName;
                filePathArry.Add(filePathTemp);

                //打印续页
                Report_ExSupEx report = new Report_ExSupEx(CurInHead, CurInList, i, PageSize, false, FirstPage, "OutJG");
                ExportToPdf(report, filePathTemp);
            }
            if (lastPageSize != 0)
            {
                index = index + 1;
                fileName = string.Format(fileNameF, index);
                filePathTemp = dirPath + fileName;
                filePathArry.Add(filePathTemp);

                //打印最后一页
                Report_ExSupEx report = new Report_ExSupEx(CurInHead, CurInList, Page, PageSize, true, FirstPage, "OutJG");
                ExportToPdf(report, filePathTemp);
            }

            // PDF 合并
            MergerPdf(filePath, filePathArry); 
        }

        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <param name="reportClass"></param>
        /// <param name="filePath"></param>
        private void ExportToPdf(XtraReport reportClass, string filePath)
        {
            if (reportClass == null) return;  
            reportClass.ExportToPdf(filePath); 
        } 

        #endregion

        /// <summary>
        /// Pdf 合并
        /// </summary>
        /// <param name="filePath">输出文件路径</param>
        /// <param name="filePathArry">合并文件路径集合</param>
        public void MergerPdf(string filePath, IList<string> filePathArry)
        {
            Stream output = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            PdfSplitterMerger psm = new PdfSplitterMerger(output);
            Project project = new Project();

            foreach (var item in filePathArry)
            {
                ProjectPart pp = new ProjectPart();
                pp.Load(item);
                project.Parts.Add(pp);

                psm.Add(File.OpenRead(pp.path), pp.Pages);
            }
            psm.Finish(); 
        }
    }
}