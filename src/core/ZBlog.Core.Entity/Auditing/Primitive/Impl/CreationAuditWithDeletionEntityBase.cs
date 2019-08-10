using System;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Primitive.Impl
{
    [Serializable]
    public abstract class CreationAuditWithDeletionEntityBase<TPrimaryKey> : CreationAuditedEntityBase<TPrimaryKey>, IDeletionAudited
    {
        public bool IsDeleted { get; private set; }
        public DateTime? DeletionTime { get; private set; }
        public long? DeleterUserId { get; private set; }
        public virtual void DeletionAuditing(ICoreService coreService)
        {
            DeletionTime = DateTime.Now;
            DeleterUserId = coreService.User.Id;
            IsDeleted = true;
        }
    }
}
