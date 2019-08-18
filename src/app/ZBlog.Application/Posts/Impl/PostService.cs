using System.Collections.Generic;
using System.Linq;
using ZBlog.Application.Posts.Request;
using ZBlog.Application.Posts.Result;
using ZBlog.Core.Cache;
using ZBlog.Core.Entity;
using ZBlog.Core.Map;
using ZBlog.Core.Runtime;
using ZBlog.Domain.Posts;
using ZBlog.Domain.Posts.Dtos;
using ZBlog.Domain.Posts.Repo;
using ZBlog.Domain.Users.Repo;

namespace ZBlog.Application.Posts.Impl
{
    public class PostService : IPostService
    {
        #region .ctor

        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICacheService _cacheService;
        private readonly ICoreService _coreService;
        private readonly IMapperService _mapperService;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, ICacheService cacheService,
            ICoreService coreService, IMapperService mapperService)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _cacheService = cacheService;
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
            _cacheService.Insert(Caches.Post, result, result.Id);
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
            _cacheService.Update(Caches.Post, post, post.Id);
        }

        #endregion

        #region DeleteAPost

        public void DeleteAPost(int postId)
        {
            var post = _postRepository.GetPost(_coreService.User.Id, postId);
            _postRepository.Delete(x => x.Id == postId);
            _cacheService.Remove(Caches.Post, post, postId);
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
            var cacheResult = _cacheService.GetList<PostResult>(Caches.Post);
            if (cacheResult != null) return cacheResult;

            var posts = _postRepository.Query(x => x.Title != null)?
                .OrderByDescending(x => x.CreationTime).AsEnumerable();
            var postResults = _mapperService.Map<IEnumerable<PostResult>>(posts);
            _cacheService.GetList(Caches.Post, () => postResults);
            return postResults;
        }

        #endregion

        #region SearchPost

        public IEnumerable<PostSearchDto> SearchPost(PostSearchRequest request)
        {
            request.Validate<PostSearchRequestValidator, PostSearchRequest>();
            return _postRepository.SearchPost(request.Search);
        }

        #endregion
    }
}
