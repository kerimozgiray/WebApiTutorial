using ProductCategory.Core.ProductCategory.Data.Entities;

namespace ProductCategory.Core.ProductCategory.Data.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        void DeleteProductsOfCategory(int categoryId);

        //Product GetProductWithImage(int Id);
    }
}