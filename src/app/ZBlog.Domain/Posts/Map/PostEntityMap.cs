using ZBlog.Core.Entity;

namespace ZBlog.Domain.Posts.Map
{
    public class PostEntityMap : EntityMapper<Post>
    {
        protected override void OnMap()
        {
            Map(m => m.Comments).Ignore();
        }
    }
}
