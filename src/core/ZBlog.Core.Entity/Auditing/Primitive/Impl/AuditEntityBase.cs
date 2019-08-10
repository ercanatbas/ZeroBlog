using System;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Primitive.Impl
{
    [Serializable]
    public abstract class AuditedEntityBase<TPrimaryKey> : CreationAuditedEntityBase<TPrimaryKey>, IModificationAudited
    {
        public virtual DateTime? LastModificationTime { get; private set; }
        public virtual long? LastModifierUserId { get; private set; }
        public virtual void ModificationAuditing(ICoreService coreService)
        {
            LastModificationTime = DateTime.Now;
            LastModifierUserId = coreService.User?.Id != 0 ? coreService.User?.Id : null;
        }
    }
}
