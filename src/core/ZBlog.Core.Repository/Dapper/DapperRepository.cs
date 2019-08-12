using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using ZBlog.Core.Entity;
using ZBlog.Core.Entity.Auditing.Primitive;
using ZBlog.Core.Extension;
using ZBlog.Core.Kernel;
using ZBlog.Core.Runtime;
using ZBlog.Core.UnitOfWork;

namespace ZBlog.Core.Repository.Dapper
{
    public class DapperRepository<TEntity> : DapperRepository<TEntity, int>, IRepository<TEntity>
       where TEntity : class, IEntity<int>
    {
        public DapperRepository(IUnitOfWork uof, ICoreService coreService) : base(uof, coreService)
        {
        }
    }
    public class DapperRepository<TEntity, TPrimaryKey> : DapperRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        protected DbConnection Connection => (DbConnection)_uof.GetConnection();
        protected DbTransaction Transaction => (DbTransaction)_uof.GetTransaction();

        private readonly DapperUowBase _uof;
        private readonly ICoreService _coreService;

        public DapperRepository(IUnitOfWork uof, ICoreService coreService)
        {
            _uof = (DapperUowBase)uof;
            _coreService = coreService;
        }

        public override TEntity Get(TPrimaryKey id) => Connection.Get<TEntity>(id);

        public override IEnumerable<TEntity> Query()
        {
            var result = Connection.GetList<TEntity>(OnFilters(), transaction: Transaction);

            return result;
        }
        public override IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Connection.GetList<TEntity>(OnFilters(predicate), transaction: Transaction);
            return result;
        }

        public override IEnumerable<TEntity> Query(string query, object parameters = null)
        {
            var result = Connection.Query<TEntity>(query, parameters, Transaction);

            return result;
        }

      

        public override IEnumerable<TAny> Query<TAny>(string query, object parameters = null)
        {
            var result = Connection.Query<TAny>(query, parameters, Transaction);

            return result;
        }

        public override IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Connection.GetList<TEntity>(OnFilters(predicate), transaction: Transaction);

            return result;
        }

        public override TEntity Update(TEntity entity)
        {
            if (entity is IModificationAudited modificationEntity)
                modificationEntity.ModificationAuditing(_coreService);
            Connection.Update(entity, Transaction);

            return entity;
        }

        public override void Delete(TEntity entity, bool force = false)
        {
            if (force)
            {
                Connection.Delete(entity, Transaction);
                return;
            }
            if (entity is IDeletionAudited deletionEntity)
                deletionEntity.DeletionAuditing(_coreService);
            if (entity is ISoftDelete)
                Connection.Update(entity, Transaction);
            else
                Connection.Delete(entity, Transaction);
        }


        public override void Delete(Expression<Func<TEntity, bool>> predicate, bool force = false)
        {
            GetAll(predicate).ForEach(x => Delete(x, force));
        }

        public override TEntity Insert(TEntity entity)
        {
            if (entity is ICreationAudited creationEntity)
                creationEntity.CreationAuditing(_coreService);
            Connection.Insert(entity, Transaction);
            return entity;
        }
    }
}
