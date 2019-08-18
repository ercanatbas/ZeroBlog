using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using ZBlog.Application.Posts;
using ZBlog.Application.Posts.Request;
using ZBlog.Application.Posts.Result;
using ZBlog.Application.Comments;
using ZBlog.Application.Comments.Result;
using ZBlog.Domain.Posts.Dtos;

namespace ZBlog.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PostController : ControllerBase
    {
        #region .ctor

        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public PostController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        #endregion

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult CreateAPost([FromBody] PostRequest request) => Ok(_postService.CreateAPost(request));

        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult UpdateAPost([FromBody] UpdateRequest request)
        {
            _postService.UpdateAPost(request);
            return Ok();
        }

        [HttpDelete]
        [Route("{postId}")]
        [ProducesResponseType(typeof(void), 200)]
        public IActionResult DeleteAPost(int postId)
        {
            _postService.DeleteAPost(postId);
            return Ok();
        }

        [HttpGet]
        [Route("{postId}")]
        [ProducesResponseType(typeof(PostResult), 200)]
        public IActionResult GetAPost(int postId) => Ok(_postService.GetAPost(postId));

        [HttpGet]
        [AllowAnonymous]
        [Route("all")]
        [ProducesResponseType(typeof(IEnumerable<PostResult>), 200)]
        public IActionResult GetAllPost() => Ok(_postService.GetAllPost());

        [HttpGet]
        [AllowAnonymous]
        [Route("{postId}/comments")]
        [ProducesResponseType(typeof(IEnumerable<CommentResult>), 200)]
        public IActionResult GetAllComment(int postId) => Ok(_commentService.GetAllComments(postId));

        [HttpGet]
        [AllowAnonymous]
        [Route("search")]
        [ProducesResponseType(typeof(IEnumerable<PostSearchDto>), 200)]
        public IActionResult SearchPost(PostSearchRequest request) => Ok(_postService.SearchPost(request));
    }
}
