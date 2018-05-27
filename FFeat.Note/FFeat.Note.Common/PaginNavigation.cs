using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.Common
{
    public class PaginNavigation
    {
        public static string PagingNavigation(string url, int pageIndex, int pageSize, int totalCount)
        {
            pageSize = pageSize == 0 ? 5 : pageSize;
            var totalPage = Math.Max((totalCount + pageSize - 1)/pageSize, 1);
            
            var output = new StringBuilder();
            if (totalPage > 1)
            {
                if (pageIndex != 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a>", url, pageSize);

                }
                if (pageIndex > 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a>", url, pageIndex - 1, pageSize);

                }
                else
                {
                    output.AppendFormat("<span class='pageLink'>上一页</span>");
                }
                output.Append(" ");
                int currint = 5;
                for (int i = 0; i < 10; i++)
                {
                    if ((pageIndex + i - currint) >= 1 && (pageIndex + i - currint) <= totalPage)
                    {
                        if (currint==i)
                        {
                            //output.AppendFormat(string.Format("[{0}]", pageIndex));
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a>", url, pageIndex, pageSize, pageIndex);

                        }
                        else
                        {
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a>", url, pageIndex + i - currint, pageSize, pageIndex + i - currint);

                        }
                    }
                    output.Append(" ");
                }
                if (pageIndex<totalPage)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a>", url, pageIndex + 1, pageSize);

                }
                else
                {
                    output.Append("<span class='pageLink'>下一页</span>");

                }
                output.Append(" ");
                if (pageIndex!=totalPage)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a>", url, totalPage, pageSize);

                }
                output.Append(" ");

            }
            output.AppendFormat("第{0}页 / 共{1}页", pageIndex, totalPage);
            return output.ToString();
        }





        public static string PagingNavigation1( int pageIndex, int pageSize, int totalCount)
        {
            pageSize = pageSize == 0 ? 5 : pageSize;
            var totalPage = Math.Max((totalCount + pageSize - 1) / pageSize, 1);

            var output = new StringBuilder();
            if (totalPage > 1)
            {
                //if (pageIndex != 1)
                //{
                //    output.AppendFormat("<a class='pageLink' href='javascript:void(0)'pageIndex='1'pageSize='{0}'>首页</a>",  pageSize);

                //}
                //if (pageIndex > 1)
                //{
                //    output.AppendFormat("<a class='pageLink' href='javascript:void(0)'pageIndex='{0}' pageSize='{1}'>上一页</a>", pageIndex - 1, pageSize);

                //}
                //else
                //{
                //    output.AppendFormat("<span class='pageLink'>上一页</span>");
                //}
                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {
                    if ((pageIndex + i - currint) >= 1 && (pageIndex + i - currint) <= totalPage)
                    {
                        if (currint == i)
                        {
                            //output.AppendFormat(string.Format("[{0}]", pageIndex));
                            output.AppendFormat("<a class='cpb' href='javascript:void(0)'pageIndex='{0}' pageSize='{1}'>{2}</a>", pageIndex, pageSize, pageIndex);

                        }
                        else
                        {
                            output.AppendFormat("<a class='pageLink' href='javascript:void(0)'pageIndex='{0}' pageSize='{1}'>{2}</a>",  pageIndex + i - currint, pageSize, pageIndex + i - currint);

                        }
                    }
                    output.Append(" ");
                }
                //if (pageIndex < totalPage)
                //{
                //    output.AppendFormat("<a class='pageLink' href='javascript:void(0)'pageIndex='{0}' pageSize='{1}'>下一页</a>",  pageIndex + 1, pageSize);

                //}
                //else
                //{
                //    output.Append("<span class='pageLink'>下一页</span>");

                //}
                output.Append(" ");
                //if (pageIndex != totalPage)
                //{
                //    output.AppendFormat("<a class='pageLink' href='javascript:void(0)'pageIndex='{0}' pageSize='{1}'>末页</a>",totalPage, pageSize);

                //}
                output.Append(" ");

            }
            output.AppendFormat("第{0}页 / 共{1}页", pageIndex, totalPage);
            return output.ToString();
        }
    }
}
