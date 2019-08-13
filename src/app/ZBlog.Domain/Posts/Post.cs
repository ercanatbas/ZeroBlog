using ZBlog.Core.Entity;
using ZBlog.Core.Entity.Auditing.Primitive.Impl;
using ZBlog.Domain.Posts.Validations;
using ZBlog.Domain.Users;

namespace ZBlog.Domain.Posts
{
    public class Post : FullAuditedEntityBase<int>
    {
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public int UserId { get; protected set; }

        protected Post()
        {
        }

        #region Create

        public static Post Create(User user, string title, string content)
        {
            var post = new Post
            {
                UserId = user.Id,
                Title = title,
                Content = content
            };
            post.Validate<PostValidator, Post>();
            return post;
        }

        #endregion

        #region Update

        public void Update(string title, string content)
        {
            Title = title ?? Title;
            Content = content ?? Content;
            this.Validate<PostValidator, Post>();
        }

        #endregion
    }
}
