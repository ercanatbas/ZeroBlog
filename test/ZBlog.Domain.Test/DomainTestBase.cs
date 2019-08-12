using ZBlog.Domain.Posts;
using ZBlog.Domain.Users;

namespace ZBlog.Domain.Test
{
    public static class DomainTestBase
    {
        public static User CreateAUser(string firstName = "test", string lastName = "test", string mailAddress = "test@test.com", string password = "123456")
        {
            return User.Create(firstName, lastName, mailAddress, password);
        }

        public static Post CreateAPost(string title = "test", string content = "test")
        {
            return Post.Create(CreateAUser(), title, content);
        }
    }
}
