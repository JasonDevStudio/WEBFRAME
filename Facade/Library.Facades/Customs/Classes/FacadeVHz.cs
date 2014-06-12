using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Facades.Customs.Interfaces;
using System.Data;
using Library.Criterias.CustomsCriterias;
using Library.Logic.DAL.DBCustoms.Interfaces;
using Library.Logic.DAL.DBCustoms.Classes;

namespace Library.Facades.Customs.Classes
{
    public class FacadeVHz : IFacadeVHz
    {

        private ILogicVHz logicVHz = new LogicVHz();
        #region IFacadeVHz 成员

        /// <summary>
        /// 核增查询
        /// </summary>
        /// <param name="resultMsg"></param>
        /// <param name="recordCount"></param>
        /// <param name="TotalPages"></param>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable QueryV_HZListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaNuclearGrowth criteria, int pageSize = 10, int pageIndex = 1)
        {
            
            var data =this.logicVHz.QueryV_HZListPager(out resultMsg, out recordCount, out TotalPages, criteria, pageSize, pageIndex);
            return data;  
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bill_id"></param>
        /// <param name="in_head"></param>
        /// <param name="in_list"></param>
        public void GetDetailsData(string bill_id,out DataTable in_head,out DataTable in_list)
        {
            in_head = this.logicVHz.GetStore_in_headByBid(bill_id);
            in_list = this.logicVHz.GetStore_in_listByBid(bill_id);
        }
        #endregion
    }
}
