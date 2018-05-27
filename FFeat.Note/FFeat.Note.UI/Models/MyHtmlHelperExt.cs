using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace System.Web.Mvc
{
    public static class MyHtmlHelperExt
    {
        /// <summary>
        /// 自定义的分页helper扩展方法
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">一页几条</param>
        /// <param name="totalCount">总条数</param>
        /// <returns></returns>
        public static HtmlString ShowPageNavigate(this HtmlHelper htmlHelper, int currentPage, int pageSize, int totalCount)
        {
            //获取请求上下文获取并解析当前url
            var redirectTo = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
            pageSize = pageSize == 0 ? 3 : pageSize;//三目运算符 如果=0 就赋值为3，如果不等于0，就赋值为原值。
            var totalPage = Math.Max((totalCount + pageSize - 1) / pageSize, 1);//总页数
            var output = new StringBuilder();//字符串拼接专用
            if (totalPage > 1)
            {
                if (currentPage != 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a>", redirectTo, pageSize);
                }
                if (currentPage > 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pagIndex={1}&pageSize={2}'>上一页</a>", redirectTo, currentPage - 1, pageSize);
                }
                //else
                //{
                //    output.AppendFormat("<span class='pageLink'>上一页</span>");
                //}
                output.Append(" ");
                int currint = 5;
                for (int i = 0; i < 10; i++)
                {
                    //一条页码最多显示10个，前面5个后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPage)
                    {
                        if (currint == i)
                        {
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a>", redirectTo, currentPage, pageSize, currentPage);

                        }
                        else
                        {
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a>", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint);

                        }
                    }
                    output.Append(" ");

                }

                if (currentPage < totalPage)
                {
                    output.AppendFormat("<a class='pageLink' href={0}?pageIndex={1}&pageSize={2}'>下一页</a>", redirectTo, currentPage + 1, pageSize);

                }
                //else
                //{
                //    output.Append("<span class='pageLink'>下一页</span>");
                //}
                output.Append(" ");
                if (currentPage != totalPage)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a>", redirectTo, totalPage, pageSize);

                }
                output.Append(" ");
            }
            output.AppendFormat("第{0}页 / 共{1}页", currentPage, totalPage);

            return new HtmlString(output.ToString());
        }
    }
}