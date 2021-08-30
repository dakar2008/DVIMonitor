using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using DVIMonitor.Models;
using System.Web.Mvc;
using DVIMonitor.DVIService;

namespace DVIMonitor.Controllers
{
    public class HomeController : Controller
    {
        private monitorSoapClient ds = new monitorSoapClient();
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            string servermappath = Server.MapPath("~/Content/");
            WebClient client = new WebClient();
            if(System.IO.File.Exists(servermappath + "newsfeed.xml"))
            {
                System.IO.File.Delete(servermappath + "newsfeed.xml");
            }
            client.DownloadFile("https://nordjyske.dk/rss/nyheder", servermappath + "newsfeed.xml");
            return View();
        }
        public JsonResult GetDVITempData()
        {
            var data = new { InsideTemp = ds.StockTemp().ToString("N2").Replace(',', '.') + " ºc", InsideHumidity = ds.StockHumidity().ToString("N2").Replace(',', '.') + " %", OutsideTemp = ds.OutdoorTemp().ToString("N2").Replace(',', '.') + " ºc", OutsideHumidity = ds.OutdoorHumidity().ToString("N2").Replace(',', '.') + " %" };

            if (db.DVIServices.Any())
            {
                Models.DVIService dvis = db.DVIServices.FirstOrDefault();
                dvis.InsideTemp = data.InsideTemp;
                dvis.InsideHumitity = data.InsideHumidity;
                dvis.OutsideTemp = data.OutsideTemp;
                dvis.OutsideHumitity = data.OutsideHumidity;
                db.SaveChanges();
            }
            else
            {
                Models.DVIService dvis = new Models.DVIService();
                dvis.InsideTemp = data.InsideTemp;
                dvis.InsideHumitity = data.InsideHumidity;
                dvis.OutsideTemp = data.OutsideTemp;
                dvis.OutsideHumitity = data.OutsideHumidity;
                db.DVIServices.Add(dvis);
                db.SaveChanges();
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDVIItemsUnderMin()
        {
            List<string> itemlist = new List<string>();
            foreach (var item in ds.StockItemsUnderMin())
            {
                itemlist.Add(item);
            }
            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDVIItemsOverMax()
        {
            List<string> itemlist = new List<string>();
            foreach (var item in ds.StockItemsOverMax())
            {
                itemlist.Add(item);
            }
            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDVIItemsMostSold()
        {
            List<string> itemlist = new List<string>();
            foreach (var item in ds.StockItemsMostSold())
            {
                itemlist.Add(item);
            }
            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAPI()
        {
            List<Models.DVIService> dviservicelist = db.DVIServices.ToList();
            return Json(dviservicelist, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult _Footer()
        {
            return PartialView();
        }

        #region Close DB
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}