using System;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Primitive.Impl
{
    [Serializable]
    public abstract class FullAuditedEntityBase<TPrimaryKey> : AuditedPassivableEntityBase<TPrimaryKey>, IFullAudited
    {
        public virtual bool IsDeleted { get; private set; }
        public virtual long? DeleterUserId { get; private set; }
        public virtual DateTime? DeletionTime { get; private set; }
        public virtual void DeletionAuditing(ICoreService coreService)
        {
            DeletionTime = DateTime.Now;
            //DeleterUserId = coreService.User?.Id != 0 ? coreService.User?.Id : null;
            IsDeleted = true;
        }
    }
}
