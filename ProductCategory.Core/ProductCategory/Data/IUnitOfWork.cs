namespace ProductCategory.Core.ProductCategory.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}