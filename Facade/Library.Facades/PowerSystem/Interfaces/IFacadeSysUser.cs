using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Facades.PowerSystem
{
    public interface IFacadeSysUser
    {
        //登录验证
        string VerifyUser(string userName, string userPassword, string sessionID, out string userId, out string userFullName, out string resultMsg);
    }
}
