using Castle.MicroKernel.Registration;
using DapperExtensions.Sql;
using ZBlog.Application;
using ZBlog.Core;
using ZBlog.Core.Configuration;
using ZBlog.Core.Container;
using ZBlog.Core.Entity.Map;
using ZBlog.Domain;
using ZBlog.Infrastructure;

namespace ZBlog.Api
{
    public static class BootStrapper
    {
        public static void InitializeContainer()
        {
            var container = ContainerManager.Instance.WindsorContainer;
            ContainerManager.Instance.WindsorContainer.Install(new CoreRegister(), new InfrastructureRegister(), new DomainRegister(), new ApplicationRegister());
            container.Register(Component.For<IConfigurationManager>().ImplementedBy<ConfigurationManager>().LifestyleSingleton()).Resolve<IConfigurationManager>();
        }

        public static void InitializeSettings()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(DefaultEntityMapper<>);
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
        }
    }
    
   
}
