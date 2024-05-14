// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

internal record Button
{
	private static string Base => CssBuilder.Empty()
		.AddClass( "inline-flex" )
		.AddClass( "items-center" )
		.AddClass( "justify-center" )
		.AddClass( "appearance-none" )
		.AddClass( "outline-none" )
		.AddClass( "select-none" )
		.AddClass( "whitespace-nowrap" )
		.AddClass( "min-w-max" )
		.AddClass( "subpixel-antialiased" )
		.AddClass( "overflow-hidden" )
		.AddClass( "bg-blue-400" )
		.AddClass( "text-white" )
		.AddClass( "hover:opacity-80" )
		.Build();

	private static string Disabled => CssBuilder.Empty()
		.AddClass( "opacity-disabled" )
		.AddClass( "pointer-events-none" )
		.Build();

	private static string FullWidth => CssBuilder.Empty()
		.AddClass( "w-full" )
		.Build();

	private static string GetSize( Size size ) => size switch
	{
		Size.Small => "min-w-16 h-8 px-3 gap-2 text-sm rounded-lg",
		Size.Medium => "min-w-20 h-10 px-4 gap-2 text-base rounded-xl",
		Size.Large => "min-w-24 h-12 px-6 gap-2 text-lg rounded-xl",
		_ => throw new NotImplementedException()
	};

	public static string GetStyles( LumexButton button )
	{
		var styles = new CssBuilder()
			.AddClass( Base )
			.AddClass( Disabled, when: button.Disabled )
			.AddClass( FullWidth, when: button.FullWidth )
			.AddClass( GetSize( button.Size ) )
			.Build();

		return styles;
	}
}
