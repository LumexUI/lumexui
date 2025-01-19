using Microsoft.Extensions.DependencyInjection;

namespace LumexUI.Motion.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="IServiceCollection"/> interface.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    public static void AddLumexMotion( this IServiceCollection services )
    {
        services.AddScoped<MotionInterop>();
    }
}

