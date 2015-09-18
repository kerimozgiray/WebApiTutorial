using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ProductCategory.Core.ProductCategory.Data.Entities;
using ProductCategory.Core.ProductCategory.Data.Repositories;

namespace ProductCategory.Data.NHibernate.Data.Repositories.NHibernate
{
    public class NhProductRepository : NHibernateRepositoryBase<Product, int>, IProductRepository
    {
        public void DeleteProductsOfCategory(int categoryId)
        {
            var products = GetAll().Where(product => product.ProductCategory.Id == categoryId).ToList();

            foreach (var product in products)
            {
                Session.Delete(product);
            }
        }

        //public Product GetProductWithImage(int Id)
        //{
            
        //}
    }
}