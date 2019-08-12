using System.Linq;
using ZBlog.Core.Exceptions;
using ZBlog.Core.Repository.Dapper;
using ZBlog.Core.Runtime;
using ZBlog.Core.UnitOfWork;
using ZBlog.Domain.Posts;
using ZBlog.Domain.Posts.Repo;

namespace ZBlog.Infrastructure.Posts
{
    public class PostRepository : DapperRepository<Post>, IPostRepository
    {
        public PostRepository(IUnitOfWork uof, ICoreService coreService) : base(uof, coreService)
        {
        }

        public Post GetPost(int userId, int postId)
        {
            var post = Query(x => x.UserId == userId && x.Id == postId)?.FirstOrDefault();
            if (post == null)
                throw new RecordNotFoundException("Post", postId);
            return post;
        }
    }
}
