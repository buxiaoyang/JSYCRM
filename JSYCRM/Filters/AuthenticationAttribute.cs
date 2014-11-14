using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JSYCRM.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Models.z_user model_z_user = (Models.z_user)filterContext.HttpContext.Session["loginUserModel"];
            List<Models.z_menu> z_menu_list = (List<Models.z_menu>)filterContext.HttpContext.Session["loginUserMenuList"];
            if (model_z_user != null && z_menu_list != null)
            {
                //检查是否有权限
                String controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                Boolean hasPermission = false;
                foreach (Models.z_menu item in z_menu_list)
                {
                    if (item.VALUE.IndexOf("/" + controllerName) >= 0)
                    {
                        hasPermission = true;
                    }
                }
                if (hasPermission)
                {
                    filterContext.Controller.ViewBag.model_z_user = model_z_user;
                    filterContext.Controller.ViewBag.z_menu_list = z_menu_list;
                }
                else
                { 
                    //没有权限
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "NoPermission",
                        ViewData = filterContext.Controller.ViewData
                    };
                }
                //检查是否有权限
            }
            else  //Session lost
            { 
                //Remember me login.
                if (filterContext.HttpContext.Request.Cookies["YourAppLogin"] != null)
                {
                    DAL.z_user dal_user = new DAL.z_user();
                    string userAccount = filterContext.HttpContext.Request.Cookies["YourAppLogin"].Values["loginUserAccount"];
                    if (userAccount != null)
                    {
                        Common.Encrypt Encrypt = new Common.Encrypt();
                        model_z_user = dal_user.GetLoginModel(Encrypt.DecryptString(userAccount.Trim()));
                        if (model_z_user != null)
                        {
                            DAL.z_menu dal_z_menu = new DAL.z_menu();
                            z_menu_list = dal_z_menu.GetMenuModelListByUserID(model_z_user.ID);
                            filterContext.HttpContext.Session.Remove("loginUserMenuList");
                            filterContext.HttpContext.Session.Remove("loginUserModel");
                            filterContext.HttpContext.Session.Add("loginUserMenuList", z_menu_list);
                            filterContext.HttpContext.Session.Add("loginUserModel", model_z_user);
                            //检查是否有权限
                            String controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                            Boolean hasPermission = false;
                            foreach (Models.z_menu item in z_menu_list)
                            {
                                if (item.VALUE.IndexOf("/" + controllerName) >= 0)
                                {
                                    hasPermission = true;
                                }
                            }
                            if (hasPermission)
                            {
                                filterContext.Controller.ViewBag.model_z_user = model_z_user;
                                filterContext.Controller.ViewBag.z_menu_list = z_menu_list;
                            }
                            else
                            {
                                //没有权限
                                filterContext.Result = new ViewResult
                                {
                                    ViewName = "NoPermission",
                                    ViewData = filterContext.Controller.ViewData
                                };
                            }
                            //检查是否有权限
                        }
                    }
                }
                else  //没有session也没有cookies
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "SessionLost",
                        ViewData = filterContext.Controller.ViewData
                    };
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}