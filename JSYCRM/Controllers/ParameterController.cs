using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JSYCRM.Filters;

namespace JSYCRM.Controllers
{
    [Authentication]
    public class ParameterController : Controller
    {

        public ActionResult Index(String Name, String message)
        {
            Name = HttpUtility.UrlDecode(Name, System.Text.Encoding.UTF8);
            if (Name == "" || Name == null)
            {
                ViewBag.Name = "分公司";
            }
            else
            {
                ViewBag.Name = Name;
            }
            if (message != null && message != "")
            {
                ViewBag.message = message;
            }
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            List<Models.z_parameter> z_parameter_list = dal_z_parameter.GetModelList(ViewBag.Name);
            return View(z_parameter_list);
        }

        [HttpPost]
        public ActionResult Delete(String Name, FormCollection collection)
        {
            Name = HttpUtility.UrlDecode(Name, System.Text.Encoding.UTF8);
            try
            {
                String IDlist = collection["parameter_id[]"];
                IDlist = IDlist.Replace(",", "','");
                IDlist = "'" + IDlist + "'";
                DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
                dal_z_parameter.DeleteList(IDlist);
                return RedirectToAction("Index", new { Name = Name, message = "删除成功" });   
            }
            catch
            {
                return RedirectToAction("Index", new { Name = Name, message = "删除失败" });   
            }
        }

        public ActionResult Create(String Name)
        {
            Name = HttpUtility.UrlDecode(Name, System.Text.Encoding.UTF8);
            ViewBag.Name = Name;
            return View();
        }


        [HttpPost]
        public ActionResult Create(String Name, FormCollection collection)
        {
            Name = HttpUtility.UrlDecode(Name, System.Text.Encoding.UTF8);
            try
            {
                String VALUE = collection["VALUE"].Trim();
                String DESCRIPTION = collection["DESCRIPTION"].Trim();
                if (VALUE == null || VALUE == "")
                {
                    ViewBag.Name = Name;
                    ViewBag.message = "新建失败，名称不能为空";
                    return View();
                }
                // TODO: Add insert logic here
                Models.z_parameter model_z_parameter = new Models.z_parameter();
                model_z_parameter.ID = Guid.NewGuid();
                model_z_parameter.TYPE = "";
                model_z_parameter.NAME = Name;
                model_z_parameter.VALUE = VALUE;
                model_z_parameter.DESCRIPTION = DESCRIPTION;
                model_z_parameter.CREATE_USER_ID = ViewBag.model_z_user.ID;
                model_z_parameter.CREATE_DATETIME = DateTime.Now;
                model_z_parameter.UPDATE_USER_ID = ViewBag.model_z_user.ID;
                model_z_parameter.UPDATE_DATETIME = DateTime.Now;
                model_z_parameter.DELETE_FLG = "0";
                DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
                dal_z_parameter.Add(model_z_parameter);
                return RedirectToAction("Index", new { Name = Name, message =  "新建成功"});       
            }
            catch
            {
                ViewBag.Name = Name;
                ViewBag.message = "新建失败";
                return View();
            }
        }

        public ActionResult Edit(String Name, String ID)
        {
            Name = HttpUtility.UrlDecode(Name, System.Text.Encoding.UTF8);
            ViewBag.Name = Name;
            DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
            Models.z_parameter model_z_parameter = dal_z_parameter.GetModel(new Guid(ID));
            return View(model_z_parameter);
        }

        [HttpPost]
        public ActionResult Edit(String Name, String ID, FormCollection collection)
        {
            Name = HttpUtility.UrlDecode(Name, System.Text.Encoding.UTF8);
            try
            {
                DAL.z_parameter dal_z_parameter = new DAL.z_parameter();
                Models.z_parameter model_z_parameter = dal_z_parameter.GetModel(new Guid(ID));
                String VALUE = collection["VALUE"].Trim();
                String DESCRIPTION = collection["DESCRIPTION"].Trim();
                if (VALUE == null || VALUE == "")
                {
                    ViewBag.Name = Name;
                    ViewBag.message = "编辑失败，名称不能为空";
                    return View(model_z_parameter);
                }
                model_z_parameter.VALUE = VALUE;
                model_z_parameter.DESCRIPTION = DESCRIPTION;
                model_z_parameter.UPDATE_USER_ID = ViewBag.model_z_user.ID;
                model_z_parameter.UPDATE_DATETIME = DateTime.Now;
                dal_z_parameter.Update(model_z_parameter);
                return RedirectToAction("Index", new { Name = Name, message = "编辑成功" });
            }
            catch
            {
                ViewBag.Name = Name;
                ViewBag.message = "编辑失败";
                return View();
            }
        }

    }
}
