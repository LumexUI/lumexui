// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.Extensions.DependencyInjection;

namespace LumexUI.Variants.Extensions;

public static class ServiceCollectionExtensions
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="services"></param>
	public static void AddTailwindVariants( this IServiceCollection services )
	{
		services.AddSingleton<TwVariant>();
		//services.AddSingleton<TwMerge>();
	}
}
