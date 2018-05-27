using FFeat.Note.IBll;
using FFeat.Note.Model;
using FFeat.Note.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI.Controllers
{
    public class LoginController : Controller
    {
        private IUserInfoService userInfoService;
        public LoginController(IUserInfoService us)
        {
            this.userInfoService = us;
        }

        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult Index()
        {
            //var UName = Request["UName"];
            //var Pwd = Request["Pwd"];
            //UserInfo userInfo = userInfoService.GetEntities(u => u.UserName == UName && u.Pwd == Pwd && u.DelFlag == DelFalg).FirstOrDefault();
            //if (string.IsNullOrEmpty(Convert.ToString(userInfo)))
            //{
            //    HttpContext.Response.Redirect("/home/index");
            //    return Content("Error，用户名密码错误");

            //}
            //else
            //{

            //    return Content("ok");

            //}
            return View();

        }
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult Login(string uname, string pwd)
        {
            var newPwd = Common.Encryption.GetPwsMd5(pwd);
            var data = userInfoService.GetEntities(u => u.UserName == uname && u.Pwd == newPwd && u.DelFlag == 0).FirstOrDefault();
            if (data != null)
            {
                //HttpContext.Response.Redirect("/Home/Index");
                //string token = Guid.NewGuid().ToString().ToUpper();
                //编码中文cookie值，避免乱码
                HttpCookie cookie = new HttpCookie("name", HttpUtility.UrlEncode(data.UserName));
                Session["userInfo"] = data;
                Response.Cookies.Add(cookie);

                return Content("ok");
            }
            else
            {
                return Content("登录失败");
            }
        }
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult Logout()
        {
            HttpContext.Session["userInfo"] = null;
            //this.Session.Abandon();
            //Session.Contents.Remove("userInfo");
            return Content("ok");
        }
    }
}