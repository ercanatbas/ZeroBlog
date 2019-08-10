using Castle.Windsor;

namespace ZBlog.Core.Container
{
    public class ContainerManager : IContainerManager
    {
        private static ContainerManager instance = new ContainerManager();
        public IWindsorContainer WindsorContainer { get; }
        public static ContainerManager Instance => instance;

        private ContainerManager()
        {
            WindsorContainer = new WindsorContainer();
        }

        public bool IsRegistered<TService>() => WindsorContainer.Kernel.HasComponent(typeof(TService));
        public TService Resolve<TService>() => WindsorContainer.Resolve<TService>();
    }
}
