using JSYCRM.Common;
using JSYCRM.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSYCRM.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [HttpGet]
        [Authentication]
        public ActionResult MyAccount()
        {
            return View();
        }

        [HttpPost]
        [Authentication]
        public ActionResult MyAccount(FormCollection collection)
        {
            try
            {
                var EMAIL = collection["EMAIL"].Trim();
                var MOBILE_NUM = collection["MOBILE_NUM"].Trim();
                var COMPANY_TEL = collection["COMPANY_TEL"].Trim();
                var PASSWORD = collection["PASSWORD"].Trim();
                var PASSWORD_RE = collection["PASSWORD_RE"].Trim();
                Models.z_user model_z_user = ViewBag.model_z_user;
                if (EMAIL == null || EMAIL == "" || MOBILE_NUM == "" || MOBILE_NUM == null)
                {
                    ViewBag.message = "修改失败，邮箱和手机号码不能为空";
                    return View(); 
                }
                if (PASSWORD != null && PASSWORD != "")
                {
                    if (PASSWORD == PASSWORD_RE)
                    {
                        model_z_user.PASSWORD = Common.Common.MD5(PASSWORD);
                    }
                    else
                    {
                        ViewBag.message = "修改失败，两次输入密码不匹配";
                        return View();
                    }
                }
                model_z_user.EMAIL = EMAIL;
                model_z_user.COMPANY_TEL = COMPANY_TEL;
                model_z_user.MOBILE_NUM = MOBILE_NUM;
                DAL.z_user dal_z_user = new DAL.z_user();
                dal_z_user.Update(model_z_user);
                ViewBag.message = "修改成功";
                return View();
            }
            catch
            {
                ViewBag.message = "修改失败";
                return View();
            }
        }

        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Login(String returnUrl)
        {
            DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
            List<Models.m_announcement> m_announcement_list = dal_m_announcement.GetListModelByPage(true);
            try
            {
                //Remember me login.
                DAL.z_user dal_user = new DAL.z_user();
                if (Request.Cookies["YourAppLogin"] != null)
                {
                    string userAccount = Request.Cookies["YourAppLogin"].Values["loginUserAccount"];
                    if (userAccount != null)
                    {
                        Common.Encrypt Encrypt = new Common.Encrypt();
                        Models.z_user model_z_user = dal_user.GetLoginModel(Encrypt.DecryptString(userAccount.Trim()));
                        if (model_z_user != null)
                        {
                            DAL.z_menu dal_z_menu = new DAL.z_menu();
                            List<Models.z_menu> z_menu_list = dal_z_menu.GetMenuModelListByUserID(model_z_user.ID);
                            Session.Add("loginUserMenuList", z_menu_list);
                            Session.Add("loginUserModel", model_z_user);
                            if (!String.IsNullOrEmpty(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
                ViewBag.errorMessage = "请先登录...";
                return View(m_announcement_list);
            }
            catch
            {
                ViewBag.errorMessage = "请先登录...";
                return View(m_announcement_list);
            }
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
            List<Models.m_announcement> m_announcement_list = dal_m_announcement.GetListModelByPage(true);
            try
            {
                var name = collection["name"].Trim();
                var password = collection["password"].Trim();
                var rememberMe = collection["rememberMe"];
                var valicode = collection["valicode"].Trim();
                var returnUrl = collection["returnUrl"];
                //验证验证码
                if (Session["ValidateCode"].ToString() != valicode)
                {
                    ViewBag.errorMessage = "验证码不正确";
                    return View(m_announcement_list);
                }
                //此处验证用户名、密码
                DAL.z_user dal_user = new DAL.z_user();
                Models.z_user model_z_user = dal_user.GetLoginModel(name.Trim(), Common.Common.MD5(password.Trim()));
                if (model_z_user == null)
                {
                    ViewBag.errorMessage = "用户名或密码不正确";
                    return View(m_announcement_list);
                }
                //验证成功
                if (rememberMe == "on")
                {
                    HttpCookie cookie = new HttpCookie("YourAppLogin");
                    Common.Encrypt Encrypt = new Common.Encrypt();
                    cookie.Values.Add("loginUserAccount", Encrypt.EncryptString(name.Trim()));
                    cookie.Expires = DateTime.Now.AddDays(5);
                    Response.Cookies.Add(cookie);
                }
                DAL.z_menu dal_z_menu = new DAL.z_menu();
                List<Models.z_menu> z_menu_list = dal_z_menu.GetMenuModelListByUserID(model_z_user.ID);
                Session.Add("loginUserMenuList", z_menu_list);
                Session.Add("loginUserModel", model_z_user);
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                ViewBag.errorMessage = "验证码不正确";
                return View(m_announcement_list);
            }
        }

        [HttpGet]
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            if (Request.Cookies["YourAppLogin"] != null)
            {
                HttpCookie myCookie = new HttpCookie("YourAppLogin");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return View();
        }

        public ActionResult TestRemoveSession()
        {
            Session.RemoveAll();
            return View();
        }

    }
}
