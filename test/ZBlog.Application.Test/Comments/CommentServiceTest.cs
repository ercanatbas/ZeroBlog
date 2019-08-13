using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using ZBlog.Application.Comments;
using ZBlog.Application.Comments.Impl;
using ZBlog.Application.Comments.Request;
using ZBlog.Application.Comments.Result;
using ZBlog.Core.Map;
using ZBlog.Domain.Comments;
using ZBlog.Domain.Comments.Repo;
using ZBlog.Domain.Posts.Repo;
using ZBlog.Domain.Test;
using ZBlog.Test;

namespace ZBlog.Application.Test.Comments
{
    [TestFixture]
    public class CommentServiceTest : TestBase
    {
        #region .setup

        private ICommentService _commentService;
        private ICommentRepository _commentRepository;
        private IPostRepository _postRepository;
        private IMapperService _mapperService;
        public CommentServiceTest()
        {
            base.SetUp();
            _commentRepository = Substitute.For<ICommentRepository>();
            _postRepository = Substitute.For<IPostRepository>();
            _mapperService = Substitute.For<IMapperService>();
            _commentService = new CommentService(_commentRepository, _postRepository, _mapperService);
        }

        #endregion

        #region CreateAComment

        [Test, Category("Unit")]
        public void CreateAComment_GIVENCommentPostRequest_WHENInserting_THENItBecomesSuccessfully()
        {
            _postRepository.GetCommentForPost(Arg.Any<int>()).Returns(DomainTestBase.CreateAPost());
            _commentRepository.Insert(Arg.Any<Comment>()).Returns(DomainTestBase.CreateAComment());

            var result = _commentService.CreateAComment(new CommentRequest
            {
                FirstName = "test",
                LastName = "test",
                Message = "test",
                PostId = 1
            });

            result.ShouldNotBeNull();
            _postRepository.Received(1).GetCommentForPost(Arg.Any<int>());
        }

        #endregion

        #region UpdateAComment

        [Test, Category("Unit")]
        public void UpdateAComment_GIVENUpdateRequest_WHENUpdating_THENItBecomesSuccessfully()
        {
            _commentRepository.GetComment(Arg.Any<int>(), Arg.Any<int>()).Returns(DomainTestBase.CreateAComment());

            _commentService.UpdateAComment(new UpdateCommentRequest
            {
                Id = 1,
                PostId = 1,
                FirstName = "test",
                LastName = "test",
                Message = "test",
            });

            _commentRepository.Received().GetComment(Arg.Any<int>(), Arg.Any<int>());
            _commentRepository.Received(1).Update(Arg.Any<Comment>());
        }

        #endregion

        #region DeleteAComment

        [Test, Category("Unit")]
        public void DeleteAComment_GIVENIdParameter_WHENRemoving_THENItBecomesSuccessfully()
        {
            _commentRepository.GetComment(Arg.Any<int>(), Arg.Any<int>()).Returns(DomainTestBase.CreateAComment());

            _commentService.DeleteAComment(1, 1);

            _commentRepository.Received(1).GetComment(Arg.Any<int>(), Arg.Any<int>());
            _commentRepository.Received(1).Delete(Args.AnyEntity<Comment>());
        }

        #endregion

        #region GetAllComment

        [Test, Category("Unit")]
        public void GetAllComment_WHENGetting_THENItBecomesSuccessfully()
        {
            _commentRepository.Query(Args.AnyEntity<Comment>()).Returns(DomainTestBase.CreateAComment().ToList());
            _mapperService.Map<IEnumerable<CommentResult>>(Arg.Any<List<Comment>>())
                .Returns(new CommentResult { Id = 1, PostId = 1, FirstName = "test", LastName = "test", Message = "test"}.ToList());

            var result = _commentService.GetAllComments(1);

            result.ShouldNotBeNull();
            _commentRepository.Received(1).Query(Args.AnyEntity<Comment>());
        }

        #endregion
    }
}
