using FFeat.Note.Common;
using FFeat.Note.IBll;
using FFeat.Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FFeat.Note.Model.EnumNote;

namespace FFeat.Note.UI.Controllers
{

    public class NoteInfoController : BaseController
    {
        private INoteInfoService noteInfoService;
        public NoteInfoController(INoteInfoService noteInfoService)
        {
            this.noteInfoService = noteInfoService;
        }

        // GET: NoteInfo
        public ActionResult Index(int pageIndex = 1, int pageSize = 15)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            int total = 0;
            ViewData.Model = noteInfoService.GetEntitesByPage(pageSize, pageIndex, out total, n => n.DelFlag == 0, n => n.SubTime, true);

            ViewData["total"] = total;

            return View();

        }

        // GET: NoteInfo/Details/5
        public ActionResult Details(int id)
        {
            ViewData.Model = noteInfoService.GetEntities(n => n.Id == id).FirstOrDefault();
            return View();
        }

        // GET: NoteInfo/Create
        public ActionResult Add()
        {
            ViewBag.NoteTypeList = EnumHelper.GetSelectList<NoteTypeEnum>();
            return View();
        }

        // POST: NoteInfo/Create
        //让服务器不验证输入，针对富文本编辑器
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(NoteInfo ni)
        {
            try
            {
                // TODO: Add insert logic here
                ni.SubTime = DateTime.Now;
                ni.DelFlag = 0;
                ni.UserInfoId = (HttpContext.Session["userInfo"] as UserInfo).Id;
                noteInfoService.Add(ni);

                return Content("ok");
            }
            catch
            {
                return Content("添加失败");
            }
        }

        // GET: NoteInfo/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData.Model = noteInfoService.GetEntities(n => n.Id == id && n.DelFlag == 0).FirstOrDefault();
            //ViewBag.NoteTypeList = EnumHelper.GetSelectList<NoteTypeEnum>();
            return View();
        }

        // POST: NoteInfo/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(NoteInfo ni)
        {
            try
            {
                ni.SubTime = DateTime.Now;
                ni.UserInfoId = (HttpContext.Session["userInfo"] as UserInfo).Id;
                // TODO: Add update logic here
                noteInfoService.Edit(ni);
                return Content("ok");
            }
            catch
            {
                return Content("添加失败");
            }
        }

        // GET: NoteInfo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                noteInfoService.LogicalDelete(new List<int> { id });
                return Content("ok");
            }
            catch
            {
                return Content("删除失败");
            }
        }

        // POST: NoteInfo/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
