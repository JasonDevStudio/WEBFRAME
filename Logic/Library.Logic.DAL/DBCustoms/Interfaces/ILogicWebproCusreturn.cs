using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library.Criterias.CustomsCriterias;

namespace Library.Logic.DAL.DBCustoms.Interfaces
{
    public interface ILogicWebproCusreturn
    {
        /// <summary>
        /// 反馈信息分页查询
        /// </summary>
        /// <param name="resultMsg"></param>
        /// <param name="recordCount"></param>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        DataTable QueryWebproCusreturnListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaRetroaction criteria, int pageSize = 10, int pageIndex = 1);
    }
}
