using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Library.Criterias.CustomsCriterias
{
    /// <summary>
    /// Created by：lgl，2014-5-29，海关反馈信息查询
    /// </summary>
    public class CriteriaRetroaction
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string bill_id { get; set; }
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string client_no { get; set; }
        /// <summary>
        /// 核增/扣编号
        /// </summary>
        public string cust_bill_id { get; set; }
        /// <summary>
        /// 海关批准时间
        /// </summary>
        public string passed_date { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string lease_holder { get; set; }
        public IEnumerable<SelectListItem> CustomerNameList { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
