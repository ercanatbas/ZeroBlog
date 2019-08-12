using MySql.Data.MySqlClient;
using System.Data.Common;
using ZBlog.Core.Repository.Dapper;
using ZBlog.Core.Runtime;
using ZBlog.Core.UnitOfWork;

namespace ZBlog.Application
{
    public class UnitOfWork : DapperUowBase, IUnitOfWork
    {
        public UnitOfWork(ICoreService coreService) : base(coreService)
        {
        }

        protected override DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }
    }
}
