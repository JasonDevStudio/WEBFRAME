using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Logic.DAL.DBBasicData.Interfaces;
using System.Data;
using System.Text;
using Library.StringItemDict;
using Library.Kernel.DataBaseHelper;

namespace Library.Logic.DAL.DBBasicData.Classes
{
    public class LogicBDatadictionary : ILogicBDatadictionary
    {

        #region ILogicBDatadictionary 成员
        /// <summary>
        /// 贸易方式下拉数据,仓单状态下拉数据
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="dictionaryNo"></param>
        /// <returns></returns>
        public DataTable GetDatadictionaryList(_Dictionary dictionary)
        {
            DataTable dt = new DataTable();
            StringBuilder strSqlWhere = new StringBuilder();
            if (dictionary==_Dictionary.Status)
            {
                strSqlWhere.Append(" SELECT  [dictionary_value] as list_no ,[dictionary_name] ");
                strSqlWhere.Append(" FROM [ILIMS_BasicData].[dbo].[b_datadictionary] ");
                strSqlWhere.AppendFormat(" WHERE dictionary_no ={0} ", Enum.Parse(typeof(_Dictionary), dictionary.ToString()).GetHashCode());
                strSqlWhere.Append(" and is_valid=1 ");
            }
            else
            {
                strSqlWhere.Append(" SELECT [list_no] ,[dictionary_name] ");
                strSqlWhere.Append(" FROM [ILIMS_BasicData].[dbo].[b_datadictionary] ");
                strSqlWhere.AppendFormat(" WHERE  dictionary_no={0} ",Enum.Parse(typeof(_Dictionary), dictionary.ToString()).GetHashCode());
                strSqlWhere.Append(" and is_valid=1 ");
            }
            DataSet ds = new DataSet();
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds!=null||ds.Tables.Count>0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 获取客户名称下拉列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustommerList(string cus_no, string server_type)
        {
            DataTable dt = new DataTable();
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT custom_name,custom_code FROM [ILIMS_BasicData].[dbo].[b_custom_info]  ");
            if (cus_no.Equals("0505"))
            {
                if (!string.IsNullOrWhiteSpace(server_type))
                {
                    strSqlWhere.AppendFormat(" WHERE dbo.StrIn('{0}',server_type)=1 ", server_type);
                }
            }
            else
            {
                strSqlWhere.AppendFormat(" WHERE custom_code={0} ", cus_no);
            }
            DataSet ds = new DataSet();
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds != null || ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
           
        }
        /// <summary>
        /// 根据编码获取用户名
        /// </summary>
        /// <param name="cus_no"></param>
        /// <returns></returns>
        public string GetCustommerName(string cus_no)
        {
            string strDispName = string.Empty;
            DataTable dt = new DataTable();
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT custom_name,custom_code FROM [ILIMS_BasicData].[dbo].[b_custom_info]  ");
            strSqlWhere.AppendFormat(" WHERE custom_code={0}", cus_no);

            DataSet ds = new DataSet();
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds != null || ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["custom_name"] != DBNull.Value)
                    {
                        strDispName = row["custom_name"].ToString();
                    }
                }
            }
            return strDispName;
        }
        /// <summary>
        /// 获取状态字典显示值
        /// </summary>
        /// <param name="ActualValue"></param>
        /// <returns></returns>
        public string GetDisplayName(_Dictionary dictionary,string ActualValue)
        {
            string strDispName = string.Empty;
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT * FROM [ILIMS_BasicData].[dbo].[b_datadictionary] ");
            strSqlWhere.Append(" WHERE 1=1 ");
            switch (dictionary)
            {
                case _Dictionary.ParaExchrate:
                    strSqlWhere.AppendFormat(" AND dictionary_no='{0}' ", Enum.Parse(typeof(_Dictionary), dictionary.ToString()).GetHashCode());
                    strSqlWhere.AppendFormat(" AND dictionary_name='{0}'", ActualValue);
                    break;
                default:
                    if (!string.IsNullOrWhiteSpace(dictionary.ToString()))
                    {
                        strSqlWhere.AppendFormat(" AND dictionary_no='{0}' ", Enum.Parse(typeof(_Dictionary), dictionary.ToString()).GetHashCode());
                    }
                    strSqlWhere.AppendFormat(" AND list_no='{0}'", ActualValue);
                    break;
            }
            DataSet ds = new DataSet();
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds!=null&&ds.Tables.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    switch (dictionary)
                    {
                        case _Dictionary.ParaExchrate:
                            if (row["list_no"] != DBNull.Value)
                            {
                                strDispName = row["list_no"].ToString();
                            }
                            break;
                        default:
                            if (row["dictionary_name"] != DBNull.Value)
                            {
                                strDispName = row["dictionary_name"].ToString();
                            }
                            break;
                    }

                }
            }
            return strDispName;
        }

        public string GetCcodesDisplayName(_Pccode Pccode, string ActualValue)
        {
            string strDispName = string.Empty;
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT * FROM [ILIMS_BasicData].[dbo].[c_codes] ");
            strSqlWhere.Append(" WHERE 1=1 ");
            DataSet ds = new DataSet();
            if (!string.IsNullOrWhiteSpace(Pccode.ToString()))
            {
                strSqlWhere.AppendFormat(" AND pccode='{0}' ", Enum.Parse(typeof(_Pccode), Pccode.ToString()).GetHashCode());
            }
            strSqlWhere.AppendFormat(" AND ccode='{0}'", ActualValue);
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["cname"] != DBNull.Value)
                    {
                        strDispName = row["cname"].ToString();
                    }
                }
            }
            return strDispName;
        }

        public string GetCcompanyDisplayName(string comp_no)
        {
            string strDispName = string.Empty;
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT * FROM [ILIMS_BasicData].[dbo].[c_company] ");
            strSqlWhere.Append(" WHERE 1=1 ");
            if (!string.IsNullOrWhiteSpace(comp_no))
            {
                strSqlWhere.AppendFormat(" AND comp_no='{0}' ", comp_no);
            }
            DataSet ds = new DataSet();
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["comp_name"] != DBNull.Value)
                    {
                        strDispName = row["comp_name"].ToString();
                    }
                }
            }
            return strDispName;
        }
        #endregion

    }
}
