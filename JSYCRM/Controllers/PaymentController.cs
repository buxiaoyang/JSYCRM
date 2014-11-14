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
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        public ActionResult Index(string area, string associated_user, string start_time, string end_time)
        {
            DAL.m_worker dal_m_worker = new DAL.m_worker();
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            //判断是否有管理员和经理权限
            DAL.z_role dal_z_role = new DAL.z_role();
            List<Models.z_role> z_role_list = dal_z_role.GetModelList(session_model_z_user.ID);
            Boolean canAddorImport = false;
            foreach (Models.z_role model_z_role in z_role_list)
            {
                if (model_z_role.NAME == "管理员" || model_z_role.NAME == "经理")
                {
                    canAddorImport = true;
                }
            }
            ViewBag.canAddorImport = canAddorImport;
            //判断是否有管理员和经理权限
            if (!canAddorImport)
            {
                associated_user = session_model_z_user.ID.ToString();
            }
            DataSet dsChart = dal_m_worker.GetReportChart(area, associated_user, start_time, end_time);
            ViewBag.ReportChart = dsChart.Tables[0];
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            DAL.z_user dal_z_user = new DAL.z_user();
            ViewBag.area_list = dal_z_parameter.GetModelList("地区");
            ViewBag.associated_user_list = dal_z_user.GetListModel();
            ViewBag.area = area;
            ViewBag.associated_user = associated_user;
            ViewBag.start_time = start_time;
            ViewBag.end_time = end_time;
            return View();
        }

        public ActionResult Setting(string area, string company)
        {
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            DAL.m_return_fee_rule dal_m_return_fee_rule = new DAL.m_return_fee_rule();
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            List<Models.z_parameter> area_list = dal_z_parameter.GetModelList("地区");
            List<Models.z_parameter> company_list = dal_z_parameter.GetModelList("分公司");
            ViewBag.area_list = area_list;
            ViewBag.company_list = company_list;
            if (area == null || area == "")
            {
                area = area_list[0].ID.ToString();
            }
            if (company == null || company == "")
            {
                company = company_list[0].ID.ToString();
            }
            ViewBag.area = area;
            ViewBag.company = company;
            List<Models.m_return_fee_rule> m_list = dal_m_return_fee_rule.GetListModel(new Guid(company), new Guid(area));
            return View(m_list);
        }

        [HttpPost]
        public ActionResult Setting(string areaSave, string companySave, FormCollection collection)
        {
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            DAL.m_return_fee_rule dal_m_return_fee_rule = new DAL.m_return_fee_rule();
            dal_m_return_fee_rule.DeleteByUserId(new Guid(companySave), new Guid(areaSave));
            for (int i = 1; i < 7; i++)
            {
                try
                {
                    Models.m_return_fee_rule model_m_return_fee_rule = new Models.m_return_fee_rule();
                    model_m_return_fee_rule.ID = Guid.NewGuid();
                    model_m_return_fee_rule.USER_ID = new Guid(companySave);
                    model_m_return_fee_rule.AREA_ID = new Guid(areaSave);
                    model_m_return_fee_rule.NUMBER = i;
                    model_m_return_fee_rule.TIME_START = DateTime.Parse(collection["DATE_FROM" + i].Trim());
                    model_m_return_fee_rule.TIME_END = DateTime.Parse(collection["DATE_TO" + i].Trim());
                    model_m_return_fee_rule.STATUS = int.Parse(collection["STATUS" + i].Trim());
                    model_m_return_fee_rule.DAYS = int.Parse(collection["DAY" + i].Trim());
                    model_m_return_fee_rule.FEE_MEN = decimal.Parse(collection["MEN" + i].Trim());
                    model_m_return_fee_rule.FEE_WOMEN = decimal.Parse(collection["WOMEN" + i].Trim());
                    model_m_return_fee_rule.COMMENTS = "";
                    model_m_return_fee_rule.CREATE_USER_ID = session_model_z_user.ID;
                    model_m_return_fee_rule.CREATE_DATETIME = DateTime.Now;
                    model_m_return_fee_rule.UPDATE_USER_ID = session_model_z_user.ID;
                    model_m_return_fee_rule.UPDATE_DATETIME = DateTime.Now;
                    model_m_return_fee_rule.DELETE_FLG = "0";
                    dal_m_return_fee_rule.Add(model_m_return_fee_rule);
                }
                catch
                {

                }
            }
            ViewBag.message = "保存成功";
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            List<Models.z_parameter> area_list = dal_z_parameter.GetModelList("地区");
            List<Models.z_parameter> company_list = dal_z_parameter.GetModelList("分公司");
            ViewBag.area_list = area_list;
            ViewBag.company_list = company_list;
            if (areaSave == null || areaSave == "")
            {
                areaSave = area_list[0].ID.ToString();
            }
            if (companySave == null || companySave == "")
            {
                companySave = company_list[0].ID.ToString();
            }
            ViewBag.area = areaSave;
            ViewBag.company = companySave;
            List<Models.m_return_fee_rule> m_list = dal_m_return_fee_rule.GetListModel(new Guid(companySave), new Guid(areaSave));
            return View(m_list);
        }

        public ActionResult Calculate(string area, string company, string message)
        {
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            List<Models.z_parameter> area_list = dal_z_parameter.GetModelList("地区");
            List<Models.z_parameter> company_list = dal_z_parameter.GetModelList("分公司");
            ViewBag.area_list = area_list;
            ViewBag.company_list = company_list;
            if (area == null || area == "")
            {
                area = area_list[0].ID.ToString();
            }
            if (company == null || company == "")
            {
                company = company_list[0].ID.ToString();
            }
            ViewBag.area = area;
            ViewBag.company = company;
            Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
            DAL.m_worker dal_m_worker = new DAL.m_worker();
            DataTable dtReturnFee = dal_m_worker.GetReturnFee(area, new Guid(company));
            ViewBag.ReportChart = dtReturnFee;
            ViewBag.message = message;
            return View();
        }

        public ActionResult ExportCalculate(string area, string company)
        {
            try
            {
                Models.z_user session_model_z_user = (Models.z_user)ViewBag.model_z_user;
                DAL.m_worker dal_m_worker = new DAL.m_worker();
                DataTable dtReturnFee = dal_m_worker.GetReturnFee(area, new Guid(company));
                MemoryStream ms = DAL.NpoiExcel.RenderWorkerTableToExcelFee(dtReturnFee) as MemoryStream;
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename=返费导出" + DateTime.Now.ToString("yyyy_MM_dd HH_mm") + ".xls"));
                Response.BinaryWrite(ms.ToArray());
                Response.End();
                ms.Close();
                ms.Dispose();
                return RedirectToAction("Calculate", new { message = "导出成功", area = area });
            }
            catch
            {
                return RedirectToAction("Calculate", new { message = "导出失败", area = area });
            }
        }
    }
}
