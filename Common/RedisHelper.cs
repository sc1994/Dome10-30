using ServiceStack.Redis;
using System;
using System.Configuration;


namespace Common
{
    public class RedisHelper
    {
        public static void SetCache<T>(string key, T vlaue, DateTime expires)
        {
            using (var client = GetRedisSound())
            {
                client.Set(key, vlaue, expires);
            }
        }

        public static T GetCache<T>(string key)
        {
            using (var client = GetRedisSound())
            {
                return client.Get<T>(key);
            }
        }

        public static void ClearCache(string key)
        {
            using (var client = GetRedisSound())
            {
                client.Remove(key);
            }
        }

        private static RedisClient GetRedisSound()
        {
            return new RedisClient(ConfigurationManager.ConnectionStrings["RedisHost"].ConnectionString);
        }
    }
}
