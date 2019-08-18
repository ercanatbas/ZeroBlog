using System.Collections.Generic;
using System.Linq;
using Dapper;
using ZBlog.Core.Exceptions;
using ZBlog.Core.Extension;
using ZBlog.Core.Repository.Dapper;
using ZBlog.Core.Runtime;
using ZBlog.Core.UnitOfWork;
using ZBlog.Domain.Posts;
using ZBlog.Domain.Posts.Dtos;
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
        public Post GetCommentForPost(int postId)
        {
            var post = Query(x =>  x.Id == postId)?.FirstOrDefault();
            if (post == null)
                throw new RecordNotFoundException("Post", postId);
            return post;
        }
        
        public IEnumerable<PostSearchDto> SearchPost(string search)
        {
            var queryTemplate = @"SELECT * FROM Post AS p /**where**/ LIMIT 20";

            var builder = new SqlBuilder();
            var query = builder.AddTemplate(queryTemplate);
            builder.WhereIfNotNull(search, "MATCH (p.Content, p.Title) AGAINST (CONCAT(@search,'*') IN BOOLEAN MODE)", new { search });
            builder.WhereNotDeleted("p.IsDeleted");

            var result = Query<PostSearchDto>(query.RawSql, query.Parameters);
            return result;
        }
    }
}
