// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a badge for displaying contextual information or status indicators.
/// </summary>
public partial class LumexBadge : LumexComponentBase, ISlotComponent<BadgeSlots>
{
	/// <summary>
	/// Gets or sets the content to render inside the badge.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to display inside the badge.
	/// </summary>
	[Parameter] public object? Content { get; set; }

	/// <summary>
	/// Gets or sets the size of the badge.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the visual variant of the badge.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Variant.Solid"/>
	/// </remarks>
	[Parameter] public Variant Variant { get; set; }

	/// <summary>
	/// Gets or sets the color of the badge.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the placement of the badge relative to its anchor element.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="BadgePlacement.TopEnd"/>.
	/// </remarks>
	[Parameter] public BadgePlacement Placement { get; set; } = BadgePlacement.TopEnd;

	/// <summary>
	/// Gets or sets a value indicating whether an outline is shown around the badge.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>.
	/// </remarks>
	[Parameter] public bool ShowOutline { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether the badge is hidden.
	/// </summary>
	[Parameter] public bool Invisible { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the badge slots.
	/// </summary>
	[Parameter] public BadgeSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexBadge"/>.
	/// </summary>
	public LumexBadge()
	{
		As = "span";
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var badge = Styles.Badge.Style( TwMerge );
		_slots = badge( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Placement )] = Placement.ToString(),
			[nameof( ShowOutline )] = ShowOutline.ToString(),
		} );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( BadgeSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( BadgeSlots.Badge ) => styles( Classes?.Badge ),
			_ => throw new NotImplementedException()
		};
	}
}