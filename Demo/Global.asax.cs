using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private DemoEntities db = new DemoEntities();

        protected void Application_Error(object sender, EventArgs e)
        {
            string requestUrl = Context.Request.Url.AbsoluteUri;

            var error = Server.GetLastError();
            var httpCode = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;

            string errorPagePath = string.Format("~/CustomError/Http{0}?RequestUrl={1}", httpCode, requestUrl);

            //Context.Response.Redirect(errorPagePath);
            Context.Server.TransferRequest(errorPagePath);

            //Log log = new Log();
            //log.Id = Guid.NewGuid();
            //log.Ip = IpService.GetIPAddressViaSohuAPI();
            //log.Remark = string.Format("Error reason:Http {0}. Request url:{1}", httpCode, requestUrl);
            //log.Time = DateTime.Now;
            //db.Log.Add(log);
            //db.SaveChanges();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
