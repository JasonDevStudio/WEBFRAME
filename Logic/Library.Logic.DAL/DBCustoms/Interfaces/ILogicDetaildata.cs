using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data.Common;
using System.Data;
using Library.Criterias.CustomsCriterias;
using Library.Models.CustomsModels;

namespace Library.Logic.DAL.DBCustoms.Interfaces
{
    public interface ILogicDetaildata
    {
        /// <summary>
        /// 分页查询 
        /// </summary>
        /// <param name="recordCount">输出参数 数据总数</param>
        /// <param name="criteria">查询条件对象</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <returns>结果集 泛型</returns>
        DataSet QueryDetaildataListPager(out string resultMsg, out decimal recordCount, CriteriaDetaildata criteria, int pageSize = 10, int pageIndex = 1);

        /// <summary>
        ///  查询实体
        /// </summary>
        /// <param name="djbm">ModelDjbm 单据编码</param>
        /// <param name="spxh">ModelSpxh 商品序号</param>
        /// <returns>ModelDetaildata</returns>
        ModelDetaildata DetaildataDetail(out string resultMsg,string djbm ,int spxh );

        /// <summary>
        /// 数据 添加/更新
        /// </summary>
        /// <param name="detaildata">实体</param>
        /// <returns>执行结果</returns>
        int DetaildataInsertUpdate(out string resultMsg,ModelDetaildata detaildata,DbTransaction tran =null);

        /// <summary>
        /// 数据状态 更新
        /// </summary>
        /// <param name="djbm">Djbm 单据编码</param>
        /// <param name="spxh">Spxh 商品序号</param>
        /// <returns>执行结果</returns>
        int DetaildataUpdateStatus(out string resultMsg,string djbm ,int spxh ,DbTransaction tran=null);

        /// <summary>
        /// 数据 物理删除
        /// </summary>
        /// <param name="djbm">Djbm 单据编码</param>
        /// <param name="spxh">Spxh 商品序号</param>
        /// <returns>执行结果</returns>
        int DetaildataDelete(out string resultMsg,string djbm ,int spxh ,DbTransaction tran=null);



    }
}
