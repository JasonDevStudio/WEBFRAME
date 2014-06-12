using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Facades.BasicData.Interfaces;
using Library.Facades.BasicData.Classes;
using Library.StringItemDict;
using Library.Common;

namespace MvcApp.Helpers
{
    public static class DropDownListFor
    {
        #region 业务相关
        /// <summary>
        /// 货物类型
        /// </summary>
        /// <param name="selectedValue"></param>
        /// <param name="isAllowedEmpty"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetCargoTypeSelect(string selectedValue = null, bool isAllowedEmpty = false, string spliter = null)
        {
            IEnumerable<SelectListItem> result = null;
            IFacadeBDatadictionary IFacade = new FacadeBdatadictionary();
            var data = IFacade.GetDatadictionaryList(_Dictionary.CargoType);
            var valueFieldName = "list_no";
            var textFieldName = "dictionary_name";
            result = DropDownListHelper.GenerateItems(data, valueFieldName, textFieldName, selectedValue, isAllowedEmpty, spliter);
            return result;
        }
        /// <summary>
        /// 贸易方式下拉列表
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="selectedValue"></param>
        /// <param name="isAllowedEmpty"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetTradeSelect(string selectedValue = null, bool isAllowedEmpty = false, string spliter = null)
        {
            IEnumerable<SelectListItem> result = null;
            IFacadeBDatadictionary IFacade = new FacadeBdatadictionary();
            var data = IFacade.GetDatadictionaryList(_Dictionary.Trade_mode);
            var valueFieldName = "list_no";
            var textFieldName = "dictionary_name";
            result = DropDownListHelper.GenerateItems(data, valueFieldName, textFieldName, selectedValue, isAllowedEmpty, spliter);
            return result;
        }
        /// <summary>
        /// 审批状态
        /// </summary>
        /// <param name="selectedValue"></param>
        /// <param name="isAllowedEmpty"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetApprovalStatusSelect(string selectedValue = null, bool isAllowedEmpty = false, string spliter = null)
        {
            IEnumerable<SelectListItem> result = null;
            IFacadeBDatadictionary IFacade = new FacadeBdatadictionary();
            var data = IFacade.GetDatadictionaryList(_Dictionary.Status);
            var valueFieldName = "list_no";
            var textFieldName = "dictionary_name";
            result = DropDownListHelper.GenerateItems(data, valueFieldName, textFieldName, selectedValue, isAllowedEmpty, spliter);
            return result;
        }
        /// <summary>
        /// 入仓方式
        /// </summary>
        /// <param name="selectedValue"></param>
        /// <param name="isAllowedEmpty"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetWarehousingApproachSelect(string selectedValue = null, bool isAllowedEmpty = false, string spliter = null)
        {
            IEnumerable<SelectListItem> result = null;
            IFacadeBDatadictionary IFacade = new FacadeBdatadictionary();
            var data = IFacade.GetDatadictionaryList(_Dictionary.InType);
            var valueFieldName = "list_no";
            var textFieldName = "dictionary_name";
            result = DropDownListHelper.GenerateItems(data, valueFieldName, textFieldName, selectedValue, isAllowedEmpty, spliter);
            return result;
        }
        /// <summary>
        /// 出仓方式
        /// </summary>
        /// <param name="selectedValue"></param>
        /// <param name="isAllowedEmpty"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetWayOutSelect(string selectedValue = null, bool isAllowedEmpty = false, string spliter = null)
        {
            IEnumerable<SelectListItem> result = null;
            IFacadeBDatadictionary IFacade = new FacadeBdatadictionary();
            var data = IFacade.GetDatadictionaryList(_Dictionary.OutType);
            var valueFieldName = "list_no";
            var textFieldName = "dictionary_name";
            result = DropDownListHelper.GenerateItems(data, valueFieldName, textFieldName, selectedValue, isAllowedEmpty, spliter);
            return result;
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// <param name="cus_no"></param>
        /// <param name="selectedValue"></param>
        /// <param name="isAllowedEmpty"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetCustomerNameSelect(string cus_no, string server_type, string selectedValue = null, bool isAllowedEmpty = false, string spliter = null)
        {
            IEnumerable<SelectListItem> result = null;
            IFacadeBDatadictionary IFacade = new FacadeBdatadictionary();
            var data = IFacade.GetCustommerList(cus_no, server_type);
            var valueFieldName = "custom_code";
            var textFieldName = "custom_name";
            result = DropDownListHelper.GenerateItems(data, valueFieldName, textFieldName, selectedValue, isAllowedEmpty, spliter);
            return result;
        }
        #endregion
        #region 常太下拉项
        /// <summary>
        /// 锁定状态
        /// </summary>
        /// <param name="selectedValue"></param>
        /// <param name="isAllowedEmpty"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetLockingStatusSelect(string selectedValue = null, bool isAllowedEmpty = false)
        {
            return DropDownListHelper.GenerateItemsFromStringItems("CommonStatus+LockingStatus", selectedValue, isAllowedEmpty);
        }
        #endregion
    }
}