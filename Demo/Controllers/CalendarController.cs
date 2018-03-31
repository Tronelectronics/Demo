using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateCalendar(DateRange dr)
        {
            var result = new
            {

            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}