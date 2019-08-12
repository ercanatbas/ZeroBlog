using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZBlog.Core.Repository;
using ZBlog.Core.Repository.Dapper;
using ZBlog.Domain.Posts.Repo;
using ZBlog.Domain.Users.Repo;
using ZBlog.Infrastructure.Posts;
using ZBlog.Infrastructure.Users;

namespace ZBlog.Infrastructure
{
    public class InfrastructureRegister : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>), typeof(DapperRepository<>)).ImplementedBy(typeof(DapperRepository<>)).LifestyleSingleton());
            container.Register(Component.For(typeof(IRepository<,>), typeof(DapperRepository<,>)).ImplementedBy(typeof(DapperRepository<,>)).LifestyleSingleton());

            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestyleSingleton());
            container.Register(Component.For<IPostRepository>().ImplementedBy<PostRepository>().LifestyleSingleton());
        }
    }
}
