using Newtonsoft.Json;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Primitive
{
    public interface IModificationAudited : IHasModificationTime
    {
        [JsonIgnore]
        long? LastModifierUserId { get; }
        void ModificationAuditing(ICoreService coreService);
    }
}
