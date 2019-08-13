using Newtonsoft.Json;
using ZBlog.Domain.Comments.Base;

namespace ZBlog.Application.Comments.Result
{
    public class CommentResult : CommentBase
    {
        [JsonIgnore]
        public override  int PostId { get; set; }  
    }
}
