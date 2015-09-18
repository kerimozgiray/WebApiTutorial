using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ProductCategory.Core.ProductCategory.Data.Entities;
using ProductCategory.Core.ProductCategory.Data.Repositories;

namespace ProductCategory.Data.NHibernate.Data.Repositories.NHibernate
{
    public class NHibernateRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : EntityBase<TPrimaryKey>
    {
        protected ISession Session => NHibernateUnitOfWork.Current.Session;

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public TEntity Get(TPrimaryKey key)
        {
            return Session.Get<TEntity>(key);
        }

        public void Insert(TEntity entity)
        {
            Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            Session.Update(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            Session.Delete(Session.Load<TEntity>(id));
        }
    }
}