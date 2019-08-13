using System;
using Newtonsoft.Json;

namespace ZBlog.Core.Entity.Auditing
{
    public interface IHasDeletionTime : ISoftDelete
    {
        [JsonIgnore]
        DateTime? DeletionTime { get; }
    }
}
