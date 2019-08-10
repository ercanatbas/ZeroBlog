using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZBlog.Core.Kernel;

namespace ZBlog.Core.Repository
{
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    { }
    public interface IRepository<TEntity, TPrimaryKey> : Kernel.Repository.IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);

        void Delete(Expression<Func<TEntity, bool>> predicate, bool force = false);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
