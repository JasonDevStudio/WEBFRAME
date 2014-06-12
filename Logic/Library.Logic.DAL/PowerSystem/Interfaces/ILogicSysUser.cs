using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Models.PowerSystemModels;

namespace Library.Logic.DAL.PowerSystem
{
    public interface ILogicSysUser
    {
        /// <summary>
        ///  查询实体
        /// </summary>
        /// <param name="id">ModelId </param>
        /// <returns>ModelSysUser</returns>
        ModelSysUser SysUserDetail(out string resultMsg, string uname);

    }
}
