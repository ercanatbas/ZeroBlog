using Newtonsoft.Json;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Primitive
{
    public interface IDeletionAudited : IHasDeletionTime
    {
        [JsonIgnore]
        long? DeleterUserId { get; }
        void DeletionAuditing(ICoreService coreService);
    }
}
