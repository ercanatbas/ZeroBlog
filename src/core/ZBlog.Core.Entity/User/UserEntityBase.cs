using ZBlog.Core.Entity.Auditing.Primitive.Impl;

namespace ZBlog.Core.Entity.User
{
    public abstract class UserEntityBase<TPrimaryKey> : FullAuditedEntityBase<TPrimaryKey>, IUserEntity<TPrimaryKey>
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string MailAddress { get; protected set; }
        public string Password { get; protected set; }
    }
}
