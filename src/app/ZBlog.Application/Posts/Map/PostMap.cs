using AutoMapper;
using ZBlog.Application.Posts.Result;
using ZBlog.Domain.Posts;

namespace ZBlog.Application.Posts.Map
{
    public class PostMap : Profile
    {
        public PostMap()
        {
            CreateMap<Post, PostResult>();
        }
    }
}
