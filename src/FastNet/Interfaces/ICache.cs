namespace FastNet;

/// <summary>
/// 缓存结构
/// </summary>
public interface ICache
{
    /// <summary>
    /// Gets the model with the specified key from cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <returns>The cached model, null it wasn't found</returns>
    T Get<T>(string key);

    /// <summary>
    /// Gets the model with the specified key from cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <returns>The cached model, null it wasn't found</returns>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    Task<T> GetAsync<T>(string key, CancellationToken token = default);

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    void Set<T>(string key, T value);

    /// <summary>
    /// Sets the given model in the cache.
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="key">The unique key</param>
    /// <param name="value">The model</param>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    Task SetAsync<T>(string key, T value, CancellationToken token = default);

    /// <summary>
    /// Removes the model with the specified key from cache.
    /// </summary>
    /// <param name="key">The unique key</param>
    void Remove(string key);


    /// <summary>
    /// Removes the model with the specified key from cache.
    /// </summary>
    /// <param name="key">The unique key</param>
    /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications that the operation should be canceled.</param>
    Task RemoveAsync(string key, CancellationToken token = default);

}
