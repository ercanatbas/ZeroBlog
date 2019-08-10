using System;

namespace ZBlog.Core.Entity.Auditing.Primitive.Impl
{
    [Serializable]
    public abstract class AuditedPassivableEntityBase<TPrimaryKey> : AuditedEntityBase<TPrimaryKey>, IPassivable
    {
        public virtual bool IsActive { get; protected set; }
        public virtual void IsActiveAuditing(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
