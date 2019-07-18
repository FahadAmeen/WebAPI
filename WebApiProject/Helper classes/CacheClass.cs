using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebApiProject.Data;

namespace WebApiProject.Models
{
    public class CacheClass
    {
        private readonly IMemoryCache _cache;

        //making a dictionary so that clearing cache maybe easy 
        //KEY here represent which model class' cache is being modified, whereas values represent the string keys of the cache
        private ConcurrentDictionary<string, List<string>> allCacheEntries;


        public CacheClass(IMemoryCache memoryCache)
        {
            this._cache = memoryCache;
            allCacheEntries =
                new ConcurrentDictionary<string, List<string>>();
        }

        public void Dispose()
        {
            this._cache.Dispose();
        }

        public void ClearCache(string keyOfDictionary)
        {
            //clearing entries of that model class
            if (!allCacheEntries.Keys.Contains(keyOfDictionary))
            {
                return;
            }

            var cacheKeys = allCacheEntries[keyOfDictionary];
            
            //Clearing cache
            if (cacheKeys.Count > 0)
            {
                for (int i = 0; i < cacheKeys.Count; i++)
                {
                    _cache.Remove(cacheKeys[i]);
                }
            }

        }

        public void updateCache(string cacheKey, string modelName, int expiryDurationInDays,  Object cachedObject = null )
        {
            var opts = new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromDays(expiryDurationInDays)
            };
            
            _cache.Set(cacheKey, cachedObject, opts);
           
            //in order to clear cache we need to store keys somewhere.
            if (!allCacheEntries.Keys.Contains(modelName))
            {
                //allCacheEntries.Keys.Add(modelName);
                allCacheEntries[modelName] = new List<string>();
            }

            allCacheEntries[modelName].Add(cacheKey);
        }


        /// <inheritdoc cref="IMemoryCache.TryGetValue"/>
        /// modified ...
        public object TryGetAll(string cacheKey)
        {
            //if the key doesn't exist, the cache is updated
            _cache.TryGetValue(cacheKey, out var cachedObjects);
            return cachedObjects;
        }

        public List<object> Search(string cacheKey)
        {
            _cache.TryGetValue(cacheKey, out List<object> cachedObjects);

            return cachedObjects;
        }

        public int getCount(string cacheKey)
        {
            if (!_cache.TryGetValue(cacheKey, out int cachedObjectsCount))
            {
                return -1;
            }

            return cachedObjectsCount;
        }

        // checked ... 
        public object TryGetById(string cacheKey, int id, string modelName, int expiryDurationInDays)
        {
            Object cachedUser;
            if (!_cache.TryGetValue(cacheKey, out cachedUser))
            {
                updateCache(cacheKey, modelName, expiryDurationInDays, cachedUser);
            }

            return cachedUser;
        }
    }
}
 