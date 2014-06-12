using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Facades.Customs.Interfaces;
using Library.Logic.DAL.DBCustoms.Interfaces;
using Library.Logic.DAL.DBCustoms.Classes;
using System.Data;
using Library.Criterias.CustomsCriterias;

namespace Library.Facades.Customs.Classes
{
    public class FacadeVHk : IFacadeVHk
    {
        private ILogicVHk logicVHk = new LogicVHk();
        #region IFacadeVHk 成员
        public DataTable QueryV_HKListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaNuclearButton criteria, int pageSize = 10, int pageIndex = 1)
        {
            return logicVHk.QueryV_HKListPager(out resultMsg, out recordCount, out TotalPages, criteria, pageSize, pageIndex);
        }

        public void GetDetailsData(string bill_id, out DataTable out_head, out DataTable out_list)
        {
            out_head = this.logicVHk.GetStore_out_headByBid(bill_id);
            out_list = this.logicVHk.GetStore_out_listByBid(bill_id);
        }
        #endregion
    }
}
