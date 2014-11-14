using JSYCRM.Common;
using JSYCRM.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSYCRM.Controllers
{
    
    public class HomeController : Controller
    {
        [Authentication]
        public ActionResult Index()
        {
            DAL.m_announcement dal_m_announcement = new DAL.m_announcement();
            List<Models.m_announcement> m_announcement_list = dal_m_announcement.GetListModelByPage(false);
            return View(m_announcement_list);
        }

        [HttpPost]
        [Authentication]
        public ActionResult Upload(string dir, string fileSize)
        {
            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

            //最大文件大小
            int maxSize = 1000000;
            if (!String.IsNullOrEmpty(fileSize))
            {
                try
                {
                    maxSize = int.Parse(fileSize);
                }
                catch
                { 
                
                }
            }
            HttpPostedFileBase imgFile = this.Request.Files["imgFile"];
            if (imgFile == null)
            {
                Hashtable hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "请选择文件。";
                return Json(hash, "text/html; charset=UTF-8");

            }

            String dirPath = this.Request.PhysicalApplicationPath;
            if (!Directory.Exists(dirPath))
            {
                Hashtable hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "上传目录不存在。";
                return Json(hash, "text/html; charset=UTF-8");
            }

            string dirName = dir;
            if (String.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                Hashtable hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "目录名不正确。";
                return Json(hash, "text/html; charset=UTF-8");
            }

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                Hashtable hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "上传文件大小超过限制。";
                return Json(hash, "text/html; charset=UTF-8");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                Hashtable hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。";
                return Json(hash, "text/html; charset=UTF-8");
            }

            //创建文件夹
            dirPath += "Uploads\\" +  dirName + "\\";
            string saveUrl = "/Uploads/" + dirName + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "\\";
            saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = dirPath + newFileName;

            imgFile.SaveAs(filePath);

            String fileUrl = saveUrl + newFileName;

            Hashtable hashSucceed = new Hashtable();
            hashSucceed["error"] = 0;
            hashSucceed["url"] = fileUrl;
            return Json(hashSucceed);
        }


        public ActionResult Error()
        {
            return View("Error");
        }

    }
}
