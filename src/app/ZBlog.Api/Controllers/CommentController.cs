using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZBlog.Application.Comments;
using ZBlog.Application.Comments.Request;

namespace ZBlog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CommentController : ControllerBase
    {
        #region .ctor

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        #endregion

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult CreateAPost([FromBody] CommentRequest request) => Ok(_commentService.CreateAComment(request));

        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult UpdateAPost([FromBody] UpdateCommentRequest request)
        {
            _commentService.UpdateAComment(request);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("{commentId}/post/{postId}")]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult DeleteAPost(int commentId, int postId)
        {
            _commentService.DeleteAComment(postId, commentId);
            return Ok();
        }
    }
}
