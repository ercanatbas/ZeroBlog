using ZBlog.Core.Repository;

namespace ZBlog.Domain.Users.Repo
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(int userId);
    }
}
