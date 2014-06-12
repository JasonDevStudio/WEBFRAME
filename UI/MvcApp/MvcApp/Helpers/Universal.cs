using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Facades.BasicData.Interfaces;
using Library.Facades.BasicData.Classes;
using System.Data;
using Library.StringItemDict;

namespace MvcApp.Helpers
{
    public static class Universal
    {
        private static IFacadeBDatadictionary facade = new FacadeBdatadictionary();
        /// <summary>
        /// 页面状态转换方法
        /// </summary>
        /// <param name="Value">实际值</param>
        /// <param name="DispalyName">需转换字段名</param>
        /// <returns></returns>
        public static string GetStatusName(_Dictionary dictionary,string ActualValue)
        {
            
            string strDisplay = string.Empty;
            strDisplay = facade.GetDisplayName(dictionary, ActualValue);
            return strDisplay;
        }
        public static string GetCcodesDisplayName(_Pccode pccode, string ActualValue)
        {
            string strDisplay = string.Empty;
            strDisplay = facade.GetCcodesDisplayName(pccode, ActualValue);
            return strDisplay;
        }
        public static string GetCcompanyDisplayName(string comp_no)
        {
            string strDisplay = string.Empty;
            strDisplay = facade.GetCcompanyDisplayName(comp_no);
            return strDisplay;
        }
        /// <summary>
        /// 审批状态
        /// </summary>
        public static string GetApprovalStatusName(string ActualValue)
        {
            string strDisplay = string.Empty;
            DataTable data = facade.GetDatadictionaryList(_Dictionary.Status);
            if (data!=null&&data.Rows.Count>0)
            {
                DataRow[] row = data.Select(" list_no="+ActualValue);
                strDisplay = row[0]["dictionary_name"].ToString();
            }
            return strDisplay;
        }
        /// <summary>
        /// 获取客户名称
        /// </summary>
        /// <returns></returns>
        public static string GetCustommerName(string cus_no)
        {
            string strDisplay = string.Empty;
            strDisplay = facade.GetCustommerName(cus_no);
            return strDisplay;
        }
    }
}