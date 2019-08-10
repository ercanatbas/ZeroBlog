using Newtonsoft.Json;

namespace ZBlog.Core.Entity
{
    public interface ISoftDelete
    {
        [JsonIgnore]
        bool IsDeleted { get; }
    }
}
