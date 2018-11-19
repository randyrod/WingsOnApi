using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WingsOnApi.Models;

namespace WingsOnApi.Attributes.ExceptionHandling
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            switch (context.Exception)
            {
                case HttpException httpException:
                    context.Result = new CustomError(context.Request, 
                        (HttpStatusCode) httpException.GetHttpCode(), 
                        httpException.Message);
                    break;
                case ArgumentNullException argumentNullException:
                case ArgumentException argumentException:
                    context.Result = new CustomError(context.Request,
                        HttpStatusCode.BadRequest,
                        "It is likely you, not me. But I'll check on my side anyway.");
                    break;
                case NullReferenceException nullReferenceException:
                    context.Result = new CustomError(context.Request,
                        HttpStatusCode.InternalServerError,
                        "It's not you, it's me");
                        break;
                case NotImplementedException notImplementedException:
                    context.Result = new CustomError(context.Request,
                        HttpStatusCode.NotAcceptable,
                        "We will add this for sure, maybe next sprint.");
                        break;
                default:
                    context.Result = new CustomError(context.Request, 
                        HttpStatusCode.InternalServerError, 
                        "Ooops there is no way to cover it, it was totally my fault.");
                        break;
            }
        }
    }
}