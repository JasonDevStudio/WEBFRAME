using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.EBooks
{
    /// <summary>
    /// Created by：cz，2014-5-29，核增明细
    /// </summary>
    public class NuclearGrowthEditModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string bill_id { get; set; }
        /// <summary>
        /// 通关状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 核增日期
        /// </summary>
        public DateTime in_date { get; set; }
        /// <summary>
        /// 报关单号
        /// </summary>
        public string refer_doc { get; set; }
        /// <summary>
        /// mcc业务号
        /// </summary>
        public string mcc_no { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string car_no { get; set; }
        /// <summary>
        /// 货物类型
        /// </summary>
        public string lading_type { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string lease_holder { get; set; }
        /// <summary>
        /// 入仓方式
        /// </summary>
        public string in_type { get; set; }
        /// <summary>
        /// 报关类型
        /// </summary>
        public string dec_type { get; set; }
        /// <summary>
        /// 转关条码
        /// </summary>
        public string trans_doc { get; set; }
        /// <summary>
        /// 司机本编号
        /// </summary>
        public string driver_no { get; set; }
        /// <summary>
        /// 总件数
        /// </summary>
        public decimal pkgs_num { get; set; }
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
        /// 币制
        /// </summary>
        public string curr_code { get; set; }
        /// <summary>
        /// 退税标志
        /// </summary>
        public string tax_flag { get; set; }
        /// <summary>
        /// 核增备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 存放地点
        /// </summary>
        public string place { get; set; }
        /// <summary>
        /// 核增类型
        /// </summary>
        public string hzhk_type { get; set; }
        /// <summary>
        /// 电子账册编号
        /// </summary>
        public string cns_no { get; set; }
        /// <summary>
        /// 核增编号
        /// </summary>
        public string cust_bill_id { get; set; }
        /// <summary>
        /// 进出口岸
        /// </summary>
        public string ie_port { get; set; }
        /// <summary>
        /// 备案号
        /// </summary>
        public string bah { get; set; }
        /// <summary>
        /// 进出口日期
        /// </summary>
        public DateTime ie_date { get; set; }
        /// <summary>
        /// 提运单号
        /// </summary>
        public string tydh { get; set; }
        /// <summary>
        /// 贸易方式
        /// </summary>
        public string trade_mode { get; set; }
        /// <summary>
        /// 征免性质
        /// </summary>
        public string zmxz_code { get; set; }
        /// <summary>
        /// 经营单位
        /// </summary>
        public string trade_code { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public string traf_mode { get; set; }
        /// <summary>
        /// 运输工具
        /// </summary>
        public string traf_name { get; set; }
        /// <summary>
        /// 结汇方式    
        /// </summary>
        public string jhfs_code { get; set; }
        /// <summary>
        /// 许可证号
        /// </summary>
        public string permission_no { get; set; }
        /// <summary>
        /// 发货单位
        /// </summary>
        public string rs_code { get; set; }
        /// <summary>
        /// 运抵/起运国
        /// </summary>
        public string trade_coun { get; set; }
        /// <summary>
        /// 指运/装货港
        /// </summary>
        public string trade_port { get; set; }
        /// <summary>
        /// 境内货源/目的地
        /// </summary>
        public string trade_area { get; set; }
        /// <summary>
        /// 批准文号
        /// </summary>
        public string pzwh { get; set; }
        /// <summary>
        /// 成交方式
        /// </summary>
        public string trans_mode { get; set; }
        /// <summary>
        /// 包装种类
        /// </summary>
        public string bzzl_code { get; set; }
        /// <summary>
        /// 随附单证
        /// </summary>
        public string sfdz { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public string yunf { get; set; }
        /// <summary>
        /// 运费2
        /// </summary>
        public decimal yunf2 { get; set; }
        /// <summary>
        /// 运费3
        /// </summary>
        public string yunf3 { get; set; }
        /// <summary>
        /// 保费
        /// </summary>
        public string baof { get; set; }
        /// <summary>
        /// 保费2
        /// </summary>
        public decimal baof2 { get; set; }
        /// <summary>
        /// 保费3
        /// </summary>
        public string baof3 { get; set; }
        /// <summary>
        /// 杂费
        /// </summary>
        public string zaf { get; set; }
        /// <summary>
        /// 杂费2
        /// </summary>
        public decimal zaf2 { get; set; }
        /// <summary>
        /// 杂费3
        /// </summary>
        public string zaf3 { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string htxyh { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string pu_code { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        public string pu_name { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string creater_name { get; set; }
        /// <summary>
        /// 修改员
        /// </summary>
        public string modify_name { get; set; }
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string client_no { get; set; }
        /// <summary>
        /// 集装箱号
        /// </summary>
        public string cntnr_spec { get; set; }
        /// <summary>
        /// 自天然柜数
        /// </summary>
        public int act_cntnrs { get; set; }
        /// <summary>
        /// 标准柜数
        /// </summary>
        public int stand_cntnrs { get; set; }
        /// <summary>
        /// 吨车载重量
        /// </summary>
        public decimal vehicle_cc { get; set; }
        /// <summary>
        /// 标记唛码及备注
        /// </summary>
        public string note_s { get; set; }
        /// <summary>
        /// 客户流水号
        /// </summary>
        public string s_in_no { get; set; }
        /// <summary>
        /// 子表信息集合
        /// </summary>
        public List<NuclearGrowthEditInfoModel> infoModel { get; set; }
        /// <summary>
        /// JSON对象
        /// </summary>
        public string jsonList { get; set; }
    }
}