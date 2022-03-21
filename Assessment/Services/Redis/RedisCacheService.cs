﻿using Newtonsoft.Json;

namespace Assessment.Services.Redis
{
    public class RedisCacheService : ICacheService
    {
        private RedisServer _redisServer;

        public RedisCacheService(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public void Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data, new JsonSerializerSettings{ ReferenceLoopHandling=ReferenceLoopHandling.Ignore  });
            _redisServer.Database.StringSet(key, jsonData);
        }

        public bool Any(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            if (Any(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }

            return default;
        }

        public void Remove(string key)
        {
            _redisServer.Database.KeyDelete(key);
        }

        public void Clear()
        {
            _redisServer.FlushDatabase();
        }
    }
}
