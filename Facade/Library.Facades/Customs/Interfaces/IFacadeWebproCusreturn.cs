using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library.Criterias.CustomsCriterias;

namespace Library.Facades.Customs.Interfaces
{
    public interface IFacadeWebproCusreturn
    {
        DataTable QueryWebproCusreturnListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaRetroaction criteria, int pageSize = 10, int pageIndex = 1);
    }
}
