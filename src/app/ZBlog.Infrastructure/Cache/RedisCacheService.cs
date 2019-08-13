using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using ZBlog.Core.Cache;
using ZBlog.Core.Configuration;

namespace ZBlog.Infrastructure.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConfigurationManager _configurationManager;

        public RedisCacheService(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public IEnumerable<TModel> GetList<TModel>(string key, Func<IEnumerable<TModel>> setter)
        {
            var model = GetList<TModel>(key);
            if (model != null)
                return model;
            var data = setter.Invoke();
            SetList(key, data);
            return data;
        }
        public void Insert<TIdentity, T>(string key, T model, TIdentity identity) where T : class
        {
            try
            {
                using (var connection = ConnectionMultiplexer.Connect(_configurationManager.Cache.RedisConnection))
                {
                    var list = new RedisDictionary<TIdentity, T>(key, connection);
                    list.Add(identity, model);
                }
            }
            catch
            {
                // ignored
            }
        }
        public void Update<TIdentity, T>(string key, T model, TIdentity identity) where T : class
        {
            try
            {
                using (var connection = ConnectionMultiplexer.Connect(_configurationManager.Cache.RedisConnection))
                {
                    var list = new RedisDictionary<TIdentity, T>(key, connection);
                    if (list.ContainsKey(identity))
                        list.Remove(identity);
                    list.Add(identity, model);
                }
            }
            catch
            {
                // ignored
            }
        }
        public void Remove<TIdentity, T>(string key, T model, TIdentity identity)
        {
            try
            {
                using (var connection = ConnectionMultiplexer.Connect(_configurationManager.Cache.RedisConnection))
                {
                    var list = new RedisDictionary<TIdentity, T>(key, connection);
                    list.Remove(identity);
                }
            }
            catch
            {
                // ignored
            }
        }

        private void SetList<TModel>(string key, IEnumerable<TModel> model, string keyColumn = "Id", int second = 300)
        {
            try
            {
                using (var connection = ConnectionMultiplexer.Connect(_configurationManager.Cache.RedisConnection))
                {
                    var list = new RedisDictionary<int, TModel>(key, connection);
                    list.AddMultiple(model.Select(x =>
                        new KeyValuePair<int, TModel>(Convert.ToInt32(x.GetType().GetProperty(keyColumn).GetValue(x)), x)));
                }
            }
            catch
            {
                // ignored
            }
        }
        public IEnumerable<TModel> GetList<TModel>(string key)
        {
            var result = default(IEnumerable<TModel>);
            try
            {
                using (var connection = ConnectionMultiplexer.Connect(_configurationManager.Cache.RedisConnection))
                {
                    var list = new RedisDictionary<int, TModel>(key, connection);

                    if (list.Values.Any())
                        result = list.Values;
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }
    }
}
