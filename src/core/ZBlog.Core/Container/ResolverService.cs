namespace ZBlog.Core.Container
{
    public class ResolverService : IResolverService
    {
        public TService Resolve<TService>() => ContainerManager.Instance.WindsorContainer.Resolve<TService>();
    }
}
