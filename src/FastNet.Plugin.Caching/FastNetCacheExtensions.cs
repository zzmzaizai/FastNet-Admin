

namespace FastNet.Plugin.Caching;

/// <summary>
/// Extension methods for adding DistributedCache to the application.
/// </summary>
public static class FastNetCacheExtensions
{
    /// <summary>
    /// Adds the distributed cache service to the service collection.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <returns>The updated service collection</returns>
    public static IServiceCollection AddFastNetDistributedCache(this IServiceCollection services)
    {
        // Check dependent services
        if (!services.Any(s => s.ServiceType == typeof(IDistributedCache)))
        {
            throw new NotSupportedException("You need to register a IDistributedCache service in order to use Memory Cache in Piranha");
        }

        return services.AddSingleton<ICache, FastNet.Plugin.Caching.DistributedCache>();
    }

    /// <summary>
    /// Uses the distributed cache service in the current application.
    /// </summary>
    /// <param name="serviceBuilder">The current service builder</param>
    /// <param name="clone">If returned objects should be cloned</param>
    /// <returns>The updated service builder</returns>
    public static FastNetServiceBuilder UseFastNetDistributedCache(this FastNetServiceBuilder serviceBuilder, bool clone = false)
    {
        serviceBuilder.Services.AddFastNetDistributedCache();

        return serviceBuilder;
    }


    /// <summary>
    /// Adds the memory cache service to the service collection.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <param name="clone">If returned objects should be cloned</param>
    /// <returns>The updated service collection</returns>
    public static IServiceCollection AddFastNetMemoryCache(this IServiceCollection services, bool clone = false)
    {
        // Check dependent services
        if (!services.Any(s => s.ServiceType == typeof(IMemoryCache)))
        {
            throw new NotSupportedException("You need to register a IMemoryCache service in order to use Memory Cache in Piranha");
        }

        if (clone)
        {
            return services.AddSingleton<ICache, FastNet.Plugin.Caching.MemoryCacheWithClone>();
        }
        return services.AddSingleton<ICache, FastNet.Plugin.Caching.MemoryCache>();
    }

    /// <summary>
    /// Uses the memory cache service in the current application.
    /// </summary>
    /// <param name="serviceBuilder">The current service builder</param>
    /// <param name="clone">If returned objects should be cloned</param>
    /// <returns>The updated service builder</returns>
    public static FastNetServiceBuilder UseFastNetMemoryCache(this FastNetServiceBuilder serviceBuilder, bool clone = false)
    {
        serviceBuilder.Services.AddFastNetMemoryCache(clone);

        return serviceBuilder;
    }
}