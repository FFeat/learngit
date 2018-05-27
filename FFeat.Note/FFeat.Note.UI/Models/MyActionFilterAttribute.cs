using FFeat.Note.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI.Models
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {

        public IActionInfoService ActionInfoService { get; set; }
        public  IRoleInfoService RoleInfoService { get; set; }
        public MyActionFilterAttribute(IActionInfoService aa, IRoleInfoService rs)
        {
            this.ActionInfoService = aa;
            this.RoleInfoService = rs;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string url = filterContext.HttpContext.Request.Url.AbsolutePath.ToLower();
            var actionInfo = ActionInfoService.GetEntities(a => a.Url.ToLower() == url && a.DelFlag == 0).FirstOrDefault();
            if (actionInfo == null) { filterContext.HttpContext.Response.Redirect("/home/index"); return; }

        }
    }
}