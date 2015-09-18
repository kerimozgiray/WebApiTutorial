using System.Collections.Generic;
using System.Linq;
using ProductCategory.Core.ProductCategory.Data;
using ProductCategory.Core.ProductCategory.Data.Entities;
using ProductCategory.Core.ProductCategory.Data.Repositories;

namespace ProductCategory.Core.ProductCategory.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [UnitOfWork]
        public List<Category> GetCategoryList()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.Get(categoryId);
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.Delete(categoryId);
            _productRepository.DeleteProductsOfCategory(categoryId);
        }
    }
}