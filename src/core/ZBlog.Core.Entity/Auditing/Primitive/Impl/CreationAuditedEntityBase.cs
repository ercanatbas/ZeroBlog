using System;
using ZBlog.Core.Runtime;

namespace ZBlog.Core.Entity.Auditing.Primitive.Impl
{
    [Serializable]
    public abstract class CreationAuditedEntityBase<TPrimaryKey> : EntityBase<TPrimaryKey>, ICreationAudited
    {
        public virtual DateTime CreationTime { get; private set; }
        public virtual long? CreatorUserId { get; private set; }

        public virtual void CreationAuditing(ICoreService coreService)
        {
            //if (Id.Equals(0))
            //    return;
            CreationTime = DateTime.Now;
            //CreatorUserId = coreService.User?.Id != 0 ? coreService.User?.Id : null;
        }
    }
}
