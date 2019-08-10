using System;
using ZBlog.Core.Entity.Auditing.Primitive.Impl;

namespace ZBlog.Core.Entity.Auditing.Modern.Impl
{
    [Serializable]
    public abstract class CreationAuditedEntityBase<TPrimaryKey, TUser> : CreationAuditedEntityBase<TPrimaryKey>, ICreationAudited<TPrimaryKey, TUser>
        where TUser : IUserEntity<TPrimaryKey>
    {
        public virtual TUser CreatorUser { get; protected set; }
    }
}
