using ZBlog.Core.Entity;
using ZBlog.Core.Entity.Auditing.Primitive.Impl;
using ZBlog.Domain.Comments.Validations;
using ZBlog.Domain.Posts;

namespace ZBlog.Domain.Comments
{
    public class Comment : FullAuditedEntityBase<int>
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Message { get; protected set; }
        public int PostId { get; protected set; }

        protected Comment()
        {
        }

        #region Create

        public static Comment Create(Post post, string firstName, string lastName, string message)
        {
            var comment = new Comment
            {
                PostId = post.Id,
                FirstName = firstName,
                LastName = lastName,
                Message = message
            };
            comment.Validate<CommentValidator, Comment>();
            return comment;
        }

        #endregion

        #region Update

        public void Update(string firstName, string lastName, string message)
        {
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            Message = message ?? Message;
            this.Validate<CommentValidator, Comment>();
        }

        #endregion
    }
}
