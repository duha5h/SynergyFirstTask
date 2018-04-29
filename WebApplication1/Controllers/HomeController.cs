using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData()
        {

            var services = new Services().GetData();
            JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult DeleteService(int SERVICEID)
        {
            
            var services = new Hotel().Delete(SERVICEID);
            JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult AddData(FormCollection formCollection)
        {
            var servType = formCollection["servType"];
            var servName = formCollection["servName"];
            var country = formCollection["country"];
            var city = formCollection["city"];

            if(string.Equals(servType, "Hotel"))
            {
                var services = new Hotel().Add(new Hotel(servName, city, country));
                JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }
            else if (string.Equals(servType, "Transport"))
            {
                var services = new Transport().Add(new Transport(servName, city, country));
                JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }
            else if (string.Equals(servType, "Guide"))
            {
                var services = new Guide().Add(new Guide(servName, city, country));
                JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }

            return new JsonResult();
        }


        [HttpPost]
        public JsonResult UpdateData(string servType, string servName, string country, string city, int SERVICEID)
        {
           
            if (string.Equals(servType, "Hotel"))
            {
                var services = new Hotel().Edit(SERVICEID,new Hotel(servName, city, country));
                JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }
            else if (string.Equals(servType, "Transport"))
            {
                var services = new Transport().Edit(SERVICEID, new Transport(servName, city, country));
                JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }
            else if (string.Equals(servType, "Guide"))
            {
                var services = new Guide().Edit(SERVICEID, new Guide(servName, city, country));
                JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }

            return new JsonResult();
        }

    }


}