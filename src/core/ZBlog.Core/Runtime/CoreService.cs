using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ZBlog.Core.Authentication;
using ZBlog.Core.Configuration;
using ZBlog.Core.Container;

namespace ZBlog.Core.Runtime
{
    public class CoreService : ICoreService
    {
        private readonly IConfigurationManager _configurationManager;
        public ITokenUser User => GetTokenUser();
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
        private ITokenUser GetTokenUser(JwtSecurityToken customToken = null)
        {
            if (_context != null)
            {
                var uniqueName = customToken?.Id ?? _context.User.Identity.Name;
                var jti = (customToken?.Claims ?? _context.User.Claims)
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                var audience = (customToken?.Claims ?? _context.User.Claims)
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value;

                if (!string.IsNullOrEmpty(uniqueName) && int.TryParse(jti, out var id))
                    return new TokenUser(id, jti, audience, uniqueName);
            }
            return new TokenUser(0, null, null, null);
        }
    }
}
