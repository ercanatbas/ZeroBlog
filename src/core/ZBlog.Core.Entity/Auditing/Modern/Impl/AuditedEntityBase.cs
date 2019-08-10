using System;
using ZBlog.Core.Entity.Auditing.Primitive.Impl;

namespace ZBlog.Core.Entity.Auditing.Modern.Impl
{
    [Serializable]
    public abstract class AuditedEntityBase<TPrimaryKey, TUser> : AuditedEntityBase<TPrimaryKey>, IModificationAudited<TPrimaryKey, TUser>
        where TUser : IUserEntity<TPrimaryKey>
    {
        public virtual TUser CreatorUser { get; protected set; }
        public virtual TUser LastModifierUser { get; protected set; }
    }
}
