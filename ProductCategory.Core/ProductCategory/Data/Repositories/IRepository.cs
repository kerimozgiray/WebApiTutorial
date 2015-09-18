using System.Linq;
using ProductCategory.Core.ProductCategory.Data.Entities;

namespace ProductCategory.Core.ProductCategory.Data.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity,TPrimaryKey> : IRepository where TEntity : EntityBase<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(TPrimaryKey key);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TPrimaryKey id);
    }
}