using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Facades.Customs.Interfaces;
using Library.Logic.DAL.DBCustoms.Interfaces;
using Library.Logic.DAL.DBCustoms.Classes;

namespace Library.Facades.Customs.Classes
{
    public class FacadePrepareInhead : IFacadePrepareInhead
    {
        private ILogicPrepareInHead Logice = new LogicPrepareInHead();
        #region IFacadePrepareInhead 成员

        public bool IsExist(string UserNum, string ClientOrdersNum)
        {
            return Logice.IsExist(UserNum, ClientOrdersNum);
        }

        #endregion
    }
}
