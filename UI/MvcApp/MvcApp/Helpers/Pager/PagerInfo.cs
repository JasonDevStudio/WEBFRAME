using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    /// <summary>
    ///  分页 MODEL
    /// </summary>
    public class PagerInfo
    {
        /// <summary>
        ///  Initializes a new instance of the PagerInfo class.
        ///  PagerInfo 请赋默认值  
        /// </summary>
        public PagerInfo(HttpContextBase context)
        {
            this.PageSize = 10;
            this.CurrentPageIndex = this.GetPageNo(context);
        }

        /// <summary>
        ///  取页码
        /// </summary>
        /// <param name="context"> HttpContext </param>
        /// <returns> 当前页码数 </returns>
        private int GetPageNo(HttpContextBase context)
        {
            string pageno = context.Request.Form["hdPagerHelpToPageNo"];
            int ipageNo = 1;
            if (int.TryParse(pageno, out ipageNo) == false) { ipageNo = 1; }
            return ipageNo;
        }

        /// <summary>
        ///  记录总数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// 每页记录行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///  总页数
        /// </summary>
        public int TotalPages { get; set; }
    }
}