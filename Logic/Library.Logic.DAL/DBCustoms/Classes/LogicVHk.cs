using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Logic.DAL.DBCustoms.Interfaces;
using System.Data;
using Library.StringItemDict;
using Library.Kernel.DataBaseHelper;

namespace Library.Logic.DAL.DBCustoms.Classes
{

    public class LogicVHk : ILogicVHk
    {
        #region ILogicVHk 成员
        public System.Data.DataTable QueryV_HKListPager(out string resultMsg, out int recordCount, out int TotalPages, Criterias.CustomsCriterias.CriteriaNuclearButton criteria, int pageSize = 10, int pageIndex = 1)
        {
            recordCount = 0;
            TotalPages = 0;
            resultMsg = string.Empty;
            DataSet data = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                //存储过程名称
                string sql = "usp_v_hk_select_pager";
                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "CargoTypeTest", ParameterValue = criteria.CargoTypeTest, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "CustomerName", ParameterValue = criteria.CustomerName, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "OrderNumber", ParameterValue = criteria.OrderNumber, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "WayOut", ParameterValue = criteria.WayOut, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "PlateNum", ParameterValue = criteria.PlateNum, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "NoDeclaration", ParameterValue = criteria.NoDeclaration, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "ApprovalStatus", ParameterValue = criteria.ApprovalStatus, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "WayOutStartTime", ParameterValue = criteria.WayOutStartTime, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "WayOutEndTime", ParameterValue = criteria.WayOutEndTime, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "CustomsCode", ParameterValue = criteria.CustomsCode, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "CustomerOrderNumber", ParameterValue = criteria.CustomerOrderNumber, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "NuclearButtonNumber", ParameterValue = criteria.NuclearButtonNumber, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "ContainerNumber", ParameterValue = criteria.ContainerNumber, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "PagerIndex", ParameterValue = pageIndex, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "PagerSize", ParameterValue = pageSize, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "RowCount", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "TotalPages", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.Int32 });
                //查询执行
                using (data = DBHelper.ExecuteDataSet(sql, isStoredProc: true, parm: parm))
                {
                    foreach (var item in parm)
                    {
                        //获取输出参数值
                        if (item.ParameterName == "RowCount")
                        {
                            int.TryParse(item.ParameterValue.ToString(), out recordCount);
                        }

                        if (item.ParameterName == "TotalPages")
                        {
                            int.TryParse(item.ParameterValue.ToString(), out TotalPages);
                        }
                    }
                }
                if (data != null && data.Tables.Count > 0)
                {
                    dt = data.Tables[0];
                }
            }
            catch (Exception ex)
            {
                resultMsg = string.Format("{0} {1}", BaseDict.ErrorPrefix, ex.ToString());
            }
            return dt;
        }
        public DataTable GetStore_out_headByBid(string bill_id)
        {
            DataTable dt = new DataTable();
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT * FROM dbo.store_out_head ");
            strSqlWhere.AppendFormat(" WHERE bill_id='{0}'", bill_id);
            DataSet ds = new DataSet();
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds != null || ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable GetStore_out_listByBid(string bill_id)
        {
            DataTable dt = new DataTable();
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT * FROM dbo.store_out_list ");
            strSqlWhere.AppendFormat(" WHERE bill_id='{0}'", bill_id);
            DataSet ds = new DataSet();
            ds = DBHelper.ExecuteDataSet(strSqlWhere.ToString());
            if (ds != null || ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        #endregion

    }
}
