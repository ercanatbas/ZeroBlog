using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZBlog.Core.Repository;
using ZBlog.Core.Repository.Dapper;

namespace ZBlog.Infrastructure
{
    public class InfrastructureRegister : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>), typeof(DapperRepository<>)).ImplementedBy(typeof(DapperRepository<>)).LifestyleSingleton());
            container.Register(Component.For(typeof(IRepository<,>), typeof(DapperRepository<,>)).ImplementedBy(typeof(DapperRepository<,>)).LifestyleSingleton());
        }
    }
}
