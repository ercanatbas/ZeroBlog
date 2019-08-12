﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DapperExtensions;
using ZBlog.Core.Kernel;

namespace ZBlog.Core.Repository.Dapper
{
    internal static class DapperExpressionExtensions
    {
        public static IPredicate ToPredicateGroup<TEntity, TPrimaryKey>(this Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity<TPrimaryKey>
        {
            //Check.NotNullOrEmpty(expression, nameof(expression));

            var dev = new DapperExpressionVisitor<TEntity, TPrimaryKey>();
            IPredicate pg = dev.Process(expression);

            return pg;
        }
    }
}