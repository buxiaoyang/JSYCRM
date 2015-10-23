using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSYCRM.Controllers
{
    public class SimulatorController : Controller
    {
        //
        // GET: /Simulator/

        public FileResult Save()
        {
            string jsonString = Request.Form["data"];
            Bitmap imgFooter = new Bitmap(System.IO.Path.Combine(Server.MapPath("~"), "Images", "Print-Save-Footer-Cor.jpg"));
            Bitmap imgTarget = Common.Image.BuildImageFromJsonSource(jsonString, imgFooter);
            //response image to clent
            Response.AddHeader("Content-Disposition", "attachment; filename=\"Decotal_Tile_Simulator_" + DateTime.Now.ToShortDateString() + ".png\""); 
            MemoryStream stream = new MemoryStream();
            imgTarget.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            Byte[] bytes = stream.ToArray();
            try
            {
                Models.t_simulator model_t_simulator = new Models.t_simulator();
                model_t_simulator.ID = Guid.NewGuid();
                model_t_simulator.IP = Request.UserHostAddress;
                model_t_simulator.BROWSER = Request.Browser.Browser + " " + Request.Browser.MajorVersion;
                model_t_simulator.LANGUAGE = string.Join(", ", Request.UserLanguages);
                model_t_simulator.DATA = jsonString;
                model_t_simulator.OPERATION = "Save";
                model_t_simulator.CREATED = DateTime.Now;
                new DAL.t_simulator().Add(model_t_simulator);
            }
            catch { }
            return File(bytes, "image/png");
        }

        public ActionResult Print()
        {
            string jsonString = Request.Form["data"];
            Bitmap imgFooter = new Bitmap(System.IO.Path.Combine(Server.MapPath("~"), "Images", "Print-Save-Footer-Cor.jpg"));
            Bitmap imgTarget = Common.Image.BuildImageFromJsonSource(jsonString, imgFooter);
            MemoryStream stream = new MemoryStream();
            imgTarget.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            Byte[] bytes = stream.ToArray();
            ViewData["picture"] = Convert.ToBase64String(bytes);
            try
            {
                Models.t_simulator model_t_simulator = new Models.t_simulator();
                model_t_simulator.ID = Guid.NewGuid();
                model_t_simulator.IP = Request.UserHostAddress;
                model_t_simulator.BROWSER = Request.Browser.Browser + " " + Request.Browser.MajorVersion;
                model_t_simulator.LANGUAGE = string.Join(", ", Request.UserLanguages);
                model_t_simulator.DATA = jsonString;
                model_t_simulator.OPERATION = "Print";
                model_t_simulator.CREATED = DateTime.Now;
                new DAL.t_simulator().Add(model_t_simulator);
            }
            catch { }
            return View();
        }

    }
}
