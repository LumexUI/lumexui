// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Services;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge.Extensions;
using TailwindMerge.Models;

namespace LumexUI.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="IServiceCollection"/> interface.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the LumexUI services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    public static void AddLumexServices( this IServiceCollection services )
    {
        services.AddTailwindMerge();
        services.AddPopoverService();
    }

    private static void AddTailwindMerge( this IServiceCollection services )
    {
        services.AddTailwindMerge( options =>
        {
            options.Extend( new ExtendedConfig()
            {
                ClassGroups = new()
                {
                    ["font-size"] = new ClassGroup( "text", ["tiny", "small", "medium", "large"] ),
                    ["border-radius"] = new ClassGroup( "rounded", ["small", "medium", "large"] ),
                    ["shadow"] = new ClassGroup( "shadow", ["small", "medium", "large"] ),
                }
            } );
        } );
    }

    private static void AddPopoverService( this IServiceCollection services )
    {
        services.AddScoped<IPopoverService, PopoverService>();
    }
}
