using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library.Criterias.CustomsCriterias;

namespace Library.Facades.Customs.Interfaces
{
    public interface IFacadeVHk
    {
        DataTable QueryV_HKListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaNuclearButton criteria, int pageSize = 10, int pageIndex = 1);

        void GetDetailsData(string bill_id, out DataTable out_head, out DataTable out_list);
    }
}
