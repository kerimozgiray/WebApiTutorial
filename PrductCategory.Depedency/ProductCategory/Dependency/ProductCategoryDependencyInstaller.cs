using System.Configuration;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using PrductCategory.Depedency.ProductCategory.Dependency.UoW;
using PrductCategory.Depedency.ProductCategory.Dependency.UoW.Interceptor;
using ProductCategory.Core.ProductCategory.Services.Implementation;
using ProductCategory.Data.NHibernate.Data.Repositories.NHibernate;
using ProductCategory.Data.NHibernate.Data.Repositories.NHibernate.Mappings;

namespace PrductCategory.Depedency.ProductCategory.Dependency
{
    public class ProductCategoryDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;

            //Register all components
            container.Register(

                //Nhibernate session factory
                Component.For<ISessionFactory>().UsingFactoryMethod(CreateNhSessionFactory).LifeStyle.Singleton,

                //Unitofwork interceptor
                Component.For<NHibernateUnitOfWorkInterceptor>().LifeStyle.Transient,

                //All repositories
                Classes.FromAssembly(Assembly.GetAssembly(typeof (NhProductRepository)))
                    .InSameNamespaceAs<NhProductRepository>()
                    .WithService.DefaultInterfaces()
                    .LifestylePerWebRequest(),

                //All services
                Classes.FromAssembly(Assembly.GetAssembly(typeof (ProductService)))
                    .InSameNamespaceAs<ProductService>()
                    .WithService.DefaultInterfaces()
                    .LifestylePerWebRequest()
                );
        }

        /// <summary>
        ///     Creates NHibernate Session Factory.
        /// </summary>
        /// <returns>NHibernate Session Factory</returns>
        private static ISessionFactory CreateNhSessionFactory()
        {
            var connStr = ConfigurationManager.ConnectionStrings["ProductCategory"].ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof (ProductMap))))
                .BuildSessionFactory();
        }

        private void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            //Intercept all methods of all repositories.
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(
                    new InterceptorReference(typeof (NHibernateUnitOfWorkInterceptor)));
            }

            //Intercept all methods of classes those have at least one method that has UnitOfWork attribute.
            foreach (var method in handler.ComponentModel.Implementation.GetMethods())
            {
                if (UnitOfWorkHelper.HasUnitOfWorkAttribute(method))
                {
                    handler.ComponentModel.Interceptors.Add(
                        new InterceptorReference(typeof (NHibernateUnitOfWorkInterceptor)));
                    return;
                }
            }
        }
    }
}