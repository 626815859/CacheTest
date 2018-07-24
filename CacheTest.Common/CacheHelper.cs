using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace CacheTest.Common
{
   public class CacheHelper
    {
        Cache cache = new Cache();
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key,object value)
        {
            cache.Add(key, value, null, DateTime.Now.AddSeconds(60), TimeSpan.Zero, CacheItemPriority.Normal, null);
        }
        /// <summary>
        /// 获取指定key的vakue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public  T Retrieve<T>(string key)
        {
            object obj2 = cache.Get(key);
            if (obj2 == null)
            {
                return default(T);
            }
            return (T)obj2;
        }
        /// <summary>
        /// 缓存书否存在key的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
 
        public  bool Exist(string key)
        {
           
            return (cache.Get(key)!=null);
        }

        /// <summary>

        /// 删除全部缓存

        /// </summary>

        public  void RemoveAllCache()

        {

            
            var cacheEnum = cache.GetEnumerator();

            while (cacheEnum.MoveNext())

            {

                cache.Remove(cacheEnum.Key.ToString());

            }

        }
        /// <summary>

        /// 移除指定缓存

        /// </summary>

        /// <param name="cacheKey">键</param>

        public  void RemoveAllCache(string cacheKey)

        {
            cache.Remove(cacheKey);

        }


    }
}
