using ProductCategory.Core.ProductCategory.Data.Entities;

namespace ProductCategory.Core.ProductCategory.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}