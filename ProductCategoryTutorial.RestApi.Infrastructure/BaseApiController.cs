using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ProductCategory.Core.ProductCategory.Data.Business;

namespace ProductCategoryTutorial.RestApi.Infrastructure
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
    }
}
