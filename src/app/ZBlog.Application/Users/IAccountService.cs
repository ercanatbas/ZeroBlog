using ZBlog.Application.Users.Request;
using ZBlog.Core.Authentication;

namespace ZBlog.Application.Users
{
    public interface IAccountService
    {
        Token Login(LoginRequest loginRequest);
    }
}
