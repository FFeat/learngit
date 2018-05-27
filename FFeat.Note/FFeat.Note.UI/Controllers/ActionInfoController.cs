using FFeat.Note.IBll;
using FFeat.Note.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FFeat.Note.UI.Controllers
{
    public class ActionInfoController : BaseController
    {
        private IActionInfoService actionInfoService;
        public ActionInfoController(IActionInfoService actioninfo)
        {
            this.actionInfoService = actioninfo;
        }
        // GET: ActionInfo
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {

            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            int total = 0;
            ViewData.Model = actionInfoService.GetEntitesByPage(pageSize, pageIndex, out total, a => a.DelFlag == 0, a => a.Id, true);
            ViewData["total"] = total;
            return View();
        }

        // GET: ActionInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActionInfo/Create
        /// <summary>
        /// 添加权限信息Get进入
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        // POST: ActionInfo/Create
        [HttpPost]
        public ActionResult Add(ActionInfo ai)
        {
            try
            {
                // TODO: Add insert logic here
                ai.DelFlag = 0;
                ai.SubTime = DateTime.Now;
                actionInfoService.Add(ai);
                return Content("ok");


            }
            catch
            {
                return View();
            }
        }

        // GET: ActionInfo/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData.Model = actionInfoService.GetEntities(a => a.Id == id && a.DelFlag == 0).FirstOrDefault();
            return View();
        }

        // POST: ActionInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(ActionInfo ai)
        {
            try
            {
                // TODO: Add update logic here

                actionInfoService.Edit(ai);

                return Content("ok");
            }
            catch
            {
                return View();
            }
        }

        // GET: ActionInfo/Delete/5
        public ActionResult Delete()
        {
            int id = int.Parse(Request["id"]);
            //ai.DelFlag = 1;
            actionInfoService.Delete(id);
            return Content("ok");
        }

        // POST: ActionInfo/Delete/5
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
        /// <summary>
        /// 获取所有url
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllUrl()
        {
            List<Type> controllerTypes = new List<Type>();

            var assembly = Assembly.Load("FFeat.Note.UI");
            controllerTypes.AddRange(assembly.GetTypes().Where(type => typeof(IController).IsAssignableFrom(type) && type.Name != "ErrorController"));
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            foreach (var item in controllerTypes)
            {
                jsonBuilder.Append("{\"ctrlName\":\"");
                string CtrlUrl = "/" + item.Name.Replace("Controller", "/");

                jsonBuilder.Append(CtrlUrl);
                jsonBuilder.Append("\",\"allUrl\":[");
                var actions = item.GetMethods().Where(m => m.ReturnType.Name == "ActionResult");
                MethodInfo[] str = actions.ToArray();
                if (actions.Count() > 0)
                {
                    string at = null;
                    foreach (var action in actions)
                    {

                        if (at == action.Name)
                        {
                            continue;
                        }
                        jsonBuilder.Append("{\"actionUrl\":\"");
                        string allUrl = CtrlUrl + action.Name;
                        at = action.Name;
                        jsonBuilder.Append(allUrl);
                        jsonBuilder.Append("\"},");

                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("]},");

                }
                else
                {
                    jsonBuilder.Append("]},");

                }




            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            return Content(jsonBuilder.ToString());
        }
    }
}
