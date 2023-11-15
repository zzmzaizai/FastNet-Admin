namespace FastNet.Plugin.Caching;

/// <summary>
/// Simple in distributed cache.
/// </summary>
public class DistributedCache : ICache
{
    private readonly IDistributedCache _cache;
    private readonly JsonSerializerSettings _jsonSettings;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="cache">The currently configured cache</param>
    public DistributedCache(IDistributedCache cache)
    {
        _cache = cache;
        _jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
    }

    /// <summary>
    /// Gets the model with the specified key from cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <returns>The cached model, null it wasn't found</returns>
    public T Get<T>(string key)
    {
        var json = _cache.GetString(key);

        if (!string.IsNullOrEmpty(json))
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSettings);
        }
        return default(T);
    }

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    public void Set<T>(string key, T value)
    {
        _cache.SetString(key, JsonConvert.SerializeObject(value, _jsonSettings));
    }

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    /// <param name="absoluteExpiration"></param>
    public void Set<T>(string key, T value, DateTimeOffset? absoluteExpiration = null)
    {
        if (absoluteExpiration.HasValue)
        {
            _cache.SetString(key, JsonConvert.SerializeObject(value, _jsonSettings),new DistributedCacheEntryOptions { 
                AbsoluteExpiration = absoluteExpiration
            });
        }
        else
        {
            _cache.SetString(key, JsonConvert.SerializeObject(value, _jsonSettings));
        }
    }

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    /// <param name="absoluteExpirationRelativeToNow"></param>
    public void Set<T>(string key, T value, TimeSpan? absoluteExpirationRelativeToNow = null)
    {
        if (absoluteExpirationRelativeToNow.HasValue)
        {
            _cache.SetString(key, JsonConvert.SerializeObject(value, _jsonSettings), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow
            });
        }
        else
        {
            _cache.SetString(key, JsonConvert.SerializeObject(value, _jsonSettings));
        }
    }

    /// <summary>
    /// Removes the model with the specified key from cache.
    /// </summary>
    /// <param name="key">The unique key</param>
    public void Remove(string key)
    {
        _cache.Remove(key);
    }


    /// <summary>
    /// Gets the model with the specified key from cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <returns>The cached model, null it wasn't found</returns>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    public async Task<T> GetAsync<T>(string key, CancellationToken token = default)
    {
        var json = await _cache.GetStringAsync(key);

        if (!string.IsNullOrEmpty(json))
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSettings);
        }
        return default(T);
    }

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    public async Task SetAsync<T>(string key, T value, CancellationToken token = default)
    {
        await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value, _jsonSettings));
    }

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    /// <param name="absoluteExpiration"></param>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    public async Task SetAsync<T>(string key, T value, DateTimeOffset? absoluteExpiration = null, CancellationToken token = default)
    {
        if (absoluteExpiration.HasValue)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value, _jsonSettings), new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = absoluteExpiration
            });
        }
        else
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value, _jsonSettings));
        }
    }

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    /// <param name="absoluteExpirationRelativeToNow"></param>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    public async Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpirationRelativeToNow = null, CancellationToken token = default)
    {
        if (absoluteExpirationRelativeToNow.HasValue)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value, _jsonSettings), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow
            });
        }
        else
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value, _jsonSettings));
        }
    }

    /// <summary>
    /// Removes the model with the specified key from cache.
    /// </summary>
    /// <param name="key">The unique key</param>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    public async Task RemoveAsync(string key, CancellationToken token = default)
    {
        await _cache.RemoveAsync(key);
    }
     
}
