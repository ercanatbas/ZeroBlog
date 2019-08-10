using ZBlog.Core.Authentication;
using ZBlog.Core.Container;

namespace ZBlog.Core.Runtime
{
    public interface ICoreService
    {
        ITokenUser User { get; }
        IResolverService Resolver { get; }
        string GetConnectionString();
    }
}
