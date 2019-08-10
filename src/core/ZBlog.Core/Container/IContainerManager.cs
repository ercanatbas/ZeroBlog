namespace ZBlog.Core.Container
{
    public interface IContainerManager
    {
        bool IsRegistered<TService>();
        TService Resolve<TService>();
    }
}
