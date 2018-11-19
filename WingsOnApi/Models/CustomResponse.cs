using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WingsOnApi.Models
{
    public class CustomResponse<T> : IHttpActionResult where T : class
    {

        private readonly HttpRequestMessage _requestMessage;
        private readonly T _result;
        
        public CustomResponse(HttpRequestMessage requestMessage, T result)
        {
            _requestMessage = requestMessage;
            _result = result;
        }
        
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<T>(_result, new JsonMediaTypeFormatter()),
                RequestMessage = _requestMessage
            };

            return Task.FromResult(response);
        }
    }
}