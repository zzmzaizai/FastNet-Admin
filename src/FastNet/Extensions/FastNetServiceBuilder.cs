 

using Microsoft.Extensions.DependencyInjection;

namespace FastNet;

/// <summary>
/// Service builder for application startup.
/// </summary>
public class FastNetServiceBuilder
{
    /// <summary>
    /// The inner service collection.
    /// </summary>
    public readonly IServiceCollection Services;

    /// <summary>
    /// Gets/sets if runtime compilation should be enabled.
    /// </summary>
    public bool AddRazorRuntimeCompilation { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="services">The current service collection</param>
    public FastNetServiceBuilder(IServiceCollection services)
    {
        Services = services;
    }
}
