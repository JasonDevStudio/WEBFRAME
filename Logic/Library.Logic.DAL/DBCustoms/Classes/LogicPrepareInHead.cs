using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Logic.DAL.DBCustoms.Interfaces;
using Library.Kernel.DataBaseHelper;

namespace Library.Logic.DAL.DBCustoms.Classes
{
    public class LogicPrepareInHead : ILogicPrepareInHead
    {

        #region ILogicPrepareInHead 成员

        public bool IsExist(string UserNum, string ClientOrdersNum)
        {
            bool bl = false;
            StringBuilder strSqlWhere = new StringBuilder();
            strSqlWhere.Append(" SELECT COUNT(*) FROM dbo.prepare_in_head ");
            strSqlWhere.AppendFormat(" WHERE lease_holder='{0}' AND client_no='{1}' ", UserNum, ClientOrdersNum);
            var result =DBHelper.ExecuteScalar(strSqlWhere.ToString());
            if (Convert.ToInt32(result)>0)
            {
                bl = true;
            }
            return bl;
        }

        #endregion
    }
}
