using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZBlog.Core.Kernel;

namespace ZBlog.Core.Repository
{
    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
    }

    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        public abstract IEnumerable<TEntity> Query();
        public abstract TEntity Insert(TEntity entity);
        public abstract TEntity Update(TEntity entity);
        public abstract void Delete(TEntity entity, bool force = false);

        public abstract TEntity Get(TPrimaryKey id);
        public virtual Task<TEntity> GetAsync(TPrimaryKey id) => Task.FromResult(Get(id));
        public abstract void Delete(Expression<Func<TEntity, bool>> predicate, bool force = false);
        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate) => Task.Run(() => Delete(predicate));
    }
}
