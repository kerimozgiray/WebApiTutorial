using System.Reflection;
using Castle.DynamicProxy;
using NHibernate;
using ProductCategory.Data.NHibernate.Data.Repositories.NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace PrductCategory.Depedency.ProductCategory.Dependency.UoW.Interceptor
{
    /// <summary>
    ///     This interceptor is used to manage transactions.
    /// </summary>
    public class NHibernateUnitOfWorkInterceptor : IInterceptor
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        ///     Creates a new NHibernateUnitOfWorkInterceptor object.
        /// </summary>
        /// <param name="sessionFactory">Nhibernate session factory.</param>
        public NHibernateUnitOfWorkInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        ///     Intercepts a method.
        /// </summary>
        /// <param name="invocation">Method invocation arguments</param>
        public void Intercept(IInvocation invocation)
        {
            //If there is a running transaction, just run the method
            if (NHibernateUnitOfWork.Current != null || !RequiresDbConnection(invocation.MethodInvocationTarget))
            {
                invocation.Proceed();
                return;
            }

            try
            {
                NHibernateUnitOfWork.Current = new NHibernateUnitOfWork(_sessionFactory);
                NHibernateUnitOfWork.Current.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    NHibernateUnitOfWork.Current.Commit();
                }
                catch
                {
                    try
                    {
                        NHibernateUnitOfWork.Current.Rollback();
                    }
                    catch
                    {
                        // ignored
                    }

                    throw;
                }
            }
            finally
            {
                NHibernateUnitOfWork.Current = null;
            }
        }

        private static bool RequiresDbConnection(MethodInfo methodInfo)
        {
            return UnitOfWorkHelper.HasUnitOfWorkAttribute(methodInfo) ||
                   UnitOfWorkHelper.IsRepositoryMethod(methodInfo);
        }
    }
}