using System.Diagnostics;
using System.Web.Http.Filters;

namespace WingsOnApi.Attributes.Filters
{
    public class LoggingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.WriteLine($"Controller: {actionExecutedContext.ActionContext.ControllerContext} " +
                            $"ActionName: {actionExecutedContext.ActionContext.ActionDescriptor.ActionName} " +
                            $"ExceptionMessage: {actionExecutedContext.Exception.Message}");
            
            base.OnException(actionExecutedContext);
        }
    }
}