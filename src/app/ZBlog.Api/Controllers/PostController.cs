using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using ZBlog.Application.Posts;
using ZBlog.Application.Posts.Request;
using ZBlog.Application.Posts.Result;

namespace ZBlog.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PostController : ControllerBase
    {
        #region .ctor

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
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
        [Route("search")]
        [ProducesResponseType(typeof(IEnumerable<PostSearchResult>), 200)]
        public IActionResult SearchPost([FromBody] PostSearchRequest request) => Ok(_postService.GetAllPost());
    }
}
