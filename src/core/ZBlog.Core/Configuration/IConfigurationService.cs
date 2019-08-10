using System;
using System.Collections.Generic;
using System.Text;
using ZBlog.Core.Kernel;

namespace ZBlog.Core.Configuration
{
    public interface IConfigurationService : IService
    {
        T GetDbConfiguration<T>(string key);
        string GetDbConfiguration<TEnum>(TEnum intance) where TEnum : struct, IComparable, IFormattable, IConvertible;

    }
}
