using System;
using ZBlog.Core.Exceptions;

namespace ZBlog.Application.Users.Exceptions
{
    [Serializable]
    public class AccountIsNotActiveException : ZBLogException
    {
        public AccountIsNotActiveException(int userId) : base(402, $"'Id is {userId}' of users the account is not active")
        {

        }
    }
}
