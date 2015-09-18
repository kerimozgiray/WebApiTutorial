using ProductCategory.Core.ProductCategory.Data.Entities;
using ProductCategory.Core.ProductCategory.Data.Repositories;

namespace ProductCategory.Data.NHibernate.Data.Repositories.NHibernate
{
    public class NhCategoryRepository : NHibernateRepositoryBase<Category, int>, ICategoryRepository
    {
    }
}