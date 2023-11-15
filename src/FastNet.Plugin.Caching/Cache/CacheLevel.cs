
namespace FastNet.Plugin.Caching;

/// <summary>
/// The different cache levels available.
/// </summary>
public enum CacheLevel
{
    /// <summary>
    /// Nothing is stored cached
    /// </summary>
    None,
    /// <summary>
    /// Sites 
    /// </summary>& Params are cached
    Minimal,
    /// <summary>
    /// Sites, Params, PageTypes 
    /// </summary>& PostTypes are cached
    Basic,
    /// <summary>
    /// Everything is cached
    /// </summary>
    Full
}
