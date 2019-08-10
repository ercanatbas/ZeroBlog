using DapperExtensions.Mapper;

namespace ZBlog.Core.Entity.Map
{
    public class DefaultEntityMapper<TEntity> : ClassMapper<TEntity> where TEntity : class
    {
        public DefaultEntityMapper()
        {
            AutoMap();
            Properties.ConfigureIdentity();
        }
    }
}
