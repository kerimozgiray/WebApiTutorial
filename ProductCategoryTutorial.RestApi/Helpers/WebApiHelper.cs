using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductCategoryTutorial.RestApi.Helpers
{
    public abstract class BaseApiController : ApiController
    {
        public HttpResponseMessage CreateResponse(ResponseCode responseStatusCode, object data)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                new
                {
                    code = ((int)responseStatusCode).ToString(),
                    data
                });
        }

        public enum ResponseCode
        {
            Success = 0,
            Error = 1
        }
    }
}