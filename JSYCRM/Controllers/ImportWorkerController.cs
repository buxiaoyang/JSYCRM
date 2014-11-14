using JSYCRM.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace JSYCRM.Controllers
{
    [Authentication]
    public class ImportWorkerController : Controller
    {
        public ActionResult Interview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Interview(HttpPostedFileBase excel, FormCollection collection)
        {
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            if (excel.ContentLength > 0)
            {
                try
                {
                    DataTable table = DAL.NpoiExcel.RenderDataTableFromExcel(excel.InputStream, "导入数据", 0);
                    DAL.m_worker_excel_import dal_m_worker_excel_import = new DAL.m_worker_excel_import();
                    ViewBag.ImportResult = dal_m_worker_excel_import.getWorkerImportListInterview(table, session_model_z_user.ID);
                    ViewBag.message = "导入文件成功";
                }
                catch (Exception ex)
                {
                    ViewBag.ImportResult = "";
                    ViewBag.message = Common.Common.getImportErrorMessage(ex);
                }
            }
            return View();
        }

        public ActionResult InWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InWork(HttpPostedFileBase excel, FormCollection collection)
        {
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            if (excel.ContentLength > 0)
            {
                try
                {
                    DataTable table = DAL.NpoiExcel.RenderDataTableFromExcel(excel.InputStream, "导入数据", 0);
                    DAL.m_worker_excel_import dal_m_worker_excel_import = new DAL.m_worker_excel_import();
                    ViewBag.ImportResult = dal_m_worker_excel_import.getWorkerImportListInWork(table, session_model_z_user.ID);
                    ViewBag.message = "导入文件成功";
                }
                catch (Exception ex)
                {
                    ViewBag.ImportResult = "";
                    ViewBag.message = Common.Common.getImportErrorMessage(ex);
                }
            }
            return View();
        }

    }
}
