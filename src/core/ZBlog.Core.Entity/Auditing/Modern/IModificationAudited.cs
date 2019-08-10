using Newtonsoft.Json;
using ZBlog.Core.Entity.Auditing.Primitive;

namespace ZBlog.Core.Entity.Auditing.Modern
{
    public interface IModificationAudited<TPrimaryKey, TUser> : IModificationAudited
        where TUser : IUserEntity<TPrimaryKey>
    {
        [JsonIgnore]
        TUser LastModifierUser { get; }
    }
}
