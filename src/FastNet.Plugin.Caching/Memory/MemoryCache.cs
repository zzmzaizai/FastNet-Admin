namespace FastNet.Plugin.Caching;

/// <summary>
/// Simple in memory cache.
/// </summary>
public class MemoryCache : ICache
{
    /// <summary>
    /// The private memory cache.
    /// </summary>
    private readonly IMemoryCache _cache;

    /// <summary>
    /// If returned objects should be cloned.
    /// </summary>
    private readonly bool _clone;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="cache">The currently configured cache</param>
    public MemoryCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="cache">The currently configured cache</param>
    /// <param name="clone">If returned objects should be cloned</param>
    protected MemoryCache(IMemoryCache cache, bool clone)
    {
        _cache = cache;
        _clone = clone;
    }

    /// <summary>
    /// Gets the model with the specified key from cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <returns>The cached model, null it wasn't found</returns>
    public T Get<T>(string key)
    {
        if (_cache.TryGetValue<T>(key, out var obj))
        {
            if (!_clone)
            {
                return obj;
            }
            return Utils.DeepClone(obj);
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
        _cache.Set(key, value);
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
        if (absoluteExpiration.HasValue )
        {
            _cache.Set(key, value, absoluteExpiration.Value);
        }else
        {
            _cache.Set(key, value);
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
            _cache.Set(key, value, absoluteExpirationRelativeToNow.Value);
        }
        else
        {
            _cache.Set(key, value);
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
        return await Task.FromResult(Get<T>(key));
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
        Set<T>(key, value);
        await Task.CompletedTask;
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
        Set<T>(key, value, absoluteExpiration);
        await Task.CompletedTask;
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
        Set<T>(key, value, absoluteExpirationRelativeToNow);
        await Task.CompletedTask;
    }

    /// <summary>
    /// Removes the model with the specified key from cache.
    /// </summary>
    /// <param name="key">The unique key</param>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    public async Task RemoveAsync(string key, CancellationToken token = default)
    {
        Remove(key);
        await Task.CompletedTask;
    }



}
