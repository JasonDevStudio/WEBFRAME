using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library.StringItemDict;

namespace Library.Logic.DAL.DBBasicData.Interfaces
{
    public interface ILogicBDatadictionary
    {
        /// <summary>
        /// 贸易方式下拉数据,仓单状态下拉数据
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="dictionaryNo"></param>
        /// <returns></returns>
        DataTable GetDatadictionaryList(_Dictionary dictionary);

        /// <summary>
        /// 获取客户名称
        /// </summary>
        /// <returns></returns>
        DataTable GetCustommerList(string cus_no, string server_type);
        /// <summary>
        /// 根据编码获取用户名
        /// </summary>
        /// <param name="cus_no"></param>
        /// <returns></returns>
        string GetCustommerName(string cus_no);
        /// <summary>
        /// 获取字典显示名
        /// </summary>
        /// <param name="ActualValue">实际值</param>
        /// <returns></returns>
        string GetDisplayName(_Dictionary dictionary,string ActualValue);
        /// <summary>
        /// 获取表c_codes显示名称
        /// </summary>
        /// <param name="Pccode"></param>
        /// <param name="ActualValue"></param>
        /// <returns></returns>
        string GetCcodesDisplayName(_Pccode Pccode, string ActualValue);
        /// <summary>
        /// 获取表c_company显示名称
        /// </summary>
        string GetCcompanyDisplayName(string comp_no);
    }
}
