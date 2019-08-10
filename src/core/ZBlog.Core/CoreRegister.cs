using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZBlog.Core.Container;
using ZBlog.Core.Runtime;

namespace ZBlog.Core
{
    public class CoreRegister : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IResolverService>().ImplementedBy<ResolverService>().LifestyleTransient());
            container.Register(Component.For<ICoreService>().ImplementedBy<CoreService>().LifestyleTransient());
        }
    }
}
