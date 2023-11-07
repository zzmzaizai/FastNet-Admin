

using System.Diagnostics.CodeAnalysis;

namespace FastNet.Cache;

/// <summary>
/// Simple in memory cache.
/// </summary>
[ExcludeFromCodeCoverage]
public class SimpleCacheWithClone : SimpleCache
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public SimpleCacheWithClone() : base(true) { }
}
