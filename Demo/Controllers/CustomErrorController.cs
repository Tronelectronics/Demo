using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class CustomErrorController : Controller
    {
        // GET: CustomError
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Http404()
        {
            string requestUrl = this.Request.QueryString["RequestUrl"];

            ViewData["RequestUrl"] = requestUrl;

            //Response.StatusCode = 404;
            return View();
        }

        [HttpGet]
        public ActionResult Http500()
        {
            //Response.StatusCode = 500;
            return View();
        }
    }
}