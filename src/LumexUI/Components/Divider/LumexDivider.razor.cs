// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a divider for separating content.
/// </summary>
public partial class LumexDivider : LumexComponentBase
{
	/// <summary>
	/// Gets or sets a value defining the divider's orientation.
	/// </summary>
	/// <remarks>
	/// Default value is <see cref="Orientation.Horizontal" />
	/// </remarks>
	[Parameter] public Orientation Orientation { get; set; }

	private protected override string? RootClass =>
		TwMerge.Merge( Divider.GetStyles( this ) );

	private new string As => Orientation is Orientation.Horizontal ? "hr" : "div";
}