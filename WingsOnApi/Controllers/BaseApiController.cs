using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WingsOn.Services.CustomExceptions;
using WingsOnApi.Attributes;
using WingsOnApi.Models;

namespace WingsOnApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult GetRequestResult<T>(Func<T> action) where T : class
        {
            try
            {
                var response = action();

                if (EqualityComparer<T>.Default.Equals(response, default(T)))
                {
                    return new CustomError(Request, HttpStatusCode.NotFound,
                        "The requested element could not be found in the records.");
                    ;
                }

                return new CustomResponse<T>(Request, response);
            }
            catch (ElementNotFoundException ex)
            {
                return new CustomError(Request, HttpStatusCode.NotFound, ex);
            }
            catch (Exception e)
            {
                return new CustomError(Request, HttpStatusCode.InternalServerError, e);
            }
        }
    }
}