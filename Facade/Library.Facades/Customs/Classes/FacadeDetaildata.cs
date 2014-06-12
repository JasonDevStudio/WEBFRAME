using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data;
using Library.Facades.Customs.Interfaces;
using Library.Logic.DAL.DBCustoms.Interfaces;
using Library.Logic.DAL.DBCustoms.Classes;
using Library.Criterias.CustomsCriterias;
using Library.Models.CustomsModels;
using System.Data.Common;

namespace Library.Facades.Customs.Classes
{
    public class FacadeDetaildata : IFacadeDetaildata
    {
        public DataSet QueryDetaildataListPager(out string resultMsg, out decimal recordCount, CriteriaDetaildata criteria, int pageSize = 10, int pageIndex = 1)
        {
            ILogicDetaildata logicData = new LogicDetaildata();
            var data = logicData.QueryDetaildataListPager(out resultMsg, out recordCount, criteria, pageSize, pageIndex);
            return data;
        }

        public ModelDetaildata DetaildataDetail(out string resultMsg, string djbm, int spxh)
        {
            throw new NotImplementedException();
        }

        public int DetaildataInsertUpdate(out string resultMsg, ModelDetaildata detaildata, DbTransaction tran = null)
        {
            throw new NotImplementedException();
        }

        public int DetaildataUpdateStatus(out string resultMsg, string djbm, int spxh, DbTransaction tran = null)
        {
            throw new NotImplementedException();
        }

        public int DetaildataDelete(out string resultMsg, string djbm, int spxh, DbTransaction tran = null)
        {
            throw new NotImplementedException();
        }
    }
}
