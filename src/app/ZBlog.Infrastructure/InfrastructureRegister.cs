﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZBlog.Core.Cache;
using ZBlog.Core.Repository;
using ZBlog.Core.Repository.Dapper;
using ZBlog.Domain.Comments.Repo;
using ZBlog.Domain.Posts.Repo;
using ZBlog.Domain.Users.Repo;
using ZBlog.Infrastructure.Cache;
using ZBlog.Infrastructure.Comments;
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
            container.Register(Component.For<ICommentRepository>().ImplementedBy<CommentRepository>().LifestyleSingleton());

            container.Register(Component.For<ICacheService>().ImplementedBy<RedisCacheService>().LifestyleSingleton());
        }
    }
}
