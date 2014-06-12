using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library.Criterias.CustomsCriterias;

namespace Library.Logic.DAL.DBCustoms.Interfaces
{
    public interface ILogicVHk
    {
        /// <summary>
        /// 核增分页查询
        /// </summary>
        /// <param name="resultMsg"></param>
        /// <param name="recordCount"></param>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        DataTable QueryV_HKListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaNuclearButton criteria, int pageSize = 10, int pageIndex = 1);
        /// <summary>
        /// 核增详情主表信息
        /// </summary>
        /// <param name="bill_id"></param>
        /// <returns></returns>
        DataTable GetStore_out_headByBid(string bill_id);
        /// <summary>
        /// 核增详情从表信息
        /// </summary>
        /// <param name="bill_id"></param>
        /// <returns></returns>
        DataTable GetStore_out_listByBid(string bill_id);
    }
}
