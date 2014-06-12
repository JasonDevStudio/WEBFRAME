using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.StringItemDict
{
    public class CommonStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public class LockingStatus
        {
            public static readonly StringItem All = new StringItem("", "全部");
            /// <summary>
            /// 1 - 已锁
            /// </summary>
            public static readonly StringItem Locked = new StringItem("1", "锁定");
            /// <summary>
            /// 0 - 未锁
            /// </summary>
            public static readonly StringItem Unlocked = new StringItem("0", "未锁定");
        }
        /// <summary>
        /// 
        /// </summary>
        public class DrawbackStatus
        {
            public static readonly StringItem Be = new StringItem("0", "否");

            public static readonly StringItem No = new StringItem("1", "是");
        }


    }
}
