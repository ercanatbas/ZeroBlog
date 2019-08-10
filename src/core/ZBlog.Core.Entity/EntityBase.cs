using ZBlog.Core.Kernel;

namespace ZBlog.Core.Entity
{
    public abstract class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; protected set; }
    }
}
