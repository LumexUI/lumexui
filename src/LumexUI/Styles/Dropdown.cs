// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;
using LumexUI.Variants;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Dropdown
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwVariant twVariant )
	{
		return _variant ??= twVariant.Create( new VariantConfig()
		{
			Base = new ElementClass()
				.Add( "min-w-[200px]" )
				.Add( "w-full" )
				.Add( "p-1" )
				.ToString()
		} );
	}
}
