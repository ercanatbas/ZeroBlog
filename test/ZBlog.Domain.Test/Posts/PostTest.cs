using NSubstitute;
using NUnit.Framework;
using Shouldly;
using ZBlog.Domain.Posts;
using ZBlog.Domain.Users.Repo;
using ZBlog.Test;

namespace ZBlog.Domain.Test.Posts
{
    [TestFixture]
    public class PostTest : TestBase
    {
        #region .setup

        private IUserRepository _userRepository;

        protected override void SetUp()
        {
            base.SetUp();
            _userRepository = Substitute.For<IUserRepository>();
        }

        #endregion

        #region PostCreate

        [Test, Category("Unit")]
        public void PostCreate_ItShouldBeSuccessfully()
        {
            var post = Post.Create(DomainTestBase.CreateAUser(), "test","test");

            post.ShouldNotBeNull();
            post.Content.ShouldNotBeNullOrEmpty();
            post.Title.ShouldNotBeNullOrEmpty();
            post.UserId.ShouldNotBeNull();
        }

        #endregion

        #region PostUpdate

        [Test, Category("Unit")]
        public void PostUpdate_ItShouldBeSuccessfully()
        {
            var post = Post.Create(DomainTestBase.CreateAUser(), "test", "test");
            post.Update("test1","test2");

            post.ShouldNotBeNull();
            post.Content.ShouldBe("test2");
            post.Title.ShouldBe("test1");
        }

        #endregion
    }
}
