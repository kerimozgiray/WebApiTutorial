using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCategory.Core.ProductCategory.Data.Entities;

namespace ProductCategory.Core.ProductCategory.Services
{
    public interface IProductService
    {
        List<Product> GetProductList();

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int productId);

        List<Product> GetProductsByCategoryId(int categoryId);

        Product GetProductsById(int productId);


    }
}
