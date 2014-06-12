using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{  
    /// <summary>
    ///  分页实体  
    /// </summary>
    /// <typeparam name="TPagerInfo"> PagerInfo 分页属性 </typeparam>
    /// <typeparam name="TSearch"> 查询 ，保存页面控件状态值 </typeparam>
    /// <typeparam name="TDataList"> 页面 数据集 </typeparam>
    public class PagerQuery<TPagerInfo, TSearch, TDataList> 
    {
        /// <summary>
        /// 仅用于页面加载，不要直接使用此构造函数
        /// </summary>
        public PagerQuery()
        {

        }

        /// <summary>
        ///  Initializes a new instance of the PagerQuery class.
        /// </summary>
        /// <see cref="PagerQuery" /> 
        /// <param name="pagerInfo"> PagerInfo 分页属性 </param>
        /// <param name="search"> 保存页面 控件状态值</param>
        /// <param name="dataList"> 页面 数据集</param>
        public PagerQuery(TPagerInfo pagerInfo, TSearch search, TDataList dataList)
        {
            this.Pager = pagerInfo;
            this.Search = search;
            this.DataList = dataList;
        }

        /// <summary>
        ///  Gets or sets , PagerInfo
        /// </summary>
        public TPagerInfo Pager { get; set; }

        /// <summary>
        ///  Gets or sets , 保存页面控件状态值
        /// </summary>
        public TSearch Search { get; set; }

        /// <summary>
        ///  Gets or sets ,  数据绑定的 源List
        /// </summary>
        public TDataList DataList { get; set; }
    }
}