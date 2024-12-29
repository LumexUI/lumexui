// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Utilities;

namespace LumexUI.Styles;

internal class Textarea
{
	private readonly static string _base = ElementClass.Empty()
		.Add( "flex" )
		.Add( "min-h-[60px]" )
		.Add( "rounded-medium" )
		.Add( "border" )
		.Add( "border-input" )
		.Add( "bg-default-100" ) 
		.Add( "px-3" )
		.Add( "py-2" )
		.Add( "text-sm" )
		.Add( "shadow-sm" )
		.Add( "text-default-600" )
		.Add( "placeholder:text-muted-foreground" ) 
		.ToString();

	private readonly static string _focus = ElementClass.Empty()
		.Add( "focus-visible:outline-none" )
		.Add( "focus-visible:ring-0" )
		.ToString();

	private readonly static string _disabled = ElementClass.Empty()
		.Add( "opacity-disabled" )
		.Add( "opacity-50" )
		.Add( "cursor-not-allowed" )
		.Add( "pointer-events-none" )
		.ToString();

	private readonly static string _fullWidth = ElementClass.Empty()
		.Add( "w-full" )
		.ToString();
	
	public static string GetStyles( LumexTextarea textarea )
	{
		return ElementClass.Empty()
			.Add( _base )
			.Add( _focus )
			.Add( _disabled, when: textarea.Disabled )
			.Add( _fullWidth, when: textarea.FullWidth )
			.ToString();
	}
}