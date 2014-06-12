using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.StringItemDict
{
    public enum _Dictionary
    {
        /// <summary>
        /// 流程状态
        /// </summary>
        OverFlowStates = 53,
        /// <summary>
        /// 查验状态
        /// </summary>
        CheckStates = 64,
        /// <summary>
        /// 取样状态
        /// </summary>
        Samplestatues = 66,
        /// <summary>
        /// 施封剪封状态
        /// </summary>
        Sealcutting = 110,
        /// <summary>
        /// 仓单状态
        /// </summary>
        Status = 92,
        /// <summary>
        /// 贸易方式
        /// </summary>
        Trade_mode = 107,
        /// <summary>
        /// 入仓方式
        /// </summary>
        InType = 72,
        /// <summary>
        /// 出仓方式
        /// </summary>
        OutType=74,
        /// <summary>
        /// 货物类型
        /// </summary>
        CargoType=96,
        /// <summary>
        /// 报关业务类型
        /// </summary>
        Ywlx= 77,
        /// <summary>
        /// 汇率信息
        /// </summary>
        ParaExchrate=97,
        /// <summary>
        /// 进出口岸
        /// </summary>
        Port=86,
        /// <summary>
        /// 核增核扣类型
        /// </summary>
        HZKType=108,
        /// <summary>
        /// 单位
        /// </summary>
        CreatStoreUnit=99,
    }
    public enum _Pccode {
        /// <summary>
        /// 征免性质
        /// </summary>
        Exemption=119,
        /// <summary>
        /// 运输方式
        /// </summary>
        Transport=116,
        /// <summary>
        /// 结汇方式
        /// </summary>
        Settlement=125,
        /// <summary>
        /// 运抵/起运国
        /// </summary>
        Arrived=102,
        /// <summary>
        /// 指运/装货港
        /// </summary>
        Refers=100,
        /// <summary>
        /// 成交方式
        /// </summary>
        TransactionMethod=115,
        /// <summary>
        /// 包装种类
        /// </summary>
        Package=133,
        /// <summary>
        /// 境内货源/目的地
        /// </summary>
        Destination=121,
        /// <summary>
        /// 目的/源产地
        /// </summary>
        SourceDestination=102,
        /// <summary>
        /// 征免
        /// </summary>
        ExemptWay=103,
        /// <summary>
        /// 用途
        /// </summary>
        Use=117,
    }
}
