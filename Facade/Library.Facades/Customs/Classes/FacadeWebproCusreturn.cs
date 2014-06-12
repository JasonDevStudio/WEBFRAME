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
    public class FacadeWebproCusreturn : IFacadeWebproCusreturn
    {
        private ILogicWebproCusreturn logicWebproCusreturn = new LogicWebproCusreturn();
        #region IFacadeWebproCusreturn 成员
        public DataTable QueryWebproCusreturnListPager(out string resultMsg, out int recordCount, out int TotalPages, CriteriaRetroaction criteria, int pageSize = 10, int pageIndex = 1)
        {
            var data=logicWebproCusreturn.QueryWebproCusreturnListPager(out resultMsg,out recordCount,out TotalPages,criteria,pageSize,pageIndex);
            return data;
        }
        #endregion
    }
}
