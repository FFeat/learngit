using FFeat.Note.IBll;
using FFeat.Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI.Controllers
{
    public class BaseController : Controller
    {

        public IActionInfoService actionInfoServices { get; set; }
        public IRoleInfoService roleInfoServices { get; set; }
        public IR_UsreInfo_ActionInfoService R_UsreInfo_ActionInfoService { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var userData = filterContext.HttpContext.Session["userInfo"] as UserInfo;
            if (userData == null)
            {
                filterContext.Result = new RedirectResult("/login/index");

                return;
            }

            if (userData.UserName == "admin")
            {
                return;
            }
            string url = filterContext.HttpContext.Request.Url.AbsolutePath.ToLower();
            //使用正则匹配，取/Controller/Action 的值
            Match url2 = Regex.Match(url, @"/\w*/\w*/");

            if (url2.Success)
            {
                var str = url2.Groups[0].Value;
                url = str.Substring(0, str.Length - 1);
            }
            var actionInfo = actionInfoServices.GetEntities(a => a.Url.ToLower() == url && a.DelFlag == 0).FirstOrDefault();
            if (actionInfo == null)
            {

                filterContext.Result = new RedirectResult("/home/index");

                return;
            }

            var specialAction = R_UsreInfo_ActionInfoService.GetEntities(r => r.UserInfoId == userData.Id);
            var special = (from r in specialAction
                           where r.ActionInfoId == actionInfo.Id
                           select r).FirstOrDefault();

            if (special != null)
            {
                if (special.HasPermission == true)
                {
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectResult("/home/index");
     
                    return;

                }
            }

            var role = from r in userData.RoleInfo
                       select r;
            var action = from r in role
                         from a in r.ActionInfo
                         select a;
            var temp = (from r in action
                        where r.Id == actionInfo.Id
                        select r).Count();
            if (temp <= 0)
            {

                filterContext.Result = new RedirectResult("/home/index");
         
                return;


                //new RedirectResult("/home/index");
                //RedirectToAction("index", "home");

            }

           
        }

    }
}