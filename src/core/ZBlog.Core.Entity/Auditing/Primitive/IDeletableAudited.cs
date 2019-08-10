using ZBlog.Core.Entity.Auditing.Primitive;

namespace ZBlog.Core.Entity.Auditing
{
    public interface IDeletableAudited : IModificationAudited, IDeletionAudited
    {
    }
}
