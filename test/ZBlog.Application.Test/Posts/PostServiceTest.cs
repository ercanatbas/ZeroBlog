using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using ZBlog.Application.Posts;
using ZBlog.Application.Posts.Impl;
using ZBlog.Application.Posts.Request;
using ZBlog.Application.Posts.Result;
using ZBlog.Core.Cache;
using ZBlog.Core.Map;
using ZBlog.Core.Runtime;
using ZBlog.Domain.Posts;
using ZBlog.Domain.Posts.Repo;
using ZBlog.Domain.Test;
using ZBlog.Domain.Users.Repo;
using ZBlog.Test;

namespace ZBlog.Application.Test.Posts
{
    [TestFixture]
    public class PostServiceTest : TestBase
    {
        #region .setup

        private IPostService _postService;
        private IUserRepository _userRepository;
        private IPostRepository _postRepository;
        private ICoreService _coreService;
        private ICacheService _cacheService;
        private IMapperService _mapperService;

        protected override void SetUp()
        {
            base.SetUp();
            _userRepository = Substitute.For<IUserRepository>();
            _postRepository = Substitute.For<IPostRepository>();
            _coreService = Substitute.For<ICoreService>();
            _cacheService = Substitute.For<ICacheService>();
            _mapperService = Substitute.For<IMapperService>();
            _postService = new PostService(_postRepository, _userRepository, _cacheService, _coreService, _mapperService);
        }

        #endregion

        #region CreateAPost

        [Test, Category("Unit")]
        public void CreateAPost_GIVENPostRequest_WHENInserting_THENItBecomesSuccessfully()
        {
            _coreService.User.Id.Returns(1);
            _userRepository.GetUser(Arg.Any<int>()).Returns(DomainTestBase.CreateAUser());
            _postRepository.Insert(Arg.Any<Post>()).Returns(DomainTestBase.CreateAPost());
            _cacheService.Insert(Arg.Any<string>(), Arg.Any<Post>(), Arg.Any<int>());

            var result = _postService.CreateAPost(new PostRequest
            {
                Title = "test title",
                Content = "test content"
            });

            result.ShouldNotBeNull();
            _userRepository.Received(1).GetUser(Arg.Any<int>());
            _postRepository.Received(1).Insert(Arg.Any<Post>());
            _cacheService.Received(1).Insert(Arg.Any<string>(), Arg.Any<Post>(), Arg.Any<int>());
        }

        #endregion

        #region UpdateAPost

        [Test, Category("Unit")]
        public void UpdateAPost_GIVENUpdateRequest_WHENUpdating_THENItBecomesSuccessfully()
        {
            _coreService.User.Id.Returns(1);
            _postRepository.GetPost(Arg.Any<int>(), Arg.Any<int>()).Returns(DomainTestBase.CreateAPost());
            _cacheService.Update(Arg.Any<string>(), Arg.Any<Post>(), Arg.Any<int>());

            _postService.UpdateAPost(new UpdateRequest
            {
                Id = 1,
                Title = "test title",
                Content = "test content"
            });

            _postRepository.Received(1).GetPost(Arg.Any<int>(), Arg.Any<int>());
            _postRepository.Received(1).Update(Arg.Any<Post>());
            _cacheService.Received(1).Update(Arg.Any<string>(), Arg.Any<Post>(), Arg.Any<int>());
        }

        #endregion

        #region DeleteAPost

        [Test, Category("Unit")]
        public void DeleteAPost_GIVENIdParameter_WHENRemoving_THENItBecomesSuccessfully()
        {
            _postRepository.GetPost(Arg.Any<int>(), Arg.Any<int>()).Returns(DomainTestBase.CreateAPost());

            _postService.DeleteAPost(1);
            _cacheService.Remove(Arg.Any<string>(), Arg.Any<Post>(), Arg.Any<int>());

            _postRepository.Received(1).GetPost(Arg.Any<int>(), Arg.Any<int>());
            _postRepository.Received(1).Delete(Args.AnyEntity<Post>());
            _cacheService.Received(1).Remove(Arg.Any<string>(), Arg.Any<Post>(), Arg.Any<int>());
        }

        #endregion

        #region GetAPost

        [Test, Category("Unit")]
        public void GetAPost_WHENGetting_THENItBecomesSuccessfully()
        {
            _coreService.User.Id.Returns(1);
            _postRepository.GetPost(Arg.Any<int>(), Arg.Any<int>()).Returns(DomainTestBase.CreateAPost());
            _mapperService.Map<PostResult>(Arg.Any<Post>())
                .Returns(new PostResult { Id = 1, Title = "test" });

            var result = _postService.GetAPost(1);

            result.ShouldNotBeNull();
            _postRepository.Received(1).GetPost(Arg.Any<int>(), Arg.Any<int>());
        }

        #endregion

        #region GetAllPost

        [Test, Category("Unit")]
        public void GetAllPost_WHENGettingDatabase_THENItBecomesSuccessfully()
        {
            _coreService.User.Id.Returns(1);
            _cacheService.GetList<PostResult>(Arg.Any<string>()).Returns((IEnumerable<PostResult>) null);
            _postRepository.Query(Args.AnyEntity<Post>()).Returns(DomainTestBase.CreateAPost().ToList());
            _mapperService.Map<IEnumerable<PostResult>>(Arg.Any<List<Post>>())
                .Returns(new PostResult { Id = 1, Title = "test" }.ToList());

            var result = _postService.GetAllPost();

            result.ShouldNotBeNull();
            _postRepository.Received(1).Query(Args.AnyEntity<Post>());
            _cacheService.Received(1).GetList<PostResult>(Arg.Any<string>());
        }

        [Test, Category("Unit")]
        public void GetAllPost_WHENGettingCache_THENItBecomesSuccessfully()
        {
            _coreService.User.Id.Returns(1);
            _cacheService.GetList<PostResult>(Arg.Any<string>()).Returns(new List<PostResult>());
            _mapperService.Map<IEnumerable<PostResult>>(Arg.Any<List<Post>>())
                .Returns(new PostResult { Id = 1, Title = "test" }.ToList());

            var result = _postService.GetAllPost();

            result.ShouldNotBeNull();
            _cacheService.Received(1).GetList<PostResult>(Arg.Any<string>());
        }

        #endregion

        #region SearchPost

        [Test, Category("Unit")]
        public void SearchPost_WHENGetting_THENItBecomesSuccessfully()
        {
            _postRepository.Query(Args.AnyEntity<Post>()).Returns(DomainTestBase.CreateAPost().ToList());
            _mapperService.Map<IEnumerable<PostSearchResult>>(Arg.Any<List<Post>>())
                .Returns(new PostSearchResult { Id = 1, Title = "test", Content = "test" }.ToList());

            var result = _postService.SearchPost(new PostSearchRequest
            {
                Content = "test",
                Title = "test"
            });

            result.ShouldNotBeNull();
            _postRepository.Received(1).Query(Args.AnyEntity<Post>());
        }

        #endregion
    }
}
