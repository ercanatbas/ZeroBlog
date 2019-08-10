using Microsoft.AspNetCore.Http;
using ZBlog.Core.Configuration;
using ZBlog.Core.Container;

namespace ZBlog.Core.Runtime
{
    public class CoreService : ICoreService
    {
        private readonly IConfigurationManager _configurationManager;
        public IResolverService Resolver { get; }

        #region .ctor
        private readonly HttpContext _context;

        public CoreService(IHttpContextAccessor accessor,IResolverService resolverService, IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
            _context = accessor.HttpContext;
            Resolver = resolverService;
        }

        #endregion
        public string GetConnectionString() => _configurationManager.ConnectionString.Default;
    }
}
