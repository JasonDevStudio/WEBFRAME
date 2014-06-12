using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Facades.BasicData.Interfaces;
using Library.StringItemDict;
using System.Data;
using Library.Logic.DAL.DBBasicData.Interfaces;
using Library.Logic.DAL.DBBasicData.Classes;

namespace Library.Facades.BasicData.Classes
{
    public class FacadeBdatadictionary : IFacadeBDatadictionary
    {
        private ILogicBDatadictionary LogicDal = new LogicBDatadictionary();
        #region IFacadeBDatadictionary 成员

        /// <summary>
        /// 贸易方式下拉数据,仓单状态下拉数据
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public DataTable GetDatadictionaryList(_Dictionary dictionary)
        {
            
            var data=this.LogicDal.GetDatadictionaryList(dictionary);
            return data;
        }

        /// <summary>
        /// 获取客户下拉
        /// </summary>
        /// <param name="cus_no"></param>
        /// <returns></returns>
        public DataTable GetCustommerList(string cus_no, string server_type)
        {
            var data = this.LogicDal.GetCustommerList(cus_no, server_type);
            return data;
        }
        /// <summary>
        /// 根据编码获取用户名
        /// </summary>
        /// <param name="cus_no"></param>
        /// <returns></returns>
        public string GetCustommerName(string cus_no)
        {
            return this.LogicDal.GetCustommerName(cus_no);
        }
        /// <summary>
        /// 获取显示值
        /// </summary>
        /// <param name="ActualValue"></param>
        /// <returns></returns>
        public string GetDisplayName(_Dictionary dictionary,string ActualValue)
        {
            return this.LogicDal.GetDisplayName(dictionary,ActualValue);
        }
        public string GetCcodesDisplayName(_Pccode pccode, string ActualValue)
        {
            return this.LogicDal.GetCcodesDisplayName(pccode, ActualValue);
        }
        public string GetCcompanyDisplayName(string comp_no)
        {
            return this.LogicDal.GetCcompanyDisplayName(comp_no);
        }
        #endregion
    }
}
