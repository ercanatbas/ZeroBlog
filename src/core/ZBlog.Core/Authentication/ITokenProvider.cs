using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ZBlog.Core.Authentication
{
    public interface ITokenProvider
    {
        string Issuer { get; }
        string Audience { get; }
        DateTime ExpireDate { get; }
        SymmetricSecurityKey GetSignInKey();
        SigningCredentials GetSigningCredentials();
        TokenValidationParameters GetTokenValidationParameters();
        SecurityToken CreateToken(IEnumerable<Claim> claims = null);
        SecurityToken CreateRefreshToken(string uniqe, string jti, string audience, string sub = "refresh");
        SecurityToken CreateRefreshToken(IEnumerable<Claim> claims = null);
        SecurityToken CreateToken(string uniqe, string jti, string auidence, string sub = "authorization");
        SecurityToken Validate(string token);

    }
}
