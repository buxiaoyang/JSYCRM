using JSYCRM.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSYCRM.Controllers
{
    [Authentication]
    public class AnnouncementController : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index(String message, String page, String search)
        {
            int pageNum = Common.Common.getPageNum(page);
            DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
            if (message != null && message != "")
            {
                ViewBag.message = message;
            }
            List<Models.m_announcement> m_announcement_list = dal_m_announcement.GetListModelByPage(search, pageNum * 15 + 1, (pageNum + 1) * 15);
            ViewBag.recordCount = dal_m_announcement.GetRecordCount(search);
            ViewBag.page = pageNum + 1;
            ViewBag.pageNum = Math.Ceiling((double)ViewBag.recordCount / (double)15);
            ViewBag.search = search;
            return View(m_announcement_list);
        }

        public ActionResult Details(String id)
        {
            try
            {
                DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
                Models.m_announcement model_m_announcement = dal_m_announcement.GetModel(new Guid(id));
                return View(model_m_announcement);
            }
            catch
            {
                ViewBag.message = "查看失败，员工不存在";
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.z_user session_model_z_user =  (Models.z_user)ViewBag.model_z_user;
                string TITLE =  collection["title"].Trim();
                string TITLE_COLOR = collection["color"].Trim();
                string PUBLISH = collection["status"].Trim();
                string SHOW_IN_LOGIN = collection["isshow"].Trim();
                string BODY = collection["content"].Trim();
                Models.m_announcement model_m_announcement = new Models.m_announcement();
                model_m_announcement.ID = Guid.NewGuid();
                model_m_announcement.TITLE = TITLE;
                model_m_announcement.TITLE_COLOR = TITLE_COLOR;
                model_m_announcement.PUBLISH = PUBLISH;
                model_m_announcement.SHOW_IN_LOGIN = SHOW_IN_LOGIN;
                model_m_announcement.DEPARTMENT = "";
                model_m_announcement.BODY = BODY;
                model_m_announcement.CREATE_USER_ID = session_model_z_user.ID;
                model_m_announcement.CREATE_DATETIME = DateTime.Now;
                model_m_announcement.UPDATE_USER_ID = session_model_z_user.ID;
                model_m_announcement.UPDATE_DATETIME = DateTime.Now;
                model_m_announcement.DELETE_FLG = "0";
                DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
                dal_m_announcement.Add(model_m_announcement);
                return RedirectToAction("Index", new { message = "新建成功" });
            }
            catch
            {
                ViewBag.message = "新建失败";
                return View();
            }
        }

        public ActionResult Edit(String id)
        {
            DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
            Models.m_announcement model_m_announcement = dal_m_announcement.GetModel(new Guid(id));
            return View(model_m_announcement);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, FormCollection collection)
        {
            DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
            Models.m_announcement model_m_announcement = dal_m_announcement.GetModel(new Guid(id));
            try
            {
                Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
                string TITLE = collection["title"].Trim();
                string TITLE_COLOR = collection["color"].Trim();
                string PUBLISH = collection["status"].Trim();
                string SHOW_IN_LOGIN = collection["isshow"].Trim();
                string BODY = collection["content"].Trim();
                model_m_announcement.TITLE = TITLE;
                model_m_announcement.TITLE_COLOR = TITLE_COLOR;
                model_m_announcement.PUBLISH = PUBLISH;
                model_m_announcement.SHOW_IN_LOGIN = SHOW_IN_LOGIN;
                model_m_announcement.BODY = BODY;
                model_m_announcement.UPDATE_USER_ID = session_model_z_user.ID;
                model_m_announcement.UPDATE_DATETIME = DateTime.Now;
                dal_m_announcement.Update(model_m_announcement);
                return RedirectToAction("Index", new { message = "编辑成功" });
            }
            catch
            {
                ViewBag.message = "编辑失败";
                return View(model_m_announcement);
            }
        }

        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            try
            {
                String IDlist = collection["id[]"];
                IDlist = IDlist.Replace(",", "','");
                IDlist = "'" + IDlist + "'";
                DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
                dal_m_announcement.DeleteList(IDlist);
                return RedirectToAction("Index", new { message = "删除成功" });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "删除失败" });
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
                dal_m_announcement.Delete(new Guid(id));
                return RedirectToAction("Index", new { message = "删除成功" });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "删除失败" });
            }
        }

        public ActionResult Publish(string id, string status)
        {
            try
            {
                string PUBLISH = "已停用";
                if (status == "publish")
                {
                    PUBLISH = "发布中";
                }
                DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
                Models.m_announcement model_m_announcement = dal_m_announcement.GetModel(new Guid(id));
                model_m_announcement.PUBLISH = PUBLISH;
                dal_m_announcement.Update(model_m_announcement);
                return RedirectToAction("Index", new { message = "操作成功" });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "操作失败" });
            }
        }

    }
}
