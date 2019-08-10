using System;
using System.Data;

namespace ZBlog.Core.UnitOfWork
{
    public class ActiveTransaction
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;
        public ActiveTransaction(IDbConnection connection)
        {
            _connection = connection;
            _transaction = connection.BeginTransaction();
        }
        public IDbTransaction GetTransaction() => _transaction;
        public IDbConnection GetConnection() => _connection;
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection?.Close();
            }
        }
        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection?.Close();
            }
        }
    }
}
