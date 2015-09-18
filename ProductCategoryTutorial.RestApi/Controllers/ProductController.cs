using System.Web.Http;
using ProductCategory.Core.ProductCategory.Services;
using ProductCategoryTutorial.RestApi.Models.DTO;

namespace ProductCategoryTutorial.RestApi.Controllers
{
    [RoutePrefix("api")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //public List<Product> GetProductByCategoryId(int categoryId)
        //{
        //    return _productService.GetProductsByCategoryId(categoryId);
        //}

        [Route("products/{id:int}")]
        [HttpGet]
        public ProductDto GetProducts(int id)
        {
            var product = _productService.GetProductsById(id);

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.ProductCategory.Id,
                Image = string.Empty,
                RecordDate = product.RecordDate
            };

            return productDto;
        }
    }
}