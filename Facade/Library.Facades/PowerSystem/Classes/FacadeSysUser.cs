using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using Library.Models.PowerSystemModels;
using Library.Common;
using Library.Logic.DAL.PowerSystem;

namespace Library.Facades.PowerSystem
{
    public class FacadeSysUser : IFacadeSysUser
    { 
        public string VerifyUser(string userName, string userPassword, string sessionID, out string userId, out string userFullName,out string resultMsg)
        {
            resultMsg = string.Empty;
            userId = string.Empty;
            userFullName = string.Empty;
            var key = string.Empty;
            if ((sessionID == null) || (sessionID == string.Empty))
            {
                return string.Empty;
            }

            userPassword = string.IsNullOrWhiteSpace(userPassword) ? string.Empty : userPassword;
            userName = string.IsNullOrWhiteSpace(userName) ? string.Empty : userName;
            ILogicSysUser logic = new LogicSysUser(); 
            ModelSysUser userByName = logic.SysUserDetail(out resultMsg, userName); ;
            if ((userByName != null) && !string.IsNullOrWhiteSpace(userByName.Upassword) && !string.IsNullOrWhiteSpace(userByName.Uname) && userByName.Ustate != 2)
            {
                userPassword = Common.EncryptDecrypt.ComputeHash(userPassword, userName.ToLower());
                if (userPassword.Trim() == userByName.Upassword.Trim())
                {
                    userId = userByName.Userid;
                    userFullName = userByName.Fullname;
                    key = EncryptDecrypt.EncryptStr(userName + Convert.ToString(Convert.ToChar(1)) + userPassword, sessionID);
                }
            }

            return key;
        }
    }
}
