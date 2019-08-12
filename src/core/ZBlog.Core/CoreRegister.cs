using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZBlog.Core.Authentication;
using ZBlog.Core.Container;
using ZBlog.Core.Map;
using ZBlog.Core.Runtime;

namespace ZBlog.Core
{
    public class CoreRegister : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IResolverService>().ImplementedBy<ResolverService>().LifestyleTransient());
            container.Register(Component.For<ICoreService>().ImplementedBy<CoreService>().LifestyleTransient());
            container.Register(Component.For<ITokenProvider>().ImplementedBy<FileTokenProvider>().LifestyleTransient());
            container.Register(Component.For<IMapperService>().ImplementedBy<MapperService>().LifestyleTransient());
        }
    }
}
