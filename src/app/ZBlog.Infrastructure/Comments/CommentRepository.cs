using System.Linq;
using ZBlog.Core.Exceptions;
using ZBlog.Core.Repository.Dapper;
using ZBlog.Core.Runtime;
using ZBlog.Core.UnitOfWork;
using ZBlog.Domain.Comments;
using ZBlog.Domain.Comments.Repo;

namespace ZBlog.Infrastructure.Comments
{
    public class CommentRepository : DapperRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork uof, ICoreService coreService) : base(uof, coreService)
        {
        }

        public Comment GetComment(int commentId, int postId)
        {
            var comment = Query(x => x.Id == commentId && x.PostId == postId)?.FirstOrDefault();
            if (comment == null)
                throw new RecordNotFoundException("Comment", commentId);
            return comment;
        }
    }
}
