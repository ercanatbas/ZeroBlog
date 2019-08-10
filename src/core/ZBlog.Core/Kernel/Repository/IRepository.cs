using System.Collections.Generic;

namespace ZBlog.Core.Kernel.Repository
{
    public interface IRepository
    {
    }
    public interface IRepository<TEntity, TPrimaryKey> : IRepository
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        IEnumerable<TEntity> Query();
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity, bool force = false);
    }
}
