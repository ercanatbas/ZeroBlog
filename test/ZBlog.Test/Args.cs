using NSubstitute;
using System;
using System.Linq.Expressions;

namespace ZBlog.Test
{
    public static class Args
    {
        public static Expression<Func<TEntity, bool>> AnyEntity<TEntity>()
        {
            return Arg.Any<Expression<Func<TEntity, bool>>>();
        }
    }
}
