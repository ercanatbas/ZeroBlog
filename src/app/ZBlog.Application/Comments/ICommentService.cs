using System.Collections.Generic;
using ZBlog.Application.Comments.Request;
using ZBlog.Application.Comments.Result;

namespace ZBlog.Application.Comments
{
    public interface ICommentService
    {
        int CreateAComment(CommentRequest request);
        void UpdateAComment(UpdateCommentRequest request);
        void DeleteAComment(int postId, int commentId);
        IEnumerable<CommentResult> GetAllComments(int postId);
    }
}
