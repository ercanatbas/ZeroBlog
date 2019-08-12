using System.IdentityModel.Tokens.Jwt;
using ZBlog.Core.Authentication;
using ZBlog.Core.Entity;
using ZBlog.Core.Entity.User;
using ZBlog.Core.Extension;
using ZBlog.Domain.Users.Validations;

namespace ZBlog.Domain.Users
{
    public class User : UserEntityBase<int>
    {

        protected User()
        {
        }

        #region Create

        public static User Create(string firstName, string lastName, string mailAddress, string password)
        {
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                MailAddress = mailAddress,
                Password = password.ToSha256()
            };
            user.Validate<UserValidator, User>();
            return user;
        }

        #endregion

        #region IsActive

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        #endregion

        #region Token

        public Token GetToken(ITokenProvider provider)
        {
            return new Token
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(provider.CreateToken(MailAddress, Id.ToString(), "Audience")),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(provider.CreateRefreshToken(MailAddress, Id.ToString(), "Audience")),
                ExpireDate = provider.ExpireDate,
                Type = "bearer"
            };
        }

        #endregion
    }
}
