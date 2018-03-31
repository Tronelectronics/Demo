using Demo.Filter;
using System.Web;
using System.Web.Mvc;

namespace Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());

            //如果要更改默认的错误视图，需要设置View属性
            //filters.Add(new HandleErrorAttribute() { View = "~/Views/Error/CustomError.cshtml" });

            // 注册自定义Exception过滤器  
            filters.Add(new MyExceptionFilterAttribute() { View = "~/Views/Error/CustomError.cshtml" });
        }
    }
}
