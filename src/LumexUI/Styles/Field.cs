// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Field
{
	// Vertical orientation styles
	private readonly static string _verticalBase = ElementClass.Empty()
		.Add( "flex" )
		.Add( "flex-col" )
		.Add( "gap-1.5" )
		.ToString();

	private readonly static string _verticalLabel = ElementClass.Empty()
		.Add( "text-small" )
		.Add( "text-foreground-500" )
		.ToString();

	private readonly static string _verticalHelper = ElementClass.Empty()
		.Add( "flex" )
		.Add( "flex-col" )
		.Add( "gap-1" )
		.Add( "px-1" )
		.ToString();

	// Horizontal orientation styles
	private readonly static string _horizontalBase = ElementClass.Empty()
		.Add( "inline-flex" )
		.Add( "items-start" )
		.Add( "gap-2" )
		.ToString();

	private readonly static string _horizontalContent = ElementClass.Empty()
		.Add( "flex-shrink-0" )
		.ToString();

	private readonly static string _horizontalLabelWrapper = ElementClass.Empty()
		.Add( "flex" )
		.Add( "flex-col" )
		.Add( "gap-0.5" )
		.ToString();

	private readonly static string _horizontalLabel = ElementClass.Empty()
		.Add( "text-small" )
		.Add( "text-foreground" )
		.ToString();

	private readonly static string _horizontalHelper = ElementClass.Empty()
		.Add( "flex" )
		.Add( "flex-col" )
		.Add( "gap-1" )
		.ToString();

	// Shared styles
	private readonly static string _description = ElementClass.Empty()
		.Add( "text-tiny" )
		.Add( "text-foreground-400" )
		.ToString();

	private readonly static string _errorMessage = ElementClass.Empty()
		.Add( "text-tiny" )
		.Add( "text-danger" )
		.ToString();

	private readonly static string _disabled = ElementClass.Empty()
		.Add( "opacity-disabled" )
		.Add( "pointer-events-none" )
		.ToString();

	private readonly static string _required = ElementClass.Empty()
		.Add( "after:content-['*']" )
		.Add( "after:text-danger" )
		.Add( "after:ms-0.5" )
		.ToString();

	public static string GetStyles( LumexField field )
	{
		var isVertical = field.Orientation is Orientation.Vertical;

		return ElementClass.Empty()
			.Add( _verticalBase, when: isVertical )
			.Add( _horizontalBase, when: !isVertical )
			.Add( _disabled, when: field.Disabled )
			.Add( field.Class )
			.Add( field.Classes?.Base )
			.ToString();
	}

	public static string GetLabelStyles( LumexField field )
	{
		var isVertical = field.Orientation is Orientation.Vertical;

		return ElementClass.Empty()
			.Add( _verticalLabel, when: isVertical )
			.Add( _horizontalLabel, when: !isVertical )
			.Add( _required, when: field.Required )
			.Add( field.Classes?.Label )
			.ToString();
	}

	public static string GetContentStyles( LumexField field )
	{
		var isVertical = field.Orientation is Orientation.Vertical;

		return ElementClass.Empty()
			.Add( _horizontalContent, when: !isVertical )
			.Add( field.Classes?.Content )
			.ToString();
	}

	public static string GetLabelWrapperStyles( LumexField field )
	{
		return ElementClass.Empty()
			.Add( _horizontalLabelWrapper )
			.Add( field.Classes?.LabelWrapper )
			.ToString();
	}

	public static string GetHelperStyles( LumexField field )
	{
		var isVertical = field.Orientation is Orientation.Vertical;

		return ElementClass.Empty()
			.Add( _verticalHelper, when: isVertical )
			.Add( _horizontalHelper, when: !isVertical )
			.Add( field.Classes?.Helper )
			.ToString();
	}

	public static string GetDescriptionStyles( LumexField field )
	{
		return ElementClass.Empty()
			.Add( _description )
			.Add( field.Classes?.Description )
			.ToString();
	}

	public static string GetErrorMessageStyles( LumexField field )
	{
		return ElementClass.Empty()
			.Add( _errorMessage )
			.Add( field.Classes?.ErrorMessage )
			.ToString();
	}
}
