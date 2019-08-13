namespace ZBlog.Domain.Comments.Base
{
    public abstract class CommentBase
    {
        public virtual int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public virtual int PostId { get; set; }
    }
}
