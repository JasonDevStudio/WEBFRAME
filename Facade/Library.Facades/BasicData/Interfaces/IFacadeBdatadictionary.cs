using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Library.StringItemDict;
namespace Library.Facades.BasicData.Interfaces
{
    public interface IFacadeBDatadictionary
    {
        /// <summary>
        /// 贸易方式下拉数据,仓单状态下拉数据
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        DataTable GetDatadictionaryList(_Dictionary dictionary);

        /// <summary>
        /// 获取客户下拉
        /// </summary>
        /// <param name="cus_no"></param>
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
        /// 
        /// </summary>
        /// <param name="pccode"></param>
        /// <param name="ActualValue"></param>
        /// <returns></returns>
        string GetCcodesDisplayName(_Pccode pccode, string ActualValue);

        string GetCcompanyDisplayName(string comp_no);
    }
}
