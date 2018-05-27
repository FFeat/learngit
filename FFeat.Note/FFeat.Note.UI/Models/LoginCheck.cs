using FFeat.Note.IBll;
using FFeat.Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI.Models
{
    public class LoginCheckFilterAttribute : ActionFilterAttribute
    {
        //public IActionInfoService ActionInfoService { get; set; }
        //public IRoleInfoService RoleInfoService { get; set; }
        public bool IsCheck { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //if (IsCheck)
            //{


            //    var userData = filterContext.HttpContext.Session["userInfo"] as UserInfo;
            //    if (userData == null)
            //    {
            //        filterContext.HttpContext.Response.Redirect("/login/index");
            //        return;
            //    }


            //    string url = filterContext.HttpContext.Request.Url.AbsolutePath.ToLower();
            //    var actionInfo = ActionInfoService.GetEntities(a => a.Url.ToLower() == url && a.DelFlag == 0).FirstOrDefault();
                //if (actionInfo == null) { filterContext.HttpContext.Response.Redirect("/home/index"); return; }
                //var roleId = (from r in userData.RoleInfo select r.Id).ToList();
                //List<int> Ids = new List<int>();
                ////foreach (var id in roleId)
                ////{
                ////    var actionRole = roleInfoService.GetEntities(r => r.Id == id).FirstOrDefault();
                ////    Ids.AddRange((from r in actionRole.ActionInfo select r.Id).ToList());

                ////}

                //var role = from r in userData.RoleInfo
                //           select r;
                //var action = from r in role
                //             from a in r.ActionInfo
                //             select a;

                //var userRoleInfo=roleInfoService.GetEntities(r=>r.Id)

        }

    }
}