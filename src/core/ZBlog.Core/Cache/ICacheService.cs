using System;
using System.Collections.Generic;

namespace ZBlog.Core.Cache
{
    public interface ICacheService
    {
        IEnumerable<TModel> GetList<TModel>(string key, Func<IEnumerable<TModel>> setter);
        IEnumerable<TModel> GetList<TModel>(string key);
        void Insert<TIdentity, T>(string key, T model, TIdentity identity) where T : class;
        void Update<TIdentity, T>(string key, T model, TIdentity identity) where T : class;
        void Remove<TIdentity, T>(string key, T model, TIdentity identity);
    }
}
