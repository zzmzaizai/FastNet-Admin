 
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
 

/// <summary>
/// Extension methods for adding DistributedCache to the application.
/// </summary>
public static class FastNetDistributedCacheExtensions
{
    /// <summary>
    /// Adds the distributed cache service to the service collection.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <returns>The updated service collection</returns>
    public static IServiceCollection AddPiranhaDistributedCache(this IServiceCollection services)
    {
        // Check dependent services
        if (!services.Any(s => s.ServiceType == typeof(IDistributedCache)))
        {
            throw new NotSupportedException("You need to register a IDistributedCache service in order to use Memory Cache in Piranha");
        }
        return services.AddSingleton<ICache, DistributedCache>();
    }

    /// <summary>
    /// Uses the distributed cache service in the current application.
    /// </summary>
    /// <param name="serviceBuilder">The current service builder</param>
    /// <param name="clone">If returned objects should be cloned</param>
    /// <returns>The updated service builder</returns>
    public static FastNetServiceBuilder UseDistributedCache(this FastNetServiceBuilder serviceBuilder, bool clone = false)
    {
        serviceBuilder.Services.AddPiranhaDistributedCache();

        return serviceBuilder;
    }
}