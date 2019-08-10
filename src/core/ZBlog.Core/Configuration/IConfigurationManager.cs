namespace ZBlog.Core.Configuration
{
    public interface IConfigurationManager
    {
        string ApplicationName { get; set; }
        ConnectionStringConfig ConnectionString { get; set; }
    }
}
