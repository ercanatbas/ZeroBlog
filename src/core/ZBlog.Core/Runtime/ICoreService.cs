using ZBlog.Core.Container;

namespace ZBlog.Core.Runtime
{
    public interface ICoreService
    {
        IResolverService Resolver { get; }
        string GetConnectionString();
    }
}
