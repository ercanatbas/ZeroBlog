using System.Collections.Generic;
using System.Linq;
using ZBlog.Application.Comments.Request;
using ZBlog.Application.Comments.Result;
using ZBlog.Core;
using ZBlog.Core.Entity;
using ZBlog.Core.Map;
using ZBlog.Core.Runtime;
using ZBlog.Domain.Comments;
using ZBlog.Domain.Comments.Repo;
using ZBlog.Domain.Posts.Repo;

namespace ZBlog.Application.Comments.Impl
{
    public class CommentService : ICommentService
    {
        #region .ctor

        private readonly ICommentRepository _commentRepository;
        private readonly IMapperService _mapperService;
        private readonly IPostRepository _postRepository;
        private readonly ICoreService _coreService;

        public CommentService(ICommentRepository commentRepository, IPostRepository postRepository, ICoreService coreService, IMapperService mapperService)
        {
            _commentRepository = commentRepository;
            _mapperService = mapperService;
            _postRepository = postRepository;
            _coreService = coreService;
        }

        #endregion

        #region CreateACustomer

        public int CreateAComment(CommentRequest request)
        {
            Check.NotNullOrEmpty(request.PostId, nameof(request.PostId));
            request.Validate<CommentRequestValidator, CommentRequest>();
            var comment = Comment.Create(_postRepository.GetCommentForPost(request.PostId), request.FirstName, request.LastName, request.Message);
            var result = _commentRepository.Insert(comment);
            return result.Id;
        }

        #endregion

        #region UpdateAComment

        public void UpdateAComment(UpdateCommentRequest request)
        {
            Check.NotNullOrEmpty(request.PostId, nameof(request.PostId));
            request.Validate<UpdateCommentRequestValidator, UpdateCommentRequest>();
            var comment = _commentRepository.GetComment(request.Id, request.PostId);
            comment.Update(request.FirstName, request.LastName, request.Message);
            _commentRepository.Update(comment);
        }

        #endregion

        #region DeleteAComment
        public void DeleteAComment(int postId, int commentId)
        {
            _commentRepository.GetComment(commentId, postId);
            _commentRepository.Delete(x => x.Id == commentId && x.PostId == postId);
        }

        #endregion

        #region GetAllComments

        public IEnumerable<CommentResult> GetAllComments(int postId)
        {
            var comments = _commentRepository.Query(x => x.PostId == postId)?.ToList();
            return _mapperService.Map<IEnumerable<CommentResult>>(comments);
        }

        #endregion
    }
}
