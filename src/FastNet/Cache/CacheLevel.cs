
namespace FastNet.Cache;

/// <summary>
/// The different cache levels available.
/// </summary>
public enum CacheLevel
{
    // Nothing is stored cached
    None,
    // Sites & Params are cached
    Minimal,
    // Sites, Params, PageTypes & PostTypes are cached
    Basic,
    // Everything is cached
    Full
}
