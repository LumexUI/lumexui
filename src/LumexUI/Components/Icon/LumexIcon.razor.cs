// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents an icon.
/// </summary>
public partial class LumexIcon : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the icon.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the name or path of the icon to be displayed.
	/// </summary>
	[Parameter] public string? Icon { get; set; }

	/// <summary>
	/// Gets or sets the dimensions of the icon.
	/// </summary>
	/// <remarks>
	/// The default is 24x24
	/// </remarks>
	[Parameter] public Dimensions Size { get; set; } = new( "24" );

	/// <summary>
	/// Gets or sets a color of the icon.
	/// </summary>
	[Parameter] public ThemeColor Color { get; set; }

	private protected override string? RootClass =>
		TwMerge.Merge( Styles.Icon.GetStyles( this ) );

	private string? FontIconStyle => ElementStyle.Empty()
		.Add( "font-size", $"{Size.W}px", when: Size.W == Size.H )
		.Add( RootStyle )
		.ToString();

	[MemberNotNullWhen( true, nameof( Icon ) )]
	private bool IsSvgIcon => !string.IsNullOrEmpty( Icon ) && Icon.Trim().StartsWith( '<' );

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( ChildContent is not null && ( Size.W != Size.H ) )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires equal width and height dimensions for " +
				$"{nameof( Size )} if used as a font icon." );
		}
	}
}
