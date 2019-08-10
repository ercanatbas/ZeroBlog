using Newtonsoft.Json;
using System;

namespace ZBlog.Core.Entity
{
    public interface IHasDeletionTime : ISoftDelete
    {
        [JsonIgnore]
        DateTime? DeletionTime { get; }
    }
}
