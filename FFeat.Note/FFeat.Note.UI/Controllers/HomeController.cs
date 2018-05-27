using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using FFeat.Note.Bll;
using FFeat.Note.IBll;
using FFeat.Note.Model;
using FFeat.Note.UI.Models;

namespace FFeat.Note.UI.Controllers
{
    public class HomeController : Controller
    {
        private INoteInfoService noteInfoService;
        short Basic = (short)Model.EnumNote.NoteTypeEnum.BasicKnow;
        short winform = (short)Model.EnumNote.NoteTypeEnum.Winform;
        short webform = (short)Model.EnumNote.NoteTypeEnum.Webform;
        short aspmvc = (short)Model.EnumNote.NoteTypeEnum.Aspmvc;
        short DelFlag = (short)Model.EnumNote.DelFlagEnum.Normal;
        public HomeController(INoteInfoService ns)
        {
            this.noteInfoService = ns;
        }
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult Index(int pageIndex = 1, int pageSize = 6)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;


            //ViewData.Model = noteInfoService.GetEntities(n =>n.NoteType==NoteTypes);

            return View();
        }



        //根据ID，查询笔记信息
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult GetNoteInfoById()
        {


            int Id = int.Parse(Request["Id"] ?? "0");
            var data = noteInfoService.GetEntities(n => n.Id == Id).Select(n => new { n.NoteName, n.SubTime, n.SubContent, n.UserInfoId }).FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 初始化所有基础note信息
        /// </summary>
        /// <returns></returns>
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult GetAllBasicNote()
        {
            return Json(new { rows = GetNoteInfo(DelFlag, Basic), pagingString = pagingNavigation }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取winform信息
        /// </summary>
        /// <returns></returns>
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult GetAllWinformNote()
        {
            return Json(new { rows = GetNoteInfo(DelFlag, winform), pagingString = pagingNavigation }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取webform基础信息
        /// </summary>
        /// <returns></returns>
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult GetAllWebformNote()
        {
            return Json(new { rows = GetNoteInfo(DelFlag, webform), pagingString = pagingNavigation }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        ///获取mvc相关信息
        /// </summary>
        /// <returns></returns>
        //[LoginCheckFilter(IsCheck = false)]
        public ActionResult GetAllAspmvcNote()
        {
            return Json(new { rows = GetNoteInfo(DelFlag, aspmvc), pagingString = pagingNavigation }, JsonRequestBehavior.AllowGet);
        }
        public string pagingNavigation;
        /// <summary>
        /// 封装NoteInfo通用查询方法
        /// </summary>
        /// <param name="DelFlag"></param>
        /// <param name="NoteType"></param>
        /// <returns></returns>

        public IQueryable GetNoteInfo(short DelFlag, short NoteType)
        {
            int pageSize = int.Parse(Request["pageSize"] ?? "6");
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int total = 0;

            var pageData = noteInfoService.GetEntitesByPage(pageSize, pageIndex, out total, n => n.DelFlag == DelFlag && n.NoteType == NoteType, n => n.SubTime, false).Select(n => new { n.Id, n.NoteName, n.SubTime, n.UserInfoId });
            pagingNavigation = Common.PaginNavigation.PagingNavigation1(pageIndex, pageSize, total);
            //var data = new { rows = pageData.ToList(), pagingString = pagingNavigation };

            return pageData;
        }






    }
}