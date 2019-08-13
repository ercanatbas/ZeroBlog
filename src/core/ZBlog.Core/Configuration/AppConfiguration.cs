namespace ZBlog.Core.Configuration
{
    public class ConnectionStringConfig
    {
        public string Default { get; set; }
    }


    public class CacheConfig
    {
        public string RedisConnection { get; set; }
    }
}
