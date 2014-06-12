using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Logic.DAL.DBCustoms.Interfaces
{
    public interface ILogicPrepareInHead
    {
        bool IsExist(string UserNum, string ClientOrdersNum);
    }
}
