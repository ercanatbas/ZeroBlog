using System;
using Newtonsoft.Json;

namespace ZBlog.Core.Entity.Auditing
{
    public interface IHasModificationTime
    {
        [JsonIgnore]
        DateTime? LastModificationTime { get; }
    }
}
