using System.Web;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Telehire.BusinessLogic.Data;
using Telehire.BusinessLogic.Fake;
using Telehire.BusinessLogic.Services;

namespace Telehire.Web.Infrastructure
{
    public class DependencyResolver
    {
        public static void RegisterDependencies()
        {

            var builder = new ContainerBuilder();
            //Register All Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());


            //or be explicit
            //HTTP context and other related stuff
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>().InstancePerHttpRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();


            builder.RegisterGeneric(typeof(NHibernateRepository<,>)).As(typeof(IRepository<,>)).InstancePerHttpRequest();


            //builder.RegisterType<AsyncService>().As<IAsyncRunner>().InstancePerDependency();//.InstancePerLifetimeScope();

            //builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();


            IContainer container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}