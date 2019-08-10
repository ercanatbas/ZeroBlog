using Newtonsoft.Json;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Primitive
{
    public interface ICreationAudited : IHasCreationTime
    {
        [JsonIgnore]
        long? CreatorUserId { get; }
        void CreationAuditing(ICoreService coreService);
    }
}
