using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ZBlog.Core.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string ApplicationName { get; set; }
        public ConnectionStringConfig ConnectionString { get; set; }

        #region .ctor

        private readonly IConfigurationRoot _appConfiguration;

        public ConfigurationManager(IConfigurationRoot appConfiguration)
        {
            _appConfiguration = appConfiguration;
            appConfiguration.Bind(this);
        }

        #endregion
        private TConfiguration GetConfigurationInstance<TConfiguration, TService>(string sectionKey) where TConfiguration : IListConfiguration
        {
            var services = _appConfiguration.GetSection(sectionKey).GetChildren();
            var service = services.FirstOrDefault(x => x.GetSection("FullName").Value == typeof(TService).FullName);
            if (service == null)
                throw new Exception($"{typeof(TService).FullName} service config not found");
            var configuration = Activator.CreateInstance<TConfiguration>();
            service.Bind(configuration);
            return configuration;
        }

    }
}
