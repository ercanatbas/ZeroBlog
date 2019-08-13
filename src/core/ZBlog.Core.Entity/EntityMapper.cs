using DapperExtensions.Mapper;
using ZBlog.Core.Entity.Map;

namespace ZBlog.Core.Entity
{
    public abstract class EntityMapper<TEntity> : ClassMapper<TEntity> where TEntity : class
    {
        protected EntityMapper()
        {
            OnMap();
            AutoMap();
            Properties.ConfigureIdentity();
        }
        protected abstract void OnMap();
    }
}
