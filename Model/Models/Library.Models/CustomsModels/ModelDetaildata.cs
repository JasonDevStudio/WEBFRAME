using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.CustomsModels
{
    public class ModelDetaildata
    {
        /// <summary> 
        /// 单据编码 
        /// </summary>
        [Required]
        [Display(Name = "单据编码")]
        public String Djbm { get;set;} 

        /// <summary> 
        /// 商品序号 
        /// </summary>
        [Required]
        [Display(Name = "商品序号")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "商品序号输入错误！")]
        public Int32 Spxh { get;set;} 

        /// <summary> 
        /// 备案序号
    
        /// </summary>
        [Display(Name = "备案序号")]
        public String Baxh { get;set;} 

        /// <summary> 
        /// 商品编号 
        /// </summary>
        [Display(Name = "商品编号")]
        public String Spbh { get;set;} 

        /// <summary> 
        /// 附加编号 
        /// </summary>
        [Display(Name = "附加编号")]
        public String Fjbh { get;set;} 

        /// <summary> 
        /// 商品名称 
        /// </summary>
        [Display(Name = "商品名称")]
        public String Spmc { get;set;} 

        /// <summary> 
        /// 规格型号 
        /// </summary>
        [Display(Name = "规格型号")]
        public String Ggxh { get;set;} 

        /// <summary> 
        /// 成交数量 
        /// </summary>
        [Display(Name = "成交数量")]
        public Object Cjsl { get;set;} 

        /// <summary> 
        /// 成交单位 
        /// </summary>
        [Display(Name = "成交单位")]
        public String Cjdw { get;set;} 

        /// <summary> 
        /// 成交单价 
        /// </summary>
        [Display(Name = "成交单价")]
        public Object Cjdj { get;set;} 

        /// <summary> 
        /// 成交总价 
        /// </summary>
        [Display(Name = "成交总价")]
        public Object Cjzj { get;set;} 

        /// <summary> 
        /// 币制 
        /// </summary>
        [Display(Name = "币制")]
        public String Bizhi { get;set;} 

        /// <summary> 
        /// 法定数量 
        /// </summary>
        [Display(Name = "法定数量")]
        public Object Fdsl { get;set;} 

        /// <summary> 
        /// 法定单位 
        /// </summary>
        [Display(Name = "法定单位")]
        public String Fddw { get;set;} 

        /// <summary> 
        /// 版本号 
        /// </summary>
        [Display(Name = "版本号")]
        public String Bbh { get;set;} 

        /// <summary> 
        /// 货号 
        /// </summary>
        [Display(Name = "货号")]
        public String Huoh { get;set;} 

        /// <summary> 
        /// 生产厂家 
        /// </summary>
        [Display(Name = "生产厂家")]
        public String Sccj { get;set;} 

        /// <summary> 
        /// 第二数量
    
        /// </summary>
        [Display(Name = "第二数量")]
        public Object Desl { get;set;} 

        /// <summary> 
        /// 第二单位 
        /// </summary>
        [Display(Name = "第二单位")]
        public String Dedw { get;set;} 

        /// <summary> 
        /// 目的地 
        /// </summary>
        [Display(Name = "目的地")]
        public String Mdd { get;set;} 

        /// <summary> 
        /// 报关单类型 
        /// </summary>
        [Display(Name = "报关单类型")]
        public String Zm { get;set;} 

        /// <summary> 
        /// 工缴费
    
        /// </summary>
        [Display(Name = "工缴费")]
        public Object Gjf { get;set;} 

        /// <summary> 
        /// 用途 
        /// </summary>
        [Display(Name = "用途")]
        public String Yt { get;set;} 

    }
}
