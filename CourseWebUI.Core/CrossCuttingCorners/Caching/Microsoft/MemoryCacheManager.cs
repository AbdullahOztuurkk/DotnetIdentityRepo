using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ninject.Activation.Caching;

namespace CourseWebUI.Core.CrossCuttingCorners.Caching.Microsoft
{
    public class MemoryCacheManager:ICacheManager
    {
        private ObjectCache _cache => MemoryCache.Default;
        public T Get<T>(string key)
        {
            return (T) _cache[key];
        }

        public void Add(string key, object data, int cacheTime=60)
        {
            if (data == null)
                return;
            var ItemPolicy=new CacheItemPolicy{AbsoluteExpiration = DateTime.Now+TimeSpan.FromMinutes(cacheTime)};
            _cache.Add(key, data, ItemPolicy);
        }

        public bool IsAdd(string key)
        {
            return _cache.Contains(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex=new Regex(pattern,RegexOptions.IgnoreCase|RegexOptions.Singleline|RegexOptions.Compiled);
            var keywords = _cache.Where(z => regex.IsMatch(z.Key)).Select(z => z.Key).ToList();
            foreach (var keyword in keywords)
            {
                Remove(keyword);
            }
        }

        public void Clear()
        {
            foreach (var keyword in _cache)
            {
                Remove(keyword.Key);
            }
        }
    }
}
