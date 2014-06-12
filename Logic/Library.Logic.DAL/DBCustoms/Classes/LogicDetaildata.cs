using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using Library.Kernel.DataBaseHelper;
using Library.StringItemDict; 
using System.Data.Common;
using Library.Logic.DAL.DBCustoms.Interfaces;
using Library.Models.CustomsModels;
using Library.Criterias.CustomsCriterias; 

namespace Library.Logic.DAL.DBCustoms.Classes
{
    public class LogicDetaildata : ILogicDetaildata
    {
        #region 私有函数
        /// <summary>
        /// Model 赋值 IDataReader
        /// </summary>
        private IList<ModelDetaildata> GetModel(IDataReader dr)
        {
            var modelList = new List<ModelDetaildata>();

            while (dr.Read())
            {
                var model = new ModelDetaildata();
                model.Djbm = dr["djbm"] == DBNull.Value ? string.Empty : dr["djbm"].ToString();
                model.Spxh = dr["spxh"] == DBNull.Value ? 0 : Convert.ToInt32(dr["spxh"]);
                model.Baxh = dr["baxh"] == DBNull.Value ? string.Empty : dr["baxh"].ToString();
                model.Spbh = dr["spbh"] == DBNull.Value ? string.Empty : dr["spbh"].ToString();
                model.Fjbh = dr["fjbh"] == DBNull.Value ? string.Empty : dr["fjbh"].ToString();
                model.Spmc = dr["spmc"] == DBNull.Value ? string.Empty : dr["spmc"].ToString();
                model.Ggxh = dr["ggxh"] == DBNull.Value ? string.Empty : dr["ggxh"].ToString();
                model.Cjsl = dr["cjsl"] == DBNull.Value ? null : (Object)dr["cjsl"];
                model.Cjdw = dr["cjdw"] == DBNull.Value ? string.Empty : dr["cjdw"].ToString();
                model.Cjdj = dr["cjdj"] == DBNull.Value ? null : (Object)dr["cjdj"];
                model.Cjzj = dr["cjzj"] == DBNull.Value ? null : (Object)dr["cjzj"];
                model.Bizhi = dr["bizhi"] == DBNull.Value ? string.Empty : dr["bizhi"].ToString();
                model.Fdsl = dr["fdsl"] == DBNull.Value ? null : (Object)dr["fdsl"];
                model.Fddw = dr["fddw"] == DBNull.Value ? string.Empty : dr["fddw"].ToString();
                model.Bbh = dr["bbh"] == DBNull.Value ? string.Empty : dr["bbh"].ToString();
                model.Huoh = dr["huoh"] == DBNull.Value ? string.Empty : dr["huoh"].ToString();
                model.Sccj = dr["sccj"] == DBNull.Value ? string.Empty : dr["sccj"].ToString();
                model.Desl = dr["desl"] == DBNull.Value ? null : (Object)dr["desl"];
                model.Dedw = dr["dedw"] == DBNull.Value ? string.Empty : dr["dedw"].ToString();
                model.Mdd = dr["mdd"] == DBNull.Value ? string.Empty : dr["mdd"].ToString();
                model.Zm = dr["zm"] == DBNull.Value ? string.Empty : dr["zm"].ToString();
                model.Gjf = dr["gjf"] == DBNull.Value ? null : (Object)dr["gjf"];
                model.Yt = dr["yt"] == DBNull.Value ? string.Empty : dr["yt"].ToString();
                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary>
        /// Model 赋值 DataSet
        /// </summary>
        private IList<ModelDetaildata> GetModel(DataSet ds)
        {
            var modelList = (from DataRow dr in ds.Tables[0].Rows
                             select new ModelDetaildata()
                             {
                                 Djbm = dr["djbm"] == DBNull.Value ? string.Empty : dr["djbm"].ToString(),
                                 Spxh = dr["spxh"] == DBNull.Value ? 0 : Convert.ToInt32(dr["spxh"]),
                                 Baxh = dr["baxh"] == DBNull.Value ? string.Empty : dr["baxh"].ToString(),
                                 Spbh = dr["spbh"] == DBNull.Value ? string.Empty : dr["spbh"].ToString(),
                                 Fjbh = dr["fjbh"] == DBNull.Value ? string.Empty : dr["fjbh"].ToString(),
                                 Spmc = dr["spmc"] == DBNull.Value ? string.Empty : dr["spmc"].ToString(),
                                 Ggxh = dr["ggxh"] == DBNull.Value ? string.Empty : dr["ggxh"].ToString(),
                                 Cjsl = dr["cjsl"] == DBNull.Value ? null : (Object)dr["cjsl"],
                                 Cjdw = dr["cjdw"] == DBNull.Value ? string.Empty : dr["cjdw"].ToString(),
                                 Cjdj = dr["cjdj"] == DBNull.Value ? null : (Object)dr["cjdj"],
                                 Cjzj = dr["cjzj"] == DBNull.Value ? null : (Object)dr["cjzj"],
                                 Bizhi = dr["bizhi"] == DBNull.Value ? string.Empty : dr["bizhi"].ToString(),
                                 Fdsl = dr["fdsl"] == DBNull.Value ? null : (Object)dr["fdsl"],
                                 Fddw = dr["fddw"] == DBNull.Value ? string.Empty : dr["fddw"].ToString(),
                                 Bbh = dr["bbh"] == DBNull.Value ? string.Empty : dr["bbh"].ToString(),
                                 Huoh = dr["huoh"] == DBNull.Value ? string.Empty : dr["huoh"].ToString(),
                                 Sccj = dr["sccj"] == DBNull.Value ? string.Empty : dr["sccj"].ToString(),
                                 Desl = dr["desl"] == DBNull.Value ? null : (Object)dr["desl"],
                                 Dedw = dr["dedw"] == DBNull.Value ? string.Empty : dr["dedw"].ToString(),
                                 Mdd = dr["mdd"] == DBNull.Value ? string.Empty : dr["mdd"].ToString(),
                                 Zm = dr["zm"] == DBNull.Value ? string.Empty : dr["zm"].ToString(),
                                 Gjf = dr["gjf"] == DBNull.Value ? null : (Object)dr["gjf"],
                                 Yt = dr["yt"] == DBNull.Value ? string.Empty : dr["yt"].ToString(),
                             }).ToList();
            return modelList;
        }

        #endregion


        /// <summary>
        /// 分页查询 
        /// </summary>
        /// <param name="recordCount">输出参数 数据总数</param>
        /// <param name="criteria">查询条件对象</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <returns>结果集 泛型</returns>
        public DataSet QueryDetaildataListPager(out string resultMsg, out decimal recordCount, CriteriaDetaildata criteria, int pageSize = 15, int pageIndex = 1)
        {
            recordCount = decimal.Zero;
            resultMsg = string.Empty;
            DataSet data = new DataSet();
            try
            {
                //存储过程名称
                string sql = "USP_DETAILDATA_SELECT_SEARCH_PAGER";

                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "PagerSize", ParameterValue = pageSize, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "PagerIndex", ParameterValue = pageIndex, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "RowCount", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.String });

                //查询执行
                using (data = DBHelper.ExecuteDataSet(sql, isStoredProc: true, parm: parm))
                { 
                    foreach (var item in parm)
                    {
                        //获取输出参数值
                        if (item.ParameterName == "RowCount")
                        {
                            decimal.TryParse(item.ParameterValue.ToString(), out recordCount);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultMsg = string.Format("{0} {1}", BaseDict.ErrorPrefix, ex.ToString());
            }

            return data;
        }


        /// <summary>
        ///  查询实体
        /// </summary>
        /// <param name="djbm">ModelDjbm 单据编码</param>
        /// <param name="spxh">ModelSpxh 商品序号</param>
        /// <returns>ModelDetaildata</returns>
        public ModelDetaildata DetaildataDetail(out string resultMsg, String djbm, Int32 spxh)
        {
            resultMsg = string.Empty;
            var model = new ModelDetaildata();
            try
            {
                //存储过程名称
                string sql = "USP_DETAILDATA_SELECT_DETAIL_BY_DJBM_SPXH";

                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "DJBM", ParameterValue = djbm, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "SPXH", ParameterValue = spxh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });

                //查询执行
                using (IDataReader dr = DBHelper.ExecuteReader(sql, true, parm))
                {
                    IList<ModelDetaildata> list = GetModel(dr);
                    model = list.First();
                }
            }
            catch (Exception ex)
            {
                resultMsg = string.Format("{0} {1}", BaseDict.ErrorPrefix, ex.ToString());
            }
            return model;
        }

        /// <summary>
        /// 数据 添加/更新
        /// </summary>
        /// <param name="detaildata">实体</param>
        /// <returns>执行结果</returns>
        public int DetaildataInsertUpdate(out string resultMsg, ModelDetaildata detaildata, DbTransaction tran = null)
        {
            resultMsg = string.Empty;
            int res = 0;
            try
            {
                //存储过程名称
                string sql = "USP_DETAILDATA_INSERT_UPDATE";
                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "DJBM", ParameterValue = detaildata.Djbm, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "SPXH", ParameterValue = detaildata.Spxh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "BAXH", ParameterValue = detaildata.Baxh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "SPBH", ParameterValue = detaildata.Spbh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "FJBH", ParameterValue = detaildata.Fjbh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "SPMC", ParameterValue = detaildata.Spmc, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "GGXH", ParameterValue = detaildata.Ggxh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "CJSL", ParameterValue = detaildata.Cjsl, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Object });
                parm.Add(new DBParameter() { ParameterName = "CJDW", ParameterValue = detaildata.Cjdw, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "CJDJ", ParameterValue = detaildata.Cjdj, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Object });
                parm.Add(new DBParameter() { ParameterName = "CJZJ", ParameterValue = detaildata.Cjzj, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Object });
                parm.Add(new DBParameter() { ParameterName = "BIZHI", ParameterValue = detaildata.Bizhi, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "FDSL", ParameterValue = detaildata.Fdsl, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Object });
                parm.Add(new DBParameter() { ParameterName = "FDDW", ParameterValue = detaildata.Fddw, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "BBH", ParameterValue = detaildata.Bbh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "HUOH", ParameterValue = detaildata.Huoh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "SCCJ", ParameterValue = detaildata.Sccj, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "DESL", ParameterValue = detaildata.Desl, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Object });
                parm.Add(new DBParameter() { ParameterName = "DEDW", ParameterValue = detaildata.Dedw, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "MDD", ParameterValue = detaildata.Mdd, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "ZM", ParameterValue = detaildata.Zm, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "GJF", ParameterValue = detaildata.Gjf, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Object });
                parm.Add(new DBParameter() { ParameterName = "YT", ParameterValue = detaildata.Yt, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "resultMsg", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.String });

                //新增/更新执行
                res = DBHelper.ExecuteNonQuery(sql, true, parm, tran);
                foreach (var item in parm)
                {
                    //获取输出参数值
                    if (item.ParameterName == "resultMsg")
                    {
                        resultMsg = item.ParameterValue.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                resultMsg = string.Format("{0} {1}", BaseDict.ErrorPrefix, ex.ToString());
            }
            return res;
        }

        /// <summary>
        /// 数据状态 更新
        /// </summary>
        /// <param name="djbm">Djbm 单据编码</param>
        /// <param name="spxh">Spxh 商品序号</param>
        /// <returns>执行结果</returns>
        public int DetaildataUpdateStatus(out string resultMsg, String djbm, Int32 spxh, DbTransaction tran = null)
        {
            resultMsg = string.Empty;
            int res = 0;
            try
            {
                //存储过程名称
                string sql = "USP_detaildata_UPDATE_STATUS";
                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "DJBM", ParameterValue = djbm, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "SPXH", ParameterValue = spxh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "resultMsg", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.String });
                //更新执行
                res = DBHelper.ExecuteNonQuery(sql, true, parm, tran);
                foreach (var item in parm)
                {
                    //获取输出参数值
                    if (item.ParameterName == "resultMsg")
                    {
                        resultMsg = item.ParameterValue.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                resultMsg = string.Format("{0} {1}", BaseDict.ErrorPrefix, ex.ToString());
            }
            return res;
        }

        /// <summary>
        /// 数据 删除
        /// </summary>
        /// <param name="djbm">Djbm 单据编码</param>
        /// <param name="spxh">Spxh 商品序号</param>
        /// <returns>执行结果</returns>
        public int DetaildataDelete(out string resultMsg, String djbm, Int32 spxh, DbTransaction tran = null)
        {
            resultMsg = string.Empty;
            int res = 0;
            try
            {
                //存储过程名称
                string sql = " USP_DETAILDATA_DELETE ";

                //参数添加
                IList<DBParameter> parm = new List<DBParameter>();
                parm.Add(new DBParameter() { ParameterName = "DJBM", ParameterValue = djbm, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.String });
                parm.Add(new DBParameter() { ParameterName = "SPXH", ParameterValue = spxh, ParameterInOut = BaseDict.ParmIn, ParameterType = DbType.Int32 });
                parm.Add(new DBParameter() { ParameterName = "resultMsg", ParameterInOut = BaseDict.ParmOut, ParameterType = DbType.String });
                //更新执行
                res = DBHelper.ExecuteNonQuery(sql, true, parm, tran);
                foreach (var item in parm)
                {
                    //获取输出参数值
                    if (item.ParameterName == "resultMsg")
                    {
                        resultMsg = item.ParameterValue.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                resultMsg = string.Format("{0} {1}", BaseDict.ErrorPrefix, ex.ToString());
            }
            return res;
        }



    }
}
