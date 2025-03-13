// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using AngleSharp.Dom;

namespace LumexUI.Tests.Extensions;

internal static class AngleSharpExtensions
{
	public static IElement? FindByTestId( this IRenderedFragment fragment, string id )
	{
		try
		{
			return fragment.Find( $"[data-testid={id}]" );
		}
		catch
		{
			return null;
		}
	}

	public static IElement? FindBySlot( this IRenderedFragment fragment, string slot )
	{
		try
		{
			return fragment.Find( $"[data-slot={slot}]" );
		}
		catch
		{
			return null;
		}
	}
}
