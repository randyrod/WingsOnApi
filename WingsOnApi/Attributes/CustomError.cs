using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WingsOnApi.Attributes
{
    public class CustomError : IHttpActionResult
    {
        private readonly string _errorMessage;
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpStatusCode _statusCode;

        public CustomError(HttpRequestMessage requestMessage, HttpStatusCode statusCode, string errorMessage)
        {
            _errorMessage = errorMessage;
            _requestMessage = requestMessage;
            _statusCode = statusCode;
        }
            
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestMessage.CreateErrorResponse(_statusCode, _errorMessage));
        }
    }
}