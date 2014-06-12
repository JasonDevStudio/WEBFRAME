using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.PowerSystem
{
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { set; get; }

        /// <summary>
        /// 用户编码  UserID
        /// </summary>
        public string strCustomCode { set; get; }
    }
}