﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Facades.Customs.Interfaces
{
    public interface IFacadePrepareInhead
    {
        bool IsExist(string UserNum, string ClientOrdersNum);
    }
}
