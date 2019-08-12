using System.Linq;
using ZBlog.Application.Users.Exceptions;
using ZBlog.Application.Users.Request;
using ZBlog.Core.Authentication;
using ZBlog.Core.Exceptions;
using ZBlog.Core.Extension;
using ZBlog.Core.Repository;
using ZBlog.Domain.Users;

namespace ZBlog.Application.Users.Impl
{
    public sealed class AccountService : IAccountService
    {
        #region .ctor

        private readonly IRepository<User> _userRepository;
        private readonly ITokenProvider _tokenProvider;

        public AccountService(IRepository<User> userRepository, ITokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
        }

        #endregion

        #region Login

        public Token Login(LoginRequest loginRequest)
        {
            var user = _userRepository.Query(x =>
                    x.MailAddress == loginRequest.MailAddress && x.Password == loginRequest.Password.ToSha256())?
                .FirstOrDefault();
            if (user == null)
                throw new NotAuthenticationException();
            if (!user.IsActive)
                throw new AccountIsNotActiveException(user.Id);

            return user.GetToken(_tokenProvider);
        }

        #endregion
    }
}
