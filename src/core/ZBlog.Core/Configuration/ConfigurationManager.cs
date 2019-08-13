using Microsoft.Extensions.Configuration;

namespace ZBlog.Core.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string ApplicationName { get; set; }
        public ConnectionStringConfig ConnectionString { get; set; }

        #region .ctor

        public ConfigurationManager(IConfigurationRoot appConfiguration)
        {
            appConfiguration.Bind(this);
        }

        #endregion


    }
}
