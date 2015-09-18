using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PrductCategory.Depedency.ProductCategory.Dependency;
using ProductCategoryTutorial.RestApi.Dependency;

namespace ProductCategoryTutorial.RestApi
{
    public class WebApiApplication : HttpApplication
    {
        private WindsorContainer _windsorContainer;

        private void Application_Start()
        {
            // Code that runs on application startup
            //InitializeWindsor();
            ConfigureWindsor(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, _windsorContainer));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            if (_windsorContainer != null)
            {
                _windsorContainer.Dispose();
            }
        }

        private void ConfigureWindsor(HttpConfiguration configuration)
        {
            //_windsorContainer = new WindsorContainer();
            //_windsorContainer.Install(FromAssembly.Containing<ProductCategoryDependencyInstaller>());
            //_windsorContainer.Install(FromAssembly.This());

            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(FromAssembly.Containing<ProductCategoryDependencyInstaller>());
            _windsorContainer.Install(FromAssembly.This());

            _windsorContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(_windsorContainer.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_windsorContainer);
            configuration.DependencyResolver = dependencyResolver;

            //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));
        }
    }
}