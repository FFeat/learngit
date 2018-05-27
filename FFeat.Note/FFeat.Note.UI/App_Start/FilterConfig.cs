using FFeat.Note.UI.Models;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //自定义日志输出
            filters.Add(new MyExceptionFilter());
            //filters.Add(DependencyResolver.Current.GetService<LoginCheckFilterAttribute>());
            //filters.Add(new LoginCheckFilterAttribute() { IsCheck = true });
            //filters.Add(new MyActionFilterAttribute(aa ,rs));
            //filters.Add(DependencyResolver.Current.GetService<MyActionFilterAttribute>());

        }
    }
}
