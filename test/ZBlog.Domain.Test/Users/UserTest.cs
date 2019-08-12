using NUnit.Framework;
using Shouldly;
using ZBlog.Domain.Users;
using ZBlog.Test;

namespace ZBlog.Domain.Test.Users
{
    [TestFixture]
    public class UserTest : TestBase
    {

        #region UserCreate

        [Test, Category("Unit")]
        public void UserCreate_ItShouldBeSuccessfully()
        {
            var user = User.Create("test","test","test@test.com","123456");

            user.ShouldNotBeNull();
            user.FirstName.ShouldNotBeNullOrEmpty();
            user.LastName.ShouldNotBeNullOrEmpty();
            user.MailAddress.ShouldNotBeNullOrEmpty();
            user.Password.ShouldNotBeNullOrEmpty();
        }

        #endregion
    }
}
