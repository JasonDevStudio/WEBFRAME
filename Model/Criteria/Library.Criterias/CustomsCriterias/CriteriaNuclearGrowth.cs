using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Library.Criterias.CustomsCriterias
{
    /// <summary>
    /// Created by：cz，2014-5-21，核增查询条件类
    /// </summary>
    public class CriteriaNuclearGrowth
    {
        /// <summary>
        /// 货物类型实际值
        /// </summary>
        public string CargoType { get; set; }
        /// <summary>
        /// 货物类型显示值
        /// </summary>
        public string CargoTypeTest { get; set; }
        public IEnumerable<SelectListItem> CargoTypeList { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        public IEnumerable<SelectListItem> CustomerNameList { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 入仓方式
        /// </summary>
        public string WarehousingApproach { get; set; }
        public IEnumerable<SelectListItem> WarehousingApproachList { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 报关单号
        /// </summary>
        public string NoDeclaration { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public string ApprovalStatus { get; set; }
        public IEnumerable<SelectListItem> ApprovalStatusList { get; set; }
        /// <summary>
        /// 入仓开始时间
        /// </summary>
        public string WarehousingStartTime { get; set; }
        /// <summary>
        /// 入仓结束时间
        /// </summary>
        public string WarehousingEndTime { get; set; }
        /// <summary>
        /// 海关编号
        /// </summary>
        public string CustomsCode { get; set; }
        /// <summary>
        /// 锁定状态
        /// </summary>
        public string LockStatus { get; set; }
        public IEnumerable<SelectListItem> LockStatusList { get; set; }
        /// <summary>
        /// 贸易方式
        /// </summary>
        public string Trade { get; set; }
        public IEnumerable<SelectListItem> TradeList { get; set; }
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string CustomerOrderNumber{get;set;}
        /// <summary>
        /// 核增编号
        /// </summary>
        public string NuclearGrowthNumber { get; set; }


    }
}
