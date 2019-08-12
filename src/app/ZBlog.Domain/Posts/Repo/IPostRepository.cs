using ZBlog.Core.Repository;

namespace ZBlog.Domain.Posts.Repo
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetPost(int userId, int postId);
    }
}
