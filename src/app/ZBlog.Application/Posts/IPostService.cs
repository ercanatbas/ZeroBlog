using System.Collections.Generic;
using ZBlog.Application.Posts.Request;
using ZBlog.Application.Posts.Result;

namespace ZBlog.Application.Posts
{
    public interface IPostService
    {
        int CreateAPost(PostRequest request);
        void UpdateAPost(UpdateRequest request);
        void DeleteAPost(int postId);
        PostResult GetAPost(int postId);
        IEnumerable<PostResult> GetAllPost();
        IEnumerable<PostSearchResult> SearchPost(PostSearchRequest request);
    }
}
