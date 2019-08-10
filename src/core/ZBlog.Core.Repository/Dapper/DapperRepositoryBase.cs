using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DapperExtensions;
using ZBlog.Core.Entity;
using ZBlog.Core.Kernel;

namespace ZBlog.Core.Repository.Dapper
{
    public abstract class DapperRepositoryBase<TEntity> : DapperRepositoryBase<TEntity, int> where TEntity : class, IEntity<int>, IRepository<TEntity>
    {
    }

    public abstract class DapperRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        public abstract IEnumerable<TEntity> Query(string query, object parameters = null);
        public abstract IEnumerable<TAny> Query<TAny>(string query, object parameters = null) where TAny : class;
        public virtual Task<IEnumerable<TEntity>> GetAllAsync() => Task.FromResult(Query());
        public abstract IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        protected IPredicate OnFilters(Expression<Func<TEntity, bool>> predicate = null)
        {
            var predicates = new List<IPredicate>();
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {

                ParameterExpression lambdaParam = Expression.Parameter(typeof(TEntity));
                BinaryExpression lambdaBody = Expression.Equal(
                    Expression.PropertyOrField(lambdaParam, "IsDeleted"),
                    Expression.Constant(false, typeof(bool))
                );
                predicates.Add(Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam).ToPredicateGroup<TEntity, TPrimaryKey>());
            }
            if (predicate != null)
                predicates.Add(predicate.ToPredicateGroup<TEntity, TPrimaryKey>());

            return predicates.Any() ? new PredicateGroup
            {
                Operator = GroupOperator.And,
                Predicates = predicates

            } : null;
        }
    }
}
