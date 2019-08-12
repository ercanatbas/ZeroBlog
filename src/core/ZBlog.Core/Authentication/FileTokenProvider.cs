using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ZBlog.Core.Authentication
{
    public class FileTokenProvider : ITokenProvider
    {
        private const string Section = "FileTokenProvider";
        private readonly IConfiguration _configurationService;

        public FileTokenProvider(IConfiguration configurationRoot)
        {
            _configurationService = configurationRoot;
        }
        public string Issuer => _configurationService[$"{Section}:{TokenConfiguration.Issuer}"];
        public string Audience => _configurationService[$"{Section}:{TokenConfiguration.Audience}"];
        public DateTime ExpireDate => DateTime.Now.AddSeconds(Convert.ToInt32(_configurationService[$"{Section}:{TokenConfiguration.TokenExpire}"]));

        public SymmetricSecurityKey GetSignInKey()
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurationService[$"{Section}:{TokenConfiguration.Secret}"]));
            return signingKey;
        }

        public SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(GetSignInKey(), SecurityAlgorithms.HmacSha256);
        }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSignInKey(),
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidateAudience = true,
                ValidAudience = Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        public SecurityToken CreateToken(IEnumerable<Claim> claims = null)
        {
            return new JwtSecurityToken(Issuer,
                Audience,
                claims,
                expires: ExpireDate,
                signingCredentials: GetSigningCredentials());
        }
        public SecurityToken CreateRefreshToken(IEnumerable<Claim> claims = null)
        {
            return new JwtSecurityToken(Issuer,
                Audience,
                claims,
                expires: DateTime.Now.AddSeconds(Convert.ToInt32(_configurationService[$"{Section}:{TokenConfiguration.RefreshExpire}"])),
                signingCredentials: GetSigningCredentials());
        }
        public SecurityToken CreateToken(string uniqe, string jti, string auidence, string sub)
        {
            return CreateToken(new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, uniqe),
                new Claim(JwtRegisteredClaimNames.Sub, sub),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
                new Claim(JwtRegisteredClaimNames.Aud, auidence),
            });
        }

        public SecurityToken Validate(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            IPrincipal principal = tokenHandler.ValidateToken(token, GetTokenValidationParameters(), out var validatedToken);
            Thread.CurrentPrincipal = principal;
            return validatedToken;
        }

        public SecurityToken CreateRefreshToken(string uniqe, string jti, string audience, string sub)
        {
            return CreateRefreshToken(new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, uniqe),
                new Claim(JwtRegisteredClaimNames.Sub, sub),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
                new Claim(JwtRegisteredClaimNames.Aud, audience)
            });
        }
    }
}
