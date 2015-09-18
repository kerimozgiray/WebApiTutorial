using System;
using NHibernate;
using ProductCategory.Core.ProductCategory.Data;

namespace ProductCategory.Data.NHibernate.Data.Repositories.NHibernate
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        [ThreadStatic] private static NHibernateUnitOfWork _current;

        /// <summary>
        ///     Reference to the session factory.
        /// </summary>
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        ///     Reference to the currently running transcation.
        /// </summary>
        private ITransaction _transaction;

        /// <summary>
        ///     Creates a new instance of NHibernateUnitOfWork.
        /// </summary>
        /// <param name="sessionFactory"></param>
        public NHibernateUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        ///     Gets current instance of the NHibernateUnitOfWork.
        ///     It gets the right instance that is related to current thread. Owe to [ThreadStatic] attribute
        /// </summary>
        public static NHibernateUnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        /// <summary>
        ///     Gets Nhibernate session object to perform queries.
        /// </summary>
        public ISession Session { get; private set; }

        /// <summary>
        ///     Opens database connection and begins transaction.
        /// </summary>
        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        /// <summary>
        ///     Commits transaction and closes database connection.
        /// </summary>
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        /// <summary>
        ///     Rollbacks transaction and closes database connection.
        /// </summary>
        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}