using Newtonsoft.Json;
using ZBlog.Core.Entity.Auditing.Primitive;

namespace ZBlog.Core.Entity.Auditing.Modern
{
    public interface IDeletionAudited<TPrimaryKey, TUser> : IDeletionAudited
        where TUser : IUserEntity<TPrimaryKey>
    {
        [JsonIgnore]
        TUser DeleterUser { get; }
    }
}
