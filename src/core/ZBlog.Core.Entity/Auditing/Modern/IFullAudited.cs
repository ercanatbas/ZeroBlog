using ZBlog.Core.Entity.Auditing.Primitive;

namespace ZBlog.Core.Entity.Auditing.Modern
{
    public interface IFullAudited<TPrimaryKey, TUser> : IModificationAudited<TPrimaryKey, TUser>, IFullAudited, IDeletionAudited<TPrimaryKey, TUser>
        where TUser : IUserEntity<TPrimaryKey>
    {

    }
}
