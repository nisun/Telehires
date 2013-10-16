using Telehire.Web.Infrastructure;
namespace Telehire.Web.App_Start
{
    public class TelehireResolverConfig
    {
        public static void Register()
        {
            DependencyResolver.RegisterDependencies();
        }
    }
}