using System;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Modern.Impl
{
    [Serializable]
    public abstract class FullAuditedEntityBase<TPrimaryKey, TUser> : AuditedEntityBase<TPrimaryKey, TUser>, IFullAudited<TPrimaryKey, TUser>
        where TUser : IUserEntity<TPrimaryKey>
    {
        public virtual bool IsDeleted { get; protected set; }
        public virtual TUser DeleterUser { get; protected set; }
        public virtual long? DeleterUserId { get; protected set; }
        public void DeletionAuditing(ICoreService coreService)
        {
            throw new NotImplementedException();
        }

        public virtual DateTime? DeletionTime { get; protected set; }
        public bool IsActive { get; protected set; }
    }
}
