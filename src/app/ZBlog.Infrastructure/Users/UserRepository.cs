using ZBlog.Core.Exceptions;
using ZBlog.Core.Repository.Dapper;
using ZBlog.Core.Runtime;
using ZBlog.Core.UnitOfWork;
using ZBlog.Domain.Users;
using ZBlog.Domain.Users.Repo;

namespace ZBlog.Infrastructure.Users
{
    public class UserRepository : DapperRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork uof, ICoreService coreService) : base(uof, coreService)
        {
        }

        public User GetUser(int userId)
        {
            var user = Get(userId);
            if (user == null)
                throw new RecordNotFoundException("User", userId);
            return user;
        }
    }
}
