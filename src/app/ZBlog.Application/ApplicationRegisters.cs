using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Reflection;
using ZBlog.Core.Extension;
using ZBlog.Core.UnitOfWork;

namespace ZBlog.Application
{
    public class ApplicationRegister : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assembly = Classes.FromAssemblyNamed(GetType().Namespace);
            container.Register(assembly
                .Where(x => !x.IsInterface && !x.IsAbstract && x.Name.EndsWith("Service"))
                .WithService.DefaultInterfaces()
                .Configure(c => c.LifestyleTransient()));

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestyleTransient());

            container.Register(
                Types.FromAssemblyInThisApplication(Assembly.GetExecutingAssembly())
                    .BasedOn<Profile>()
                    .WithService.Base()
                    .Configure(c => c.Named(c.Implementation.FullName))
                    .LifestyleTransient());

            container.Register(Component.For<IMapper>().Instance(new MapperConfiguration(cfg =>
                container.ResolveAll<Profile>().ForEach(cfg.AddProfile)
            ).CreateMapper()).LifestyleSingleton());
        }
    }
}
