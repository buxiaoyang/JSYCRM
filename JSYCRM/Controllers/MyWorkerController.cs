using JSYCRM.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSYCRM.Controllers
{
    [Authentication]
    public class MyWorkerController : Controller
    {
        //
        // GET: /Worker/

        public ActionResult Index(String message, String page, String field, String condition, String search, String by)
        {
            message = HttpUtility.UrlDecode(message, System.Text.Encoding.UTF8);
            int pageNum = Common.Common.getPageNum(page);
            DAL.m_worker dal_m_worker = new DAL.m_worker();
            if (message != null && message != "")
            {
                ViewBag.message = message;
            }
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            List<Models.m_worker> m_worker_list = dal_m_worker.GetListModelByPage(field, condition, search, by, pageNum * 15 + 1, (pageNum + 1) * 15, false, session_model_z_user.ID);
            ViewBag.recordCount = dal_m_worker.GetRecordCount(field, condition, search, by, false, session_model_z_user.ID);
            ViewBag.page = pageNum + 1;
            ViewBag.pageNum = Math.Ceiling((double)ViewBag.recordCount / (double)15);
            ViewBag.field = field;
            ViewBag.condition = condition;
            ViewBag.search = search;
            ViewBag.by = by;
            return View(m_worker_list);
        }

        //
        // GET: /Worker/Details/5

        public ActionResult Details(string id)
        {
            try
            {
                DAL.m_worker dal_m_worker = new DAL.m_worker();
                Models.m_worker model_m_worker = dal_m_worker.GetModel(new Guid(id));
                DAL.m_worker_history dal_m_worker_history = new DAL.m_worker_history();
                List<Models.m_worker_history> z_m_worker_history_list = dal_m_worker_history.GetModelList(model_m_worker.ID);
                ViewBag.z_m_worker_history_list = z_m_worker_history_list;
                return View(model_m_worker);
            }
            catch
            {
                ViewBag.message = "错误，该工友不存在";
                return View();
            }
        }

        //
        // GET: /Worker/Create

        public ActionResult Create()
        {
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            ViewBag.area_list = dal_z_parameter.GetModelList("地区");
            ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
            return View();
        }

        //
        // POST: /Worker/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            DAL.m_worker dal_m_worker = new DAL.m_worker();
            try
            {
                Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
                ViewBag.area_list = dal_z_parameter.GetModelList("地区");
                ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
                // TODO: Add insert logic here
                string B_NAME = collection["B_NAME"].Trim();
                string B_GENDER = collection["B_GENDER"];
                string B_TEL = collection["B_TEL"].Trim();
                string B_ADDRESS = collection["B_ADDRESS"].Trim();
                string B_ID_CARD = collection["B_ID_CARD"].Trim();
                string B_CREATE_AREA_ID = collection["B_CREATE_AREA_ID"];
                string B_EXPIRY_DATA = collection["B_EXPIRY_DATA"];
                string W_WORK_AREA_ID = collection["W_WORK_AREA_ID"];
                string W_IS_DELIVERY = collection["W_IS_DELIVERY"];
                string W_DELIVERY_DATA = collection["W_DELIVERY_DATA"];
                string W_IS_PASS_INTERVIEW = collection["W_IS_PASS_INTERVIEW"];
                string W_INTERVIEW_DATA = collection["W_INTERVIEW_DATA"];
                string W_IS_ONBOARD = collection["W_IS_ONBOARD"];
                string W_ONBOARD_DATA = collection["W_ONBOARD_DATA"];
                string W_IS_RESIGNATION = collection["W_IS_RESIGNATION"];
                string W_RESIGNATION_DATA = collection["W_RESIGNATION_DATA"];
                string A_GRADUATE_DATA = collection["A_GRADUATE_DATA"];
                string A_CENSUS = collection["A_CENSUS"].Trim();
                string A_EDU_BACKGROUND = collection["A_EDU_BACKGROUND"].Trim();
                string A_HOME_TEL = collection["A_HOME_TEL"].Trim();
                string A_HOME_ADDRESS = collection["A_HOME_ADDRESS"].Trim();
                string COMMENTS = collection["COMMENTS"];
                if (B_NAME == "" || B_GENDER == null || B_TEL == "" || B_CREATE_AREA_ID == "" || B_EXPIRY_DATA == "")
                {
                    ViewBag.message = "新建失败，标红星的字段不能为空或者不选";
                    return View();
                }
                if (dal_m_worker.isWorkerDuplicate(B_NAME, B_TEL, B_ID_CARD, null))
                {

                    ViewBag.message = "新建失败，姓名为：" + B_NAME + "，并且联系方式为：" + B_TEL + " 的工友已经存在。请在工友库中查找。";
                    return View();
                }
                Models.m_worker model_m_worker = new Models.m_worker();
                model_m_worker.ID = Guid.NewGuid();
                model_m_worker.B_NAME = B_NAME;
                model_m_worker.B_GENDER = B_GENDER;
                model_m_worker.B_TEL = B_TEL;
                model_m_worker.B_ADDRESS = B_ADDRESS;
                model_m_worker.B_ID_CARD = B_ID_CARD;
                model_m_worker.B_CREATE_AREA_ID = new Guid(B_CREATE_AREA_ID);
                model_m_worker.B_ASSOCIATED_USER_ID = session_model_z_user.ID;
                model_m_worker.B_ASSOCIATED_DATA = DateTime.Now;
                model_m_worker.B_EXPIRY_DATA = DateTime.Parse(B_EXPIRY_DATA);
                try
                {
                    model_m_worker.W_WORK_AREA_ID = new Guid(W_WORK_AREA_ID);
                }
                catch
                {
                    model_m_worker.W_WORK_AREA_ID = Guid.Empty;
                }
                try
                {
                    model_m_worker.W_IS_DELIVERY = int.Parse(W_IS_DELIVERY);
                }
                catch
                {
                    model_m_worker.W_IS_DELIVERY = null;
                }
                try
                {
                    model_m_worker.W_DELIVERY_DATA = DateTime.Parse(W_DELIVERY_DATA);
                }
                catch
                {
                    model_m_worker.W_DELIVERY_DATA = null;
                }
                try
                {
                    model_m_worker.W_IS_PASS_INTERVIEW = int.Parse(W_IS_PASS_INTERVIEW);
                }
                catch
                {
                    model_m_worker.W_IS_PASS_INTERVIEW = null;
                }
                try
                {
                    model_m_worker.W_INTERVIEW_DATA = DateTime.Parse(W_INTERVIEW_DATA);
                }
                catch
                {
                    model_m_worker.W_INTERVIEW_DATA = null;
                }
                try
                {
                    model_m_worker.W_IS_ONBOARD = int.Parse(W_IS_ONBOARD);
                }
                catch
                {
                    model_m_worker.W_IS_ONBOARD = null;
                }
                try
                {
                    model_m_worker.W_ONBOARD_DATA = DateTime.Parse(W_ONBOARD_DATA);
                }
                catch
                {
                    model_m_worker.W_ONBOARD_DATA = null;
                }
                try
                {
                    model_m_worker.W_IS_RESIGNATION = int.Parse(W_IS_RESIGNATION);
                }
                catch
                {
                    model_m_worker.W_IS_RESIGNATION = null;
                }
                try
                {
                    model_m_worker.W_RESIGNATION_DATA = DateTime.Parse(W_RESIGNATION_DATA);
                }
                catch
                {
                    model_m_worker.W_RESIGNATION_DATA = null;
                }
                try
                {
                    model_m_worker.A_GRADUATE_DATA = DateTime.Parse(A_GRADUATE_DATA);

                }
                catch
                {
                    model_m_worker.A_GRADUATE_DATA = null;
                }
                model_m_worker.A_CENSUS = A_CENSUS;
                model_m_worker.A_EDU_BACKGROUND = A_EDU_BACKGROUND;
                model_m_worker.A_HOME_TEL = A_HOME_TEL;
                model_m_worker.A_HOME_ADDRESS = A_HOME_ADDRESS;
                model_m_worker.STATUS = Common.Variables.WORKER_STATUS_ON_HOLD;
                model_m_worker.COMMENTS = COMMENTS;
                model_m_worker.CREATE_USER_ID = session_model_z_user.ID;
                model_m_worker.CREATE_DATETIME = DateTime.Now;
                model_m_worker.UPDATE_USER_ID = session_model_z_user.ID;
                model_m_worker.UPDATE_DATETIME = DateTime.Now;
                model_m_worker.DELETE_FLG = "0";
                dal_m_worker.Add(model_m_worker);
                return RedirectToAction("Index", new { message = "新建成功" });
            }
            catch
            {
                ViewBag.message = "新建失败";
                return View();
            }
        }

        //
        // GET: /Worker/Edit/5

        public ActionResult Edit(string id)
        {
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            ViewBag.area_list = dal_z_parameter.GetModelList("地区");
            ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
            DAL.m_worker dal_m_worker = new DAL.m_worker();
            Models.m_worker model_m_worker = dal_m_worker.GetModel(new Guid(id));
            return View(model_m_worker);
        }

        //
        // POST: /Worker/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, FormCollection collection)
        {
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            DAL.m_worker dal_m_worker = new DAL.m_worker();
            Models.m_worker model_m_worker = dal_m_worker.GetModel(new Guid(id));
            try
            {
                Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
                ViewBag.area_list = dal_z_parameter.GetModelList("地区");
                ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
                // TODO: Add insert logic here
                string B_NAME = collection["B_NAME"].Trim();
                string B_GENDER = collection["B_GENDER"];
                string B_TEL = collection["B_TEL"].Trim();
                string B_ADDRESS = collection["B_ADDRESS"].Trim();
                string B_ID_CARD = collection["B_ID_CARD"].Trim();
                string B_CREATE_AREA_ID = collection["B_CREATE_AREA_ID"];
                string B_EXPIRY_DATA = collection["B_EXPIRY_DATA"];
                string W_WORK_AREA_ID = collection["W_WORK_AREA_ID"];
                string W_IS_DELIVERY = collection["W_IS_DELIVERY"];
                string W_DELIVERY_DATA = collection["W_DELIVERY_DATA"];
                string W_IS_PASS_INTERVIEW = collection["W_IS_PASS_INTERVIEW"];
                string W_INTERVIEW_DATA = collection["W_INTERVIEW_DATA"];
                string W_IS_ONBOARD = collection["W_IS_ONBOARD"];
                string W_ONBOARD_DATA = collection["W_ONBOARD_DATA"];
                string W_IS_RESIGNATION = collection["W_IS_RESIGNATION"];
                string W_RESIGNATION_DATA = collection["W_RESIGNATION_DATA"];
                string A_GRADUATE_DATA = collection["A_GRADUATE_DATA"];
                string A_CENSUS = collection["A_CENSUS"].Trim();
                string A_EDU_BACKGROUND = collection["A_EDU_BACKGROUND"].Trim();
                string A_HOME_TEL = collection["A_HOME_TEL"].Trim();
                string A_HOME_ADDRESS = collection["A_HOME_ADDRESS"].Trim();
                string COMMENTS = collection["COMMENTS"];
                if (B_NAME == "" || B_GENDER == null || B_TEL == "" || B_CREATE_AREA_ID == "" || B_EXPIRY_DATA == "")
                {
                    ViewBag.message = "编辑失败，标红星的字段不能为空或者不选";
                    return View(model_m_worker);
                }
                if (dal_m_worker.isWorkerDuplicate(B_NAME, B_TEL, B_ID_CARD, id))
                {

                    ViewBag.message = "编辑失败，姓名为：" + B_NAME + "，并且联系方式为：" + B_TEL + " 的工友已经存在。请在工友库中查找。";
                    return View(model_m_worker);
                }
                model_m_worker.B_NAME = B_NAME;
                model_m_worker.B_GENDER = B_GENDER;
                model_m_worker.B_TEL = B_TEL;
                model_m_worker.B_ADDRESS = B_ADDRESS;
                model_m_worker.B_ID_CARD = B_ID_CARD;
                model_m_worker.B_CREATE_AREA_ID = new Guid(B_CREATE_AREA_ID);
                model_m_worker.B_ASSOCIATED_USER_ID = session_model_z_user.ID;
                model_m_worker.B_ASSOCIATED_DATA = DateTime.Now;
                model_m_worker.B_EXPIRY_DATA = DateTime.Parse(B_EXPIRY_DATA);
                try
                {
                    model_m_worker.W_WORK_AREA_ID = new Guid(W_WORK_AREA_ID);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_IS_DELIVERY = int.Parse(W_IS_DELIVERY);
                    if (model_m_worker.W_IS_DELIVERY == 1 && model_m_worker.STATUS == Common.Variables.WORKER_STATUS_ON_HOLD)
                    {
                        model_m_worker.STATUS = Common.Variables.WORKER_STATUS_IS_DELIVERY;
                    }
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_DELIVERY_DATA = DateTime.Parse(W_DELIVERY_DATA);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_IS_PASS_INTERVIEW = int.Parse(W_IS_PASS_INTERVIEW);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_INTERVIEW_DATA = DateTime.Parse(W_INTERVIEW_DATA);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_IS_ONBOARD = int.Parse(W_IS_ONBOARD);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_ONBOARD_DATA = DateTime.Parse(W_ONBOARD_DATA);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_IS_RESIGNATION = int.Parse(W_IS_RESIGNATION);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.W_RESIGNATION_DATA = DateTime.Parse(W_RESIGNATION_DATA);
                }
                catch
                {
                }
                try
                {
                    model_m_worker.A_GRADUATE_DATA = DateTime.Parse(A_GRADUATE_DATA);

                }
                catch
                {
                }
                model_m_worker.A_CENSUS = A_CENSUS;
                model_m_worker.A_EDU_BACKGROUND = A_EDU_BACKGROUND;
                model_m_worker.A_HOME_TEL = A_HOME_TEL;
                model_m_worker.A_HOME_ADDRESS = A_HOME_ADDRESS;
                //model_m_worker.STATUS = Common.Variables.WORKER_STATUS_ON_HOLD;
                model_m_worker.COMMENTS = COMMENTS;
                model_m_worker.UPDATE_USER_ID = session_model_z_user.ID;
                model_m_worker.UPDATE_DATETIME = DateTime.Now;
                model_m_worker.DELETE_FLG = "0";
                dal_m_worker.Update(model_m_worker);
                return RedirectToAction("Index", new { message = "编辑成功" });
            }
            catch
            {
                ViewBag.message = "编辑失败";
                return View(model_m_worker);
            }
        }

        //
        // POST: /Worker/Delete/5

        [HttpPost]
        public ActionResult Delete(String page, String field, String condition, String search, String by, FormCollection collection)
        {
            try
            {
                String IDlist = collection["id[]"];
                IDlist = IDlist.Replace(",", "','");
                IDlist = "'" + IDlist + "'";
                DAL.m_worker dal_m_worker = new DAL.m_worker();
                dal_m_worker.DeleteList(IDlist);
                return RedirectToAction("Index", new { message = "删除成功", page = page, field = field, condition = condition, search = search, by = by });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "删除失败", page = page, field = field, condition = condition, search = search, by = by });
            }
        }

        //
        // GET: /Worker/GiveUp/5

        public ActionResult GiveUp(string id, String page, String field, String condition, String search, String by)
        {
            try
            {
                DAL.m_worker dal_m_worker = new DAL.m_worker();
                //dal_m_worker.UpdataStatus(new Guid(id), Common.Variables.WORKER_STATUS_IN_POOL, null);
                Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
                dal_m_worker.saveHistory(new Guid(id), session_model_z_user.ID);
                return RedirectToAction("Index", new { message = "放弃成功", page = page, field = field, condition = condition, search = search, by = by });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "放弃失败", page = page, field = field, condition = condition, search = search, by = by });
            }
        }

        [HttpPost]
        public ActionResult GiveUp(String page, String field, String condition, String search, String by, FormCollection collection)
        {
            try
            {
                DAL.m_worker dal_m_worker = new DAL.m_worker();
                Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
                String[] IDList = collection["id[]"].ToString().Split(',');
                foreach (String ID in IDList)
                {
                    dal_m_worker.saveHistory(new Guid(ID), session_model_z_user.ID);
                }
                /*
                IDlist = IDlist.Replace(",", "','");
                IDlist = "'" + IDlist + "'";
                dal_m_worker.UpdataStatus(IDlist, Common.Variables.WORKER_STATUS_IN_POOL, null);
                 * */
                return RedirectToAction("Index", new { message = "放弃成功", page = page, field = field, condition = condition, search = search, by = by });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "放弃失败", page = page, field = field, condition = condition, search = search, by = by });
            }
        }

        public ActionResult FollowUp(string id, String page, String field, String condition, String search, String by)
        {
            try
            {
                DAL.m_worker dal_m_worker = new DAL.m_worker();
                Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
                dal_m_worker.followUp(new Guid(id), session_model_z_user.ID);
                return RedirectToAction("Index", new { message = "更新最近跟踪时间成功", page = page, field = field, condition = condition, search = search, by = by });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "更新最近跟踪时间失败", page = page, field = field, condition = condition, search = search, by = by });
            }
        }

        public ActionResult ExportWorker(String page, String field, String condition, String search, String by)
        {
            try
            {
                DAL.m_worker dal_m_worker = new DAL.m_worker();
                DataSet ds = dal_m_worker.GetList(field, condition, search, by, false);
                DataTable table = ds.Tables[0];
                MemoryStream ms = DAL.NpoiExcel.RenderWorkerTableToExcelWorkers(table) as MemoryStream;
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename=我的工友导出" + DateTime.Now.ToString("yyyy_MM_dd HH_mm") + ".xls"));
                Response.BinaryWrite(ms.ToArray());
                Response.End();
                ms.Close();
                ms.Dispose();
                return RedirectToAction("Index", new { message = "导出成功", page = page, field = field, condition = condition, search = search, by = by });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "导出失败", page = page, field = field, condition = condition, search = search, by = by });
            }

        }

        public ActionResult ImportWorker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportWorker(HttpPostedFileBase excel, FormCollection collection)
        {
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            if (excel.ContentLength > 0)
            {
                try
                {
                    DataTable table = DAL.NpoiExcel.RenderDataTableFromExcel(excel.InputStream, "导入数据", 0);
                    DAL.m_worker_excel_import dal_m_worker_excel_import = new DAL.m_worker_excel_import();
                    ViewBag.ImportResult = dal_m_worker_excel_import.getWorkerImportList(table, false, session_model_z_user.ID);
                    ViewBag.message = "导入文件成功";
                }
                catch (Exception ex)
                {
                    ViewBag.ImportResult = "";
                    ViewBag.message = Common.Common.getImportErrorMessage(ex);
                }
                //var fileName = Path.GetFileName(excel.FileName);
                //var path = Path.Combine(Server.MapPath("~/Uploads/excel"), fileName);
                //excel.SaveAs(path);
            }
            return View();
        }


    }
}
