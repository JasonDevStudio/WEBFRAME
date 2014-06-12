using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace System.Web.Mvc
{ 
    /// <summary>
    /// PagerHelper
    /// </summary>
    public static class PagerHelper
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="htmlAttributes">分页头标签属性</param>
        /// <param name="className">分页样式</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, object htmlAttributes, string className, PageMode mode)
        {
            TagBuilder builder = new TagBuilder("table");
            builder.IdAttributeDotReplacement = "_";
            builder.GenerateId(id);
            builder.AddCssClass(className);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            builder.InnerHtml = GetNormalPage(currentPageIndex, pageSize, recordCount, mode);
            return builder.ToString();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="className">分页样式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, string className)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, null, className, PageMode.Normal);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, "pagerTableClass");
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, PageMode mode)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, "pagerTableClass", mode);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="className">分页样式</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, string className, PageMode mode)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, null, className, mode);
        }

        /// <summary>
        /// 获取普通分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        private static string GetNormalPage(int currentPageIndex, int pageSize, int recordCount, PageMode mode)
        {
            if (currentPageIndex <= 0)
            {
                currentPageIndex = 1;
            }

            int pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;
            StringBuilder url = new StringBuilder();
            url.Append(HttpContext.Current.Request.Url.AbsolutePath + "?page={0}");
            NameValueCollection collection = HttpContext.Current.Request.QueryString;
            string[] keys = collection.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].ToLower() != "page")
                    url.AppendFormat("&{0}={1}", keys[i], System.Web.HttpUtility.UrlEncode(collection[keys[i]]));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<tr><td>");
            sb.Append(@"<script language='javascript' language='javascript'>
                                    function goToSumbit(pageNo) {
                                        var pageno = parseInt(pageNo);
                                        if (pageno <= 0) { pageno = 1; }
                                        document.getElementById('hdPagerHelpToPageNo').value = pageno
                                        document.getElementById('SubmitPagerHelpToPageNo').click();

                                    }
                                </script>");
            sb.Append("<input type='hidden' name='hdPagerHelpToPageNo' id='hdPagerHelpToPageNo'/>");
            sb.Append("<input type='submit' name='SubmitPagerHelpToPageNo' id='SubmitPagerHelpToPageNo' style='display:none;'/>");

            sb.AppendFormat("总共{0}条记录,共{1}页&nbsp;&nbsp;", recordCount, pageCount);//当前第{2}页

            if (currentPageIndex == 1)
            {
                sb.Append("<a>首页</a>&nbsp;");
            }
            else
            {
                string url1 = string.Format(url.ToString(), 1);
                sb.Append("<span><a href='javascript:void(0)' onclick='return goToSumbit(1);'>首页</a></span>&nbsp;");
            }
            if (currentPageIndex > 1)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex - 1);
                sb.AppendFormat("<span><a href='javascript:void(0)' onclick='return goToSumbit({0});'>上一页</a></span>&nbsp;", currentPageIndex - 1);
            }
            else
            {
                sb.Append("<a>上一页</a>&nbsp;");
            }
            if (mode == PageMode.Numeric)
                sb.Append(GetNumericPage(currentPageIndex, pageSize, recordCount, pageCount, url.ToString()));
            if (currentPageIndex < pageCount)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex + 1);
                sb.AppendFormat("<span><a href='javascript:void(0)' onclick='return goToSumbit({0});'>下一页</a></span>&nbsp;", currentPageIndex + 1);
            }
            else
                sb.Append("<a>下一页</a>&nbsp;");

            if (currentPageIndex == pageCount || pageCount <= 0)
            {
                sb.Append("<a>末页</a>&nbsp;");
            }
            else
            {
                string url1 = string.Format(url.ToString(), pageCount);
                sb.AppendFormat("<span><a href='javascript:void(0)' onclick='return goToSumbit({0});'>末页</a></span>&nbsp;", pageCount);
            }

            sb.Append("</td></tr>");
            return sb.ToString();
        }

        /// <summary>
        /// 获取数字分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetNumericPage(int currentPageIndex, int pageSize, int recordCount, int pageCount, string url)
        {
            if (currentPageIndex <= 0)
            {
                currentPageIndex = 1;
            }

            int k = currentPageIndex / 5;
            int m = currentPageIndex % 5;
            StringBuilder sb = new StringBuilder();
            if (currentPageIndex / 5 == pageCount / 5)
            {
                if (m == 0)
                {
                    k--;
                    m = 5;
                }
                else
                {
                    m = pageCount % 5;
                }

            }
            else
                m = 5;

            for (int i = k * 5; i <= k * 5 + m; i++)
            {
                if (i > 0)
                {
                    if (i == currentPageIndex)
                        sb.AppendFormat("<span><font color=red><b>{0}</b></font></span>&nbsp;", i);
                    else
                    {
                        string url1 = string.Format(url.ToString(), i);
                        sb.AppendFormat("<span><a href='javascript:void(0)'  onclick='return goToSumbit({0});'>{1}</a></span>&nbsp;", i, i);
                    }
                }
            }

            return sb.ToString();
        }
    }

    /// <summary>
    ///  PageMode 分页模式 
    /// </summary>
    public enum PageMode
    {
        /// <summary>
        /// 普通分页模式
        /// </summary>
        Normal,
        /// <summary>
        /// 普通分页加数字分页
        /// </summary>
        Numeric
    }
}
