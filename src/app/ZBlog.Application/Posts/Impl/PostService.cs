using System.Collections.Generic;
using System.Linq;
using ZBlog.Application.Posts.Request;
using ZBlog.Application.Posts.Result;
using ZBlog.Core.Entity;
using ZBlog.Core.Map;
using ZBlog.Core.Runtime;
using ZBlog.Domain.Posts;
using ZBlog.Domain.Posts.Repo;
using ZBlog.Domain.Users.Repo;

namespace ZBlog.Application.Posts.Impl
{
    public class PostService : IPostService
    {
        #region .ctor

        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICoreService _coreService;
        private readonly IMapperService _mapperService;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, ICoreService coreService,
            IMapperService mapperService)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _coreService = coreService;
            _mapperService = mapperService;
        }

        #endregion

        #region CreateAPost

        public int CreateAPost(PostRequest request)
        {
            request.Validate<PostRequestValidator, PostRequest>();
            var post = Post.Create(_userRepository.GetUser(_coreService.User.Id), request.Title, request.Content);
            var result = _postRepository.Insert(post);
            return result.Id;
        }

        #endregion

        #region UpdateAPost

        public void UpdateAPost(UpdateRequest request)
        {
            request.Validate<UpdateRequestValidator, UpdateRequest>();
            var post = _postRepository.GetPost(_coreService.User.Id, request.Id);
            post.Update(request.Title, request.Content);
            _postRepository.Update(post);
        }

        #endregion

        #region DeleteAPost

        public void DeleteAPost(int postId)
        {
            _postRepository.GetPost(_coreService.User.Id, postId);
            _postRepository.Delete(x => x.Id == postId);
        }

        #endregion

        #region GetAPost

        public PostResult GetAPost(int postId)
        {
            var post = _postRepository.GetPost(_coreService.User.Id, postId);
            return _mapperService.Map<PostResult>(post);
        }

        #endregion

        #region GetAllPost

        public IEnumerable<PostResult> GetAllPost()
        {
            var posts = _postRepository.Query(x => x.Title != null)?.ToList().OrderByDescending(x => x.CreationTime);
            return _mapperService.Map<IEnumerable<PostResult>>(posts);
        }

        #endregion

        #region SearchPost

        public IEnumerable<PostSearchResult> SearchPost(PostSearchRequest request)
        {
            request.Validate<PostSearchRequestValidator, PostSearchRequest>();
            var posts = _postRepository.Query(x => x.Content == request.Content || x.Title == request.Title)?.ToList();
            return _mapperService.Map<IEnumerable<PostSearchResult>>(posts);
        }

        #endregion
    }
}
