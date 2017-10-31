using System.Web.Http;
using System.Web.Http.Cors;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );

            config.EnableCors();

            config.EnableCors(new EnableCorsAttribute("http://localhost:7777", "*", "POST,GET")
            {
                SupportsCredentials = true,
                PreflightMaxAge = 60 * 60
            });
        }
    }
}
