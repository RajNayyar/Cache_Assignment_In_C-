using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
namespace cacheAssignment
{
    class Cache
    {
      
        MemoryCache cache = new MemoryCache("NewCache");
        public void AddInCache(string key, Object value)
        {
            cache.Add(key, value, DateTime.Now.AddSeconds(20));
        }

        public object GetItemFromCache(string key)
        {
            var res = cache[key];
            return res;
        }

    }
}
