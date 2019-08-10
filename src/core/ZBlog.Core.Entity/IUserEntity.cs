using Newtonsoft.Json;
using ZBlog.Core.Kernel;

namespace ZBlog.Core.Entity
{
    public interface IUserEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        string FirstName { get; }
        string LastName { get; }
        string MailAddress { get; }
        [JsonIgnore]
        string Password { get; }
    }
}
