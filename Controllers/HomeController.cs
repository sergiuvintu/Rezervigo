using Rezervigo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rezervigo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Authorize]
        public ActionResult ReservationsFeed()
        {
           // string start1 = Request["start"];
           // string end1 = Request["end"];
           // DateTime start = DateTime.Parse(start1, null, System.Globalization.DateTimeStyles.RoundtripKind);
            //DateTime end = DateTime.Parse(end1, null, System.Globalization.DateTimeStyles.RoundtripKind);
            var Reservations = db.Reservations.ToList();
            return Json(Reservations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}