using System.Collections.Generic;
using System.Linq;
using ProductCategory.Core.ProductCategory.Data;
using ProductCategory.Core.ProductCategory.Data.Entities;
using ProductCategory.Core.ProductCategory.Data.Repositories;

namespace ProductCategory.Core.ProductCategory.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [UnitOfWork]
        public List<Product> GetProductList()
        {
            //No DB operation until ToList() method called. So we need to control open/close connection in this method using UnitOfWork attribute.
            return _productRepository.GetAll().OrderBy(x => x.Id).ToList();
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.Delete(productId);
        }

        [UnitOfWork]
        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            //No DB operation until ToList() method called. So we need to control open/close connection in this method using UnitOfWork attribute.
            return _productRepository.GetAll().Where(p => p.ProductCategory.Id == categoryId).ToList();
        }

        public Product GetProductsById(int productId)
        {
            //return _productRepository.GetProductWithImage(productId);
            return _productRepository.Get(productId);
        }
    }
}