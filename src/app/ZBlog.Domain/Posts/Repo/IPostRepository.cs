using System.Collections.Generic;
using ZBlog.Core.Repository;
using ZBlog.Domain.Posts.Dtos;

namespace ZBlog.Domain.Posts.Repo
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetPost(int userId, int postId);
        Post GetCommentForPost(int postId);
        IEnumerable<PostSearchDto> SearchPost(string search);
    }
}
