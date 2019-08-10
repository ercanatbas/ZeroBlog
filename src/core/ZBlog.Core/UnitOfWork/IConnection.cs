using System.Data;

namespace ZBlog.Core.UnitOfWork
{
    public interface IConnection
    {
        IDbTransaction GetTransaction();
        IDbConnection GetConnection();
    }
}
