using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using Library.Models.PowerSystemModels;
using System.Data;
using Library.Kernel.DataBaseHelper;
using Library.StringItemDict;

namespace Library.Logic.DAL.PowerSystem
{
    public class LogicSysUser : ILogicSysUser
    {

        #region 私有函数
        /// <summary>
        /// Model 赋值 IDataReader
        /// </summary>
        private IList<ModelSysUser> GetModel(IDataReader dr)
        {
            var modelList = new List<ModelSysUser>();

            while (dr.Read())
            {
                var model = new ModelSysUser();
                model.Id = dr["id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["id"]);
                model.Userid = dr["userid"] == DBNull.Value ? string.Empty : dr["userid"].ToString();
                model.Uname = dr["uname"] == DBNull.Value ? string.Empty : dr["uname"].ToString();
                model.OrderAsc = dr["order_asc"] == DBNull.Value ? 0 : Convert.ToInt32(dr["order_asc"]);
                model.Upassword = dr["upassword"] == DBNull.Value ? string.Empty : dr["upassword"].ToString();
                model.Fullname = dr["fullname"] == DBNull.Value ? string.Empty : dr["fullname"].ToString();
                model.Ismanage = dr["ismanage"] == DBNull.Value ? false : Convert.ToBoolean(dr["ismanage"]);
                model.Ustate = dr["ustate"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ustate"]);
                model.Email = dr["email"] == DBNull.Value ? string.Empty : dr["email"].ToString();
                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary>
        /// Model 赋值 DataSet
        /// </summary>
        private IList<ModelSysUser> GetModel(DataSet ds)
        {
            var modelList = (from DataRow dr in ds.Tables[0].Rows
                             select new ModelSysUser()
                             {
                                 Id = dr["id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["id"]),
                                 Userid = dr["userid"] == DBNull.Value ? string.Empty : dr["userid"].ToString(),
                                 Uname = dr["uname"] == DBNull.Value ? string.Empty : dr["uname"].ToString(),
                                 OrderAsc = dr["order_asc"] == DBNull.Value ? 0 : Convert.ToInt32(dr["order_asc"]),
                                 Upassword = dr["upassword"] == DBNull.Value ? string.Empty : dr["upassword"].ToString(),
                                 Fullname = dr["fullname"] == DBNull.Value ? string.Empty : dr["fullname"].ToString(),
                                 Ismanage = dr["ismanage"] == DBNull.Value ? false : Convert.ToBoolean(dr["ismanage"]),
                                 Ustate = dr["ustate"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ustate"]),
                                 Email = dr["email"] == DBNull.Value ? string.Empty : dr["email"].ToString(),
                             }).ToList();
            return modelList;
        }

        #endregion
        /// <summary>
        ///  查询实体
        /// </summary>
        /// <param name="id">ModelId </param>
        /// <returns>ModelSysUser</returns>
        public ModelSysUser SysUserDetail(out string resultMsg, string uname)
        {
            resultMsg = string.Empty;
            var model = new ModelSysUser();
            try
            {
                //存储过程名称
                string sql = "SELECT * FROM [PowerSystem].[dbo].[sys_user] WHERE uname  = @uname ";

                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "uname", ParameterValue = uname, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });

                //查询执行
                using (IDataReader dr = DBHelper.ExecuteReader(sql, false, parm))
                {
                    IList<ModelSysUser> list = GetModel(dr);
                    model = list.First();
                }
            }
            catch (Exception ex)
            {
                resultMsg = string.Format("{0} {1}", BaseDict.ErrorPrefix, ex.ToString());
            }
            return model;
        }

    }

}
