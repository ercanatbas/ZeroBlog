using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;

namespace ZBlog.Domain
{
    public class DomainRegister : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assembly = Classes.FromAssemblyNamed(GetType().Namespace);

            container.Register(assembly
                .BasedOn(typeof(AbstractValidator<>))
                .WithServiceFromInterface(typeof(IValidator)).Configure(c => c.Named(c.Implementation.FullName))
                .LifestyleTransient());
        }
    }
}
