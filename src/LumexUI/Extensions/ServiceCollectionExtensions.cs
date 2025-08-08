// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Motion.Extensions;
using LumexUI.Services;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;
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
		services.AddTwMerge();
		services.AddLumexMotion();
		services.AddThemeService();
	}

	/// <summary>
	/// Adds Lumex services to the specified <see cref="IServiceCollection"/>.
	/// </summary>
	/// <param name="services">The service collection to configure.</param>
	/// <param name="options">An action to configure the <see cref="TwMergeConfig"/>.</param>
	public static void AddLumexServices( this IServiceCollection services, Action<TwMergeConfig> options )
	{
		services.AddTwMerge( options );
		services.AddLumexMotion();
		services.AddThemeService();
	}

	private static void AddTwMerge( this IServiceCollection services )
	{
		services.AddTailwindMerge( options =>
		{
			options.Extend( new ExtendedConfig()
			{
				ClassGroups = new()
				{
					["shadow"] = new ClassGroup( "shadow", ["small", "medium", "large"] ),
					["rounded"] = new ClassGroup( "rounded", ["small", "medium", "large"] ),
					["opacity"] = new ClassGroup( "opacity", ["hover", "focus", "disabled", "divider"] ),
					["leading"] = new ClassGroup( "leading", ["tiny", "small", "medium", "large"] ),
					["font-size"] = new ClassGroup( "text", ["tiny", "small", "medium", "large"] ),
				}
			} );
		} );
	}

	private static void AddTwMerge( this IServiceCollection services, Action<TwMergeConfig> options )
	{
		services.AddTwMerge();
		services.Configure( options );
	}

	private static void AddThemeService( this IServiceCollection services )
	{
		services.AddScoped<ThemeService>();
	}
}
