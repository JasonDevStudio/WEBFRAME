using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Logic.DAL.DBCustoms.Interfaces;
using Library.Criterias.CustomsCriterias;
using System.Data;
using Library.Kernel.DataBaseHelper;
using Library.StringItemDict;

namespace Library.Logic.DAL.DBCustoms.Classes
{
    public class LogicWebproCusreturn : ILogicWebproCusreturn
    {
        #region ILogicWebproCusreturn 成员
        /// <summary>
        /// 反馈信息分页查询
        /// </summary>
        /// <param name="resultMsg"></param>
        /// <param name="recordCount"></param>
        /// <param name="TotalPages"></param>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable QueryWebproCusreturnListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaRetroaction criteria, int pageSize = 10, int pageIndex = 1)
        {
            recordCount = 0;
            TotalPages = 0;
            resultMsg = string.Empty;
            DataSet data = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                //存储过程名称
                string sql = "webpro_cusreturn";
                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "bill_id", ParameterValue = criteria.bill_id, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "client_no", ParameterValue = criteria.client_no, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "cust_bill_id", ParameterValue = criteria.cust_bill_id, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "passed_date", ParameterValue = criteria.passed_date, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "lease_holder", ParameterValue = criteria.lease_holder, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "remark", ParameterValue = criteria.remark, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "pageindex", ParameterValue = pageIndex, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "pagesize", ParameterValue = pageSize, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "RowCount", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "pagecount", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.Int32 });
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
        #endregion
    }
}
