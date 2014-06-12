using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DevExpress.XtraReports.UI;
using System.Text;
using System.Runtime.InteropServices;

namespace MvcApp.Report.Common
{
    public class WareCommon
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);

        /// <summary>
        /// 显示打印预览
        /// </summary>
        /// <param name="reportClass">报表类</param>
        /// <param name="data">填充数据</param>
        /// <param name="tableName">填充的数据表名称</param>
        public static void ShowPreview(XtraReport reportClass, DataSet data, string tableName)
        {
            if (reportClass == null) return;
            //如果包含填充数据则将数据绑定到报表
            reportClass.DataSource = data;
            reportClass.DataMember = tableName;
            reportClass.PrinterName = GetDefaultPrinter();
            reportClass.PrintingSystem.ShowMarginsWarning = false;

            //#region 直接打印
            //for (int i = 0; i < 2; i++)
            //{
            //    reportClass.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            //    reportClass.Print();
            //}
            //#endregion
            reportClass.ShowPreviewDialog();
        }

        /// <summary>
        /// 获取系统的默认打印机 //modified by cuijt 2010-12-01
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPrinter()
        {
            const int ERROR_FILE_NOT_FOUND = 2;

            const int ERROR_INSUFFICIENT_BUFFER = 122;

            int pcchBuffer = 0;

            if (GetDefaultPrinter(null, ref pcchBuffer))
            {
                return null;
            }

            int lastWin32Error = Marshal.GetLastWin32Error();

            if (lastWin32Error == ERROR_INSUFFICIENT_BUFFER)
            {
                StringBuilder pszBuffer = new StringBuilder(pcchBuffer);
                if (GetDefaultPrinter(pszBuffer, ref pcchBuffer))
                {
                    return pszBuffer.ToString();
                }

                lastWin32Error = Marshal.GetLastWin32Error();
            }
            if (lastWin32Error == ERROR_FILE_NOT_FOUND)
            {
                return null;
            }

            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
        }

        #region 通过编码获取报关单类型
        public static string GetDecCodeName(string Dec_no)
        {
            BasicData.Entity.B_datadictionaryInfo info = BasicData.BLL.BLLFactory<BasicData.BLL.B_datadictionary>.
                Instance.FindSingle(" dictionary_no='77' and list_no='" + Dec_no + "'");
            if (info != null)
            {
                return info.Dictionary_name;
            }
            return Dec_no;
        }

        #endregion

        #region 根据编码获取名称
        /// <summary>
        /// 根据编码获取名称
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public static string GetCompanyName(string strCode)
        {
            string str = "";

            DataTable tab = BasicData.BLL.BLLFactory<BasicData.BLL.C_company>.Instance.GetSpbCompany(strCode);
            if (tab != null && tab.Rows.Count > 0)
            {
                str = tab.Rows[0]["COMP_NAME"].ToString();
            }
            return str;
        }
        #endregion
    }
}