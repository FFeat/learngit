using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI.Models
{
    public class MyExceptionFilter:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Common.LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}