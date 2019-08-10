namespace ZBlog.Core.Exceptions
{
    public class NotAuthorizedException : ZBLogException
    {
        public NotAuthorizedException() : base(401, "Not authorized for request")
        {

        }
    }
}
