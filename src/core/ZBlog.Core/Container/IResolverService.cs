namespace ZBlog.Core.Container
{
    public interface IResolverService
    {
        TService Resolve<TService>();
    }
}
