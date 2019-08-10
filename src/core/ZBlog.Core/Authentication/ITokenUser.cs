namespace ZBlog.Core.Authentication
{
    public interface ITokenUser
    {
        int Id { get; }
        string Subject { get; }
        string Audience { get; }
        string UniqueName { get; }
    }
}
