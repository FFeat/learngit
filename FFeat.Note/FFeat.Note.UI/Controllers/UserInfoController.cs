using FFeat.Note.Factory;
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
    public class UserInfoController : BaseController
    {
        short DelFlag = (short)Model.EnumNote.DelFlagEnum.Normal;
        private IUserInfoService userInfoService;
        private IRoleInfoService roleInfoService;
        private IActionInfoService actionInfoService;
        private IR_UsreInfo_ActionInfoService r_UsreInfo_ActionInfoService;
        public UserInfoController(IUserInfoService us, IRoleInfoService rs, IActionInfoService af, IR_UsreInfo_ActionInfoService ira)
        {
            this.userInfoService = us;
            this.roleInfoService = rs;
            this.actionInfoService = af;
            this.r_UsreInfo_ActionInfoService = ira;

        }

        // GET: UserInfo
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {

            int total = 0;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;


            //ViewData.Model = userInfoService.GetEntities(u => true);
            ViewData.Model = userInfoService.GetEntitesByPage(pageSize, pageIndex, out total, u => u.DelFlag == DelFlag, u => u.Id, true);
            //ViewData.Model=userInfoService.get
            //var data = userInfoService.GetEntitesByPage(pageSize, pageIndex, out total, u => u.DelFlag == DelFlag, u => u.Id, true);
            //s  ViewData["total"] = total;tring pagingNavigation = Common.PaginNavigation.PagingNavigation1(pageIndex, pageSize, total);
            ViewData["total"] = total;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserInfo ui)
        {
            ui.UserName = Request["UserName"];
            var ext = userInfoService.GetEntities(u => u.UserName == ui.UserName && u.DelFlag == 0).FirstOrDefault();
            if (ext == null)
            {
                ui.Pwd = Request["Pwd"];
                ui.Pwd = Common.Encryption.GetPwsMd5(ui.Pwd);
                ui.DelFlag = 0;
                ui.SubTime = DateTime.Now;
                ui.LoginTime = DateTime.Now;
                userInfoService.Add(ui);
                //HttpContext.Response.Redirect("/UserInfo/index");
                return Content("ok");
            }
            else
            {
                return Content("注册用户已存在，请更换");

            }


        }

        public ActionResult Edit(int id)
        {
            ViewData.Model = userInfoService.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserInfo ui)
        {
            //var ext = userInfoService.GetEntities(u => u.UserName == ui.UserName && u.DelFlag == 0).FirstOrDefault();
            //if (ext == null)
            //{
                ui.Pwd = Common.Encryption.GetPwsMd5(ui.Pwd);
                userInfoService.Edit(ui);
                //HttpContext.Response.Redirect("/UserInfo/index")2;
                return Content("ok");
            //}
            //else
            //{
            //    return Content("更改的用户名已存在，请更换");

            //}


        }
        public ActionResult Delete()
        {
            int deleteId = int.Parse(Request["id"]);
            //ui.DelFlag = 1;
            //userInfoService.GetEntities(u => u.Id == deleteId && u.DelFlag == DelFlag);
            //userInfoService.Edit(ui);
            userInfoService.LogicalDelete(new List<int> { deleteId });
            //userInfoService.Delete(deleteId);
            return Content("ok");
        }

        public ActionResult SetRole()
        {
            int id = int.Parse(Request["id"]);
            var userData = userInfoService.GetEntities(u => u.Id == id && u.DelFlag == 0).Select(u => new { u.Id, u.UserName, u.SubTime, u.RoleInfo }).FirstOrDefault();
            var userData2 = userInfoService.GetEntities(u => u.Id == id && u.DelFlag == 0).Select(u => new { u.Id, u.UserName, u.SubTime, }).FirstOrDefault();
            var roleData = roleInfoService.GetEntities(r => r.DelFlag == DelFlag).Select(r => new { r.Id, r.RoleName }).ToList();
            var exitsRole = (from r in userData.RoleInfo
                             select r.Id).ToList();
            return Json(new { user = userData2, role = roleData, exRole = exitsRole }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProcessSetRole()
        {
            int userId = int.Parse(Request["id"]);
            string roleIds = Request["RoleId"];
            string[] IdArray = roleIds.Split(',');
            List<int> IdList = new List<int>();
            foreach (var id in IdArray)
            {
                IdList.Add(int.Parse(id));

            }
            userInfoService.SettRole(userId, IdList);
            return Content("ok");


        }

        public ActionResult InitialSpecial(int uId)
        {
            var userActionData = r_UsreInfo_ActionInfoService.GetEntities(r => r.UserInfoId == uId && r.DelFlag == 0).Select(r => new { r.ActionInfoId, r.HasPermission });
            return Json(userActionData, JsonRequestBehavior.AllowGet);
            //var userRoleData = userInfoService.GetEntities(u => u.Id == uId && u.DelFlag == 0).FirstOrDefault();
            //var roleId = (from r in userRoleData.RoleInfo
            //              select r.Id).ToList();
            //List<int> roleAction = new List<int>();
            //foreach (var id in roleId)
            //{
            //    var roleActionData = roleInfoService.GetEntities(r => r.Id == id && r.DelFlag == 0).FirstOrDefault();
            //    roleAction.AddRange((from r in roleActionData.ActionInfo
            //                    select r.Id).ToList());
            //}
            //var newroleAction = roleAction.Distinct();

        }




        public ActionResult SetSpecial(int id = 1, int pageIndex = 1, int pageSize = 10)
        {
            //int pageIndex = 1; int pageSize = 10;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            int total = 0;
            ViewBag.User = userInfoService.GetEntities(u => u.Id == id).FirstOrDefault();
            ViewData.Model = actionInfoService.GetEntitesByPage(pageSize, pageIndex, out total, a => a.DelFlag == DelFlag, a => a.Id, true);
            ViewData["total"] = total;
            return View();
        }
        public ActionResult ProcessSpecial(int uId, int aId, int heValue)
        {
            var rUserAction = r_UsreInfo_ActionInfoService.GetEntities(r => r.UserInfoId == uId && r.ActionInfoId == aId && r.DelFlag == 0).FirstOrDefault();
            if (rUserAction != null)
            {
                rUserAction.HasPermission = heValue == 1 ? true : false;
                r_UsreInfo_ActionInfoService.Edit(rUserAction);
            }
            else
            {
                R_UsreInfo_ActionInfo RUserAcion = new R_UsreInfo_ActionInfo();
                RUserAcion.ActionInfoId = aId;
                RUserAcion.UserInfoId = uId;
                RUserAcion.DelFlag = 0;
                RUserAcion.HasPermission = heValue == 1 ? true : false;
                r_UsreInfo_ActionInfoService.Add(RUserAcion);
            }
            return Content("ok");

        }

        public ActionResult ClearSpecial(int uId, int aId)
        {
            var rUserAction = r_UsreInfo_ActionInfoService.GetEntities(r => r.ActionInfoId == aId && r.UserInfoId == uId).FirstOrDefault();
            if (rUserAction != null)
            {
                r_UsreInfo_ActionInfoService.LogicalDelete(new List<int>() { rUserAction.Id });
            }
            return Content("ok");

        }
    }
}