using Newtonsoft.Json;
using ZBlog.Core.Entity.Auditing.Primitive;

namespace ZBlog.Core.Entity.Auditing.Modern
{
    public interface ICreationAudited<TPrimaryKey, TUser> : ICreationAudited
        where TUser : IUserEntity<TPrimaryKey>
    {
        [JsonIgnore]
        TUser CreatorUser { get; }
    }
}
