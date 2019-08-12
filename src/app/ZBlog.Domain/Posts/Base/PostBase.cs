namespace ZBlog.Domain.Posts.Base
{
    public abstract class PostBase
    {
        public virtual int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual int UserId { get; set; }
    }
}
