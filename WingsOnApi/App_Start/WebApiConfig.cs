using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WingsOnApi.Attributes.ExceptionHandling;
using WingsOnApi.Attributes.Filters;

namespace WingsOnApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Filters.Add(new LoggingFilterAttribute());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }
    }
}
