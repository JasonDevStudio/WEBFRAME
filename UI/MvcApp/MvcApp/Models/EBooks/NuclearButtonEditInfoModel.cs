using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.EBooks
{
    public class NuclearButtonEditInfoModel
    {
        /// <summary>
        /// 核增订单号
        /// </summary>
        public string in_bill_id { get; set; }
        /// <summary>
        /// 核增序号
        /// </summary>
        public decimal? in_g_no { get; set; }
        /// <summary>
        /// 核增表编号
        /// </summary>
        public string cust_in_bill_id { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string code_t { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string mg_name { get; set; }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string mg_spec { get; set; }
        /// <summary>
        /// 申报数量/成交数量
        /// </summary>
        public decimal g_qty { get; set; }
        /// <summary>
        /// 申报数量单位/成交单位
        /// </summary>
        public string g_unit { get; set; }
        /// <summary>
        /// 币制
        /// </summary>
        public string curr_code { get; set; }
        /// <summary>
        /// 单价/成交单价
        /// </summary>
        public decimal? unit_price { get; set; }
        /// <summary>
        /// 总价/成交总价
        /// </summary>
        public decimal? trade_ttl { get; set; }
        /// <summary>
        /// 目的/原产地
        /// </summary>
        public string orign_coun { get; set; }
        /// <summary>
        /// 征免
        /// </summary>
        public string zm_code { get; set; }
        /// <summary>
        /// 备案序号
        /// </summary>
        public string baxh { get; set; }
        /// <summary>
        /// 附加编码
        /// </summary>
        public string code_s { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal? rate { get; set; }
        /// <summary>
        /// 汇率更新号
        /// </summary>
        public string rate_id { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public decimal? pkgs { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public decimal? gross { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal? net { get; set; }
        /// <summary>
        /// 法定数量
        /// </summary>
        public decimal? qty_1 { get; set; }
        /// <summary>
        /// 法定单位
        /// </summary>
        public string unit_code1 { get; set; }
        /// <summary>
        /// 美元单价
        /// </summary>
        public decimal? usd_unit_price { get; set; }
        /// <summary>
        /// 美元总价
        /// </summary>
        public decimal? usd_trade_ttl { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string version_num { get; set; }
        /// <summary>
        /// 第二数量
        /// </summary>
        public decimal? qty_2 { get; set; }
        /// <summary>
        /// 第二单位
        /// </summary>
        public string unit_code2 { get; set; }
        /// <summary>
        /// 存放位置
        /// </summary>
        public string loc { get; set; }
    }
}