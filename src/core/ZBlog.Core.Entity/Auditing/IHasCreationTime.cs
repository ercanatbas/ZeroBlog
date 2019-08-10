using Newtonsoft.Json;
using System;

namespace ZBlog.Core.Entity.Auditing
{
    public interface IHasCreationTime
    {
        [JsonIgnore]
        DateTime CreationTime { get; }
    }
}
