

using System.Collections.Concurrent;

namespace FastNet.Cache;

/// <summary>
/// Simple in memory cache.
/// </summary>
public class SimpleCache : ICache
{
    /// <summary>
    /// The private cache collection.
    /// </summary>
    private readonly IDictionary<string, object> _cache = new ConcurrentDictionary<string, object>();

    /// <summary>
    /// If returned objects should be cloned.
    /// </summary>
    private readonly bool _clone;

    /// <summary>
    /// Gets the model with the specified key from cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <returns>The cached model, null it wasn't found</returns>
    public T Get<T>(string key)
    {
        object value;

        if (_cache.TryGetValue(key, out value))
        {
            if (!_clone)
            {
                return (T)value;
            }
            return Utils.DeepClone((T)value);
        }
        return default(T);
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="clone">If returned objects should be cloned</param>
    public SimpleCache(bool clone = true)
    {
        _clone = clone;
    }

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    public void Set<T>(string key, T value)
    {
        _cache[key] = value;
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
