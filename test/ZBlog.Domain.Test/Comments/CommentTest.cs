using NUnit.Framework;
using Shouldly;
using ZBlog.Domain.Comments;
using ZBlog.Test;

namespace ZBlog.Domain.Test.Comments
{
    [TestFixture]
    public class CommentTest : TestBase
    {
        #region CommentCreate
        [Test, Category("Unit")]
        public void CommentCreate_ItShouldBeSuccessfully()
        {
            var comment = Comment.Create(DomainTestBase.CreateAPost(), "test", "test", "test");

            comment.ShouldNotBeNull();
            comment.FirstName.ShouldNotBeNullOrEmpty();
            comment.LastName.ShouldNotBeNullOrEmpty();
            comment.Message.ShouldNotBeNullOrEmpty();
            comment.PostId.ShouldNotBeNull();
        }
        #endregion

        #region UpdateComment
        [Test, Category("Unit")]
        public void CommentUpdate_ItShouldBeSuccessfully()
        {
            var comment = Comment.Create(DomainTestBase.CreateAPost(), "test", "test", "test");
            comment.Update("test1", "test2", "test3");

            comment.ShouldNotBeNull();
            comment.FirstName.ShouldBe("test1");
            comment.LastName.ShouldBe("test2");
            comment.Message.ShouldBe("test3");
        }
        #endregion
    }
}
