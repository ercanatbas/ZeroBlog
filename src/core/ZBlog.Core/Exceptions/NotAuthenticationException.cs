namespace ZBlog.Core.Exceptions
{
    public class NotAuthenticationException : ZBLogException
    {
        public NotAuthenticationException() : base(401, "Username or password is wrong")
        {

        }
    }
    public class RequiredAuthenticationException : ZBLogException
    {
        public RequiredAuthenticationException() : base(400, "Authentication is required")
        {

        }
    }
}
