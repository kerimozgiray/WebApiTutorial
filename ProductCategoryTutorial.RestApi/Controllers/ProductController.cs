using System.Net.Http;
using System.Web.Http;
using ProductCategory.Core.ProductCategory.Data.Business;
using ProductCategory.Core.ProductCategory.Services;
using ProductCategoryTutorial.RestApi.Infrastructure;
using ProductCategoryTutorial.RestApi.Models.DTO;

namespace ProductCategoryTutorial.RestApi.Controllers
{
    [RoutePrefix("api")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("products/{id:int}")]
        [HttpGet]
        public HttpResponseMessage ProductsById(int id)
        {
            var product = _productService.GetProductsById(id);

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.ProductCategory.Id,
                Image = product.Image,
                RecordDate = product.RecordDate
            };

            return CreateResponse(ResponseCode.Success, productDto);
        }
    }
}