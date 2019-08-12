using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using ZBlog.Application.Users;
using ZBlog.Application.Users.Exceptions;
using ZBlog.Application.Users.Impl;
using ZBlog.Application.Users.Request;
using ZBlog.Core.Authentication;
using ZBlog.Core.Exceptions;
using ZBlog.Domain.Users;
using ZBlog.Domain.Users.Repo;
using ZBlog.Test;

namespace ZBlog.Application.Test.Users
{
    [TestFixture]
    public class AccountServiceTest : TestBase
    {
        #region .setup

        private IUserRepository _userRepository;
        private ITokenProvider _tokenProvider;
        private IAccountService _accountService;

        protected override void SetUp()
        {
            base.SetUp();
            _userRepository = Substitute.For<IUserRepository>();
            _tokenProvider = Substitute.For<ITokenProvider>();
            _accountService = new AccountService(_userRepository, _tokenProvider);
        }

        #endregion

        #region Login

        [Test, Category("Unit")]
        public void Login_AreLoginInformationValid()
        {
            var request = new LoginRequest
            {
                MailAddress = "test@test.com",
                Password = "123456"
            };
            _userRepository.Query(Args.AnyEntity<User>()).Returns(default(IEnumerable<User>));
            Assert.Throws<NotAuthenticationException>(() => _accountService.Login(request));
        }
        [Test, Category("Unit")]
        public void Login_GIVENDeActiveUser_THENItShouldBeThrowsException()
        {
            var request = new LoginRequest
            {
                MailAddress = "test@test.com",
                Password = "123456"
            };
            var user = User.Create("test", "test", request.MailAddress, password: request.Password);
            user.IsActiveAuditing(false);
            var users = user.ToList();
            _userRepository.Query(Args.AnyEntity<User>()).Returns(users);
            Assert.Throws<AccountIsNotActiveException>(() => _accountService.Login(request));
        }

        #endregion
    }
}
