using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.EBooks
{
    /// <summary>
    /// Created by：cz，2014-5-21，核增查询
    /// </summary>
    public class NuclearGrowthListModel
    {
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string client_no { get; set; }
        /// <summary>
        /// 核增编号
        /// </summary>
        public string cust_bill_id { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 海关确认时间
        /// </summary>
        public DateTime passed_date { get; set; }
        /// <summary>
        /// 核增日期
        /// </summary>
        public DateTime in_date { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        public DateTime app_date { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string car_num { get; set; }
        /// <summary>
        /// 出口国别
        /// </summary>
        public string trade_coun { get; set; }
        /// <summary>
        /// 总毛重
        /// </summary>
        public decimal gross_wt { get; set; }
        /// <summary>
        /// 总净重
        /// </summary>
        public decimal net_wt { get; set; }
        /// <summary>
        /// 总价值
        /// </summary>
        public decimal all_value { get; set; }
        /// <summary>
        /// 总件数
        /// </summary>
        public decimal pkgs_num { get; set; }
        /// <summary>
        /// 报关单号
        /// </summary>
        public string refer_doc { get; set; }
        /// <summary>
        /// 贸易方式
        /// </summary>
        public string trade_mode { get; set; }
        /// <summary>
        /// 查验状态
        /// </summary>
        public string checkstatues { get; set; }
        /// <summary>
        /// 取样状态
        /// </summary>
        public string samplestatues { get; set; }
        /// <summary>
        /// 剪封状态
        /// </summary>
        public string sealcutting { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public decimal is_locked { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string lease_holder { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string bill_id { get; set; }

        /// <summary>
        /// 货物类型
        /// </summary>
        public string lading_type { get; set; }
    }
}