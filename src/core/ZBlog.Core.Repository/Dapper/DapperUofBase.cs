using System;
using System.Data;
using System.Data.Common;
using ZBlog.Core.Runtime;
using ZBlog.Core.UnitOfWork;

namespace ZBlog.Core.Repository.Dapper
{
    public abstract class DapperUowBase : IUnitOfWork, IConnection
    {
        private readonly ICoreService _coreService;

        #region .ctor

        private int _call;
        private int _openConnectionCount;
        protected DapperUowBase(ICoreService coreService)
        {
            _coreService = coreService;
        }

        #endregion
        public IDbTransaction GetTransaction() => ActiveTransaction?.GetTransaction();
        private ActiveTransaction ActiveTransaction { get; set; }
        protected abstract DbConnection CreateConnection();
        public IDbConnection GetConnection()
        {
            DbConnection connection = null;
            try
            {
                if (ActiveTransaction != null && _call != 0)
                    return ActiveTransaction.GetConnection();

                connection = CreateConnection();
                connection.Disposed += (sender, args) =>
                connection.ConnectionString = _coreService.GetConnectionString();

                if (!string.IsNullOrEmpty(connection.ConnectionString))
                {
                    connection.Open();
                    _openConnectionCount++;
                    connection.GetHashCode();
                }
                else
                    throw new Exception("Connecting string not found");

                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ActiveTransaction == null && _call == 0)
                {
                    connection?.Close();
                    _openConnectionCount--;
                }
            }

        }

        public void BeginTransaction()
        {
            _call++;
            if (ActiveTransaction == null)
            {
                var connection = GetConnection();
                ActiveTransaction = new ActiveTransaction(connection);
            }

        }

        public void Commit()
        {
            if (ActiveTransaction == null)
                throw new InvalidOperationException("No transaction started.");

            if (_call == 1)
            {
                ActiveTransaction.Commit();
                ActiveTransaction = null;
            }
            _call--;
        }

        public void Rollback()
        {
            if (ActiveTransaction == null)
                throw new InvalidOperationException("No transaction started.");
            ActiveTransaction.Rollback();
            ActiveTransaction = null;
            _call = 0;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            ActiveTransaction?.Rollback();
            _call = 0;
        }
    }
}
