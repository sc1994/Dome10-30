using System;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static System.String;

namespace Common
{
    public static class ConvertHelper
    {
        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMd5(this string str)
        {
            if (IsNullOrEmpty(str)) return "";
            var pwd = Empty;
            var md5 = MD5.Create();
            var s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return s.Aggregate(pwd, (current, t) => current + t.ToString("X"));
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T JsonToObject<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}
