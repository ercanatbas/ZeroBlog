using AutoMapper;
using ZBlog.Application.Comments.Result;
using ZBlog.Domain.Comments;

namespace ZBlog.Application.Comments.Map
{
    public class CommentMap : Profile
    {
        public CommentMap()
        {
            CreateMap<Comment, CommentResult>();
        }
    }
}
