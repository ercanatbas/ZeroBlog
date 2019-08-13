using ZBlog.Core.Repository;

namespace ZBlog.Domain.Comments.Repo
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Comment GetComment(int commentId, int postId);
    }
}
