using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library.Criterias.CustomsCriterias;

namespace Library.Facades.Customs.Interfaces
{
    /// <summary>
    /// 核增查询
    /// </summary>
    public interface IFacadeVHz
    {
        DataTable QueryV_HZListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaNuclearGrowth criteria, int pageSize = 10, int pageIndex = 1);

        void GetDetailsData(string bill_id,out DataTable in_head,out DataTable in_list);
    }
}
