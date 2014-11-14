using JSYCRM.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSYCRM.Controllers
{
    [Authentication]
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(String message, String page, String name)
        {
            int pageNum = Common.Common.getPageNum(page);
            DAL.z_user dal_z_user = new DAL.z_user();
            if (message != null && message != "")
            {
                ViewBag.message = message;
            }
            List<Models.z_user> z_user_list = dal_z_user.GetListModelByPage(name, pageNum * 15 + 1, (pageNum + 1) * 15);
            ViewBag.recordCount = dal_z_user.GetRecordCount(name);
            ViewBag.page = pageNum + 1;
            ViewBag.pageNum = Math.Ceiling((double)ViewBag.recordCount / (double)15);
            ViewBag.name = name;
            return View(z_user_list);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(String id)
        {
            try
            {
                DAL.z_user dal_z_user = new DAL.z_user();
                Models.z_user model_z_user = dal_z_user.GetModel(new Guid(id));
                DAL.z_role dal_z_role = new DAL.z_role();
                List<Models.z_role> z_role_list = dal_z_role.GetModelList(new Guid(id));
                ViewBag.z_role_list = z_role_list;
                return View(model_z_user);
            }
            catch
            {
                ViewBag.message = "查看失败，员工不存在";
                return View();
            }
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            DAL.z_role dal_z_role = new DAL.z_role();
            ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
            ViewBag.position_list = dal_z_parameter.GetModelList("职位");
            ViewBag.role_list = dal_z_role.GetModelList();
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            DAL.z_user dal_z_user = new DAL.z_user();
            Models.z_user model_z_user = new Models.z_user();
            DAL.z_r_user_role dal_z_r_user_role = new DAL.z_r_user_role();
            try
            {
                DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
                DAL.z_role dal_z_role = new DAL.z_role();
                ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
                ViewBag.position_list = dal_z_parameter.GetModelList("职位");
                ViewBag.role_list = dal_z_role.GetModelList();
                // TODO: Add insert logic here
                string USER_CD = collection["USER_CD"].Trim();
                string PASSWORD = collection["PASSWORD"].Trim();
                string PASSWORD_RE = collection["PASSWORD_RE"].Trim();
                string LAST_NAME = collection["LAST_NAME"].Trim();
                string GENDER = collection["GENDER"];
                string EMAIL = collection["EMAIL"].Trim();
                string COMPANY_TEL = collection["COMPANY_TEL"].Trim();
                string MOBILE_NUM = collection["MOBILE_NUM"].Trim();
                string COMPANY_ID = collection["COMPANY_ID"];
                string POSITION_ID = collection["POSITION_ID"];
                string DESCRIPTION = collection["DESCRIPTION"].Trim();
                string ROLE = collection["ROLE"];
                if (USER_CD == "" || PASSWORD == "" || PASSWORD_RE == "" || LAST_NAME == "" || GENDER == null || EMAIL == "" || MOBILE_NUM == "" || COMPANY_ID == null || POSITION_ID == null || ROLE == null)
                {
                    ViewBag.message = "新建失败，标红星的字段不能为空或者不选";
                    return View();
                }
                if (PASSWORD != PASSWORD_RE)
                {
                    ViewBag.message = "新建失败，两次输入的密码不一致";
                    return View();
                }
                if (dal_z_user.isCdDuplicate(USER_CD))
                {

                    ViewBag.message = "新建失败，账号已经存在";
                    return View();
                }
                model_z_user.ID = Guid.NewGuid();
                model_z_user.USER_CD = USER_CD;
                model_z_user.PASSWORD = Common.Common.MD5(PASSWORD);
                model_z_user.FIRST_NAME = "";
                model_z_user.LAST_NAME = LAST_NAME;
                model_z_user.GENDER = GENDER;
                model_z_user.EMAIL = EMAIL;
                model_z_user.COMPANY_TEL = COMPANY_TEL;
                model_z_user.COMPANY_ID = new Guid(COMPANY_ID);
                model_z_user.MOBILE_NUM = MOBILE_NUM;
                model_z_user.POSITION_ID = new Guid(POSITION_ID);
                model_z_user.DESCRIPTION = DESCRIPTION;
                model_z_user.CREATE_DATETIME = DateTime.Now;
                model_z_user.UPDATE_DATETIME = DateTime.Now;
                model_z_user.DELETE_FLG = "0";
                dal_z_user.Add(model_z_user);
                dal_z_r_user_role.Add(model_z_user.ID.ToString(), ROLE);
                return RedirectToAction("Index", new { message = "新建成功" });
            }
            catch(Exception ex)
            {
                dal_z_user.Delete(model_z_user.ID);
                dal_z_r_user_role.DeleteRoleByUserID(model_z_user.ID.ToString());
                ViewBag.message = "新建失败";
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(String id)
        {
            DAL.z_user dal_z_user = new DAL.z_user();
            Models.z_user model_z_user = dal_z_user.GetModel(new Guid(id));
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            DAL.z_role dal_z_role = new DAL.z_role();
            ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
            ViewBag.position_list = dal_z_parameter.GetModelList("职位");
            ViewBag.role_list = dal_z_role.GetModelList();
            ViewBag.role_list_user = dal_z_role.GetModelList(new Guid(id));
            return View(model_z_user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(String id, FormCollection collection)
        {
            DAL.z_user dal_z_user = new DAL.z_user();
            Models.z_user model_z_user = dal_z_user.GetModel(new Guid(id));
            DAL.z_r_user_role dal_z_r_user_role = new DAL.z_r_user_role();
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            DAL.z_role dal_z_role = new DAL.z_role();
            ViewBag.company_list = dal_z_parameter.GetModelList("分公司");
            ViewBag.position_list = dal_z_parameter.GetModelList("职位");
            ViewBag.role_list = dal_z_role.GetModelList();
            ViewBag.role_list_user = dal_z_role.GetModelList(new Guid(id));
            try
            {
                // TODO: Add insert logic here
                string USER_CD = collection["USER_CD"].Trim();
                string PASSWORD = collection["PASSWORD"].Trim();
                string PASSWORD_RE = collection["PASSWORD_RE"].Trim();
                string LAST_NAME = collection["LAST_NAME"].Trim();
                string GENDER = collection["GENDER"];
                string EMAIL = collection["EMAIL"].Trim();
                string COMPANY_TEL = collection["COMPANY_TEL"].Trim();
                string MOBILE_NUM = collection["MOBILE_NUM"].Trim();
                string COMPANY_ID = collection["COMPANY_ID"];
                string POSITION_ID = collection["POSITION_ID"];
                string DESCRIPTION = collection["DESCRIPTION"].Trim();
                string ROLE = collection["ROLE"];
                if (USER_CD == "" || LAST_NAME == "" || GENDER == null || EMAIL == "" || MOBILE_NUM == "" || COMPANY_ID == null || POSITION_ID == null || ROLE == null)
                {
                    ViewBag.message = "编辑失败，标红星的字段不能为空或者不选";
                    return View(model_z_user);
                }
                if (PASSWORD != "" && PASSWORD != PASSWORD_RE)
                {
                    ViewBag.message = "编辑失败，两次输入的密码不一致";
                    return View(model_z_user);
                }
                if (dal_z_user.isCdDuplicate(USER_CD, model_z_user.ID.ToString()))
                {
                    ViewBag.message = "编辑失败，账号已经存在";
                    return View(model_z_user);
                }
                model_z_user.USER_CD = USER_CD;
                if (PASSWORD != "")
                {
                    model_z_user.PASSWORD = Common.Common.MD5(PASSWORD);
                }
                model_z_user.LAST_NAME = LAST_NAME;
                model_z_user.GENDER = GENDER;
                model_z_user.EMAIL = EMAIL;
                model_z_user.COMPANY_TEL = COMPANY_TEL;
                model_z_user.COMPANY_ID = new Guid(COMPANY_ID);
                model_z_user.MOBILE_NUM = MOBILE_NUM;
                model_z_user.POSITION_ID = new Guid(POSITION_ID);
                model_z_user.DESCRIPTION = DESCRIPTION;
                model_z_user.UPDATE_DATETIME = DateTime.Now;
                dal_z_user.Update(model_z_user);
                dal_z_r_user_role.DeleteRoleByUserID(model_z_user.ID.ToString());
                dal_z_r_user_role.Add(model_z_user.ID.ToString(), ROLE);
                return RedirectToAction("Index", new { message = "编辑成功" });
            }
            catch
            {
                ViewBag.message = "编辑失败";
                return View(model_z_user);
            }
        }

        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            try
            {
                String IDlist = collection["user_id[]"];
                IDlist = IDlist.Replace(",", "','");
                IDlist = "'" + IDlist + "'";
                DAL.z_user dal_z_user = new DAL.z_user();
                dal_z_user.DeleteList(IDlist);
                return RedirectToAction("Index", new { message = "删除成功" });  
            }
            catch
            {
                return RedirectToAction("Index", new { message = "删除失败" });
            }
        }
    }
}
