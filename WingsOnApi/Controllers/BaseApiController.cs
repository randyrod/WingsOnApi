using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace WingsOnApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult GetRequestResult<T>(Func<T> action, [CallerMemberName] string methodName = null)
        {
            try
            {
                var response = action();

                if (EqualityComparer<T>.Default.Equals(response, default(T)))
                {
                    return Content(HttpStatusCode.NotFound, new StringContent("The requested element was not found"),
                        new JsonMediaTypeFormatter());
                }
                
                return Content(HttpStatusCode.OK, response, new JsonMediaTypeFormatter());
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new StringContent("An unknown error ocurred"),
                    new JsonMediaTypeFormatter());
            }
        }
    }
}