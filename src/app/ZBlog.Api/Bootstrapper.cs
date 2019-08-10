using Castle.MicroKernel.Registration;
using ZBlog.Core;
using ZBlog.Core.Configuration;
using ZBlog.Core.Container;

namespace ZBlog.Api
{
    public static class BootStrapper
    {
        public static void InitializeContainer()
        {
            var container = ContainerManager.Instance.WindsorContainer;
            ContainerManager.Instance.WindsorContainer.Install(new CoreRegister());
            var confManager = container.Register(Component.For<IConfigurationManager>().ImplementedBy<ConfigurationManager>().LifestyleSingleton()).Resolve<IConfigurationManager>() as ConfigurationManager;

        }
    }
    
   
}
