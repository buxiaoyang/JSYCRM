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
            return View();
        }

    }
}
