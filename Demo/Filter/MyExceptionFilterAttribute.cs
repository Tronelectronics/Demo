using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Demo.Filter
{
    public class MyExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //获取系统异常消息记录  
            string exceptionMessage = filterContext.Exception.Message;

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                //使用Log4Net记录异常信息  
                Exception exception = filterContext.Exception;

                if (exception != null)
                {
                    //LogHelper.WriteErrorLog(strException, exception);
                }
                else
                {
                    //LogHelper.WriteErrorLog(strException);
                }
            }

            //filterContext.HttpContext.Response.Redirect("~/GlobalErrorPage.html");

            // 不跳转直接返回404页面
            //filterContext.HttpContext.Server.TransferRequest("~/CustomError/Error404");
        }
    }
}