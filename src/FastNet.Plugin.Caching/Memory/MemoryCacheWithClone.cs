

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;

namespace FastNet.Plugin.Caching;

/// <summary>
/// Simple in memory cache.
/// </summary>
[ExcludeFromCodeCoverage]
public class MemoryCacheWithClone : MemoryCache
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="cache">The currently configured cache</param>
    public MemoryCacheWithClone(IMemoryCache cache) : base(cache, true) { }
}
