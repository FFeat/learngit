using FFeat.Note.IBll;
using FFeat.Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI.Controllers
{
    public class RoleInfoController : BaseController
    {
        private IRoleInfoService roleInfoService;
        private IActionInfoService actionInfoService;
        public RoleInfoController(IRoleInfoService rs, IActionInfoService ias)
        {
            this.roleInfoService = rs;
            this.actionInfoService = ias;

        }
        // GET: RoleInfo
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            int total = 0;
            ViewData.Model = roleInfoService.GetEntitesByPage(pageSize, pageIndex, out total, r => r.DelFlag == 0, r => r.Id, true);
            ViewData["total"] = total;
            return View();
        }

        // GET: RoleInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleInfo/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: RoleInfo/Create
        [HttpPost]
        public ActionResult Add(RoleInfo ri)
        {
            try
            {
                // TODO: Add insert logic here
                ri.SubTime = DateTime.Now;
                roleInfoService.Add(ri);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleInfo/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData.Model = roleInfoService.GetEntities(r => r.Id == id).FirstOrDefault();
            return View();
        }

        // POST: RoleInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(RoleInfo ri)
        {
            try
            {
                // TODO: Add update logic here
                ri.SubTime = DateTime.Now;
                roleInfoService.Edit(ri);
                return Content("ok");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleInfo/Delete/5
        public ActionResult Delete()
        {
            int id = int.Parse(Request["id"]);
            roleInfoService.Delete(id);
            return Content("ok");
        }

        public ActionResult ActionSet()
        {
            int roleId = int.Parse(Request["id"]);
            var roleData = roleInfoService.GetEntities(r => r.Id == roleId && r.DelFlag == 0)
                .Select(r => new { r.Id, r.RoleName, r.SubTime, r.ActionInfo }).FirstOrDefault();
            var roleData2 = roleInfoService.GetEntities(r => r.Id == roleId && r.DelFlag == 0)
                .Select(r => new { r.Id, r.RoleName, r.SubTime }).FirstOrDefault();
            var actionData = actionInfoService.GetEntities(r => r.DelFlag == 0)
                .Select(r => new { r.Id, r.ActionName, r.Url, r.Remark, r.SubTime }).ToList();
            var exsitActions = (from a in roleData.ActionInfo
                                select a.Id).ToList();
            return Json(new { role = roleData2, action = actionData, exAction = exsitActions }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult ProcessSetAction()
        {
            int roleId = int.Parse(Request["roleId"]);
            string actionIds = Request["actionIds"];
            string[] idArray = actionIds.Split(',');
            List<int> IdList = new List<int>();
            foreach (var id in idArray)
            {
                IdList.Add(int.Parse(id));
            }
            roleInfoService.SetAction(roleId, IdList);
            return Content("ok");
        }
    }
}
