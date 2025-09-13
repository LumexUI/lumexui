// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// Represents a code block component that displays formatted code.
/// </summary>
public partial class LumexCode : LumexComponentBase
{
	/// <summary>
	/// Get or sets the content to be rendered inside the <see cref="LumexCode"/>.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the color of the <see cref="LumexCode"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the radius of the <see cref="LumexCode"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Small"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Small;

	/// <summary>
	/// Gets or sets the size of the <see cref="LumexCode"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Small"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Small;

	private protected override string? RootClass =>
		TwMerge.Merge( Code.GetStyles( this ) );

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexCode"/>.
	/// </summary>
	public LumexCode()
	{
		As = "code";
	}
}