// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LumexUI;

/// <summary>
/// A component that represents a badge for displaying contextual information or status indicators.
/// </summary>
public partial class LumexBadge : LumexComponentBase, ISlotComponent<BadgeSlots>
{
	internal const string Dot = "Dot";

	/// <summary>
	/// Gets or sets the content around which the badge is rendered.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render inside the badge.
	/// </summary>
	[Parameter] public RenderFragment? Content { get; set; }

	/// <summary>
	/// Gets or sets the content to display inside the badge.
	/// </summary>
	[Parameter] public object? Text { get; set; }

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
	/// The default value is <see cref="BadgeVariant.Solid"/>
	/// </remarks>
	[Parameter] public BadgeVariant Variant { get; set; }

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
	/// Gets or sets a value indicating whether the badge content is limited to a single character.
	/// If true, the badge will have the same width and height.
	/// </summary>
	[Parameter] public bool OneChar { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the badge slots.
	/// </summary>
	[Parameter] public BadgeSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	private bool _isOneChar;
	private bool _isDot;

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
		if( Text is not null && Content is not null )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires one of {nameof( Text )} or {nameof( Content )}, but both were specified." );
		}

		if( Text is not ( string or int or null ) )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires the {nameof( Text )} parameter to be of type {typeof( string )} or {typeof( int )}."
			);
		}

		_isOneChar = OneChar || Text switch
		{
			string str => str.Length == 1,
			int i => i.ToString().Length == 1,
			_ => false
		};

		if( Content is null )
		{
			_isDot = Text switch
			{
				string str => str.Length == 0,
				null => true,
				_ => false
			};
		}

		var badge = Styles.Badge.Style( TwMerge );
		_slots = badge( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Placement )] = Placement.ToString(),
			[nameof( ShowOutline )] = ShowOutline.ToString(),
			[nameof( OneChar )] = _isOneChar.ToString(),
			[nameof( Dot )] = _isDot.ToString(),
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
			nameof( BadgeSlots.Base ) => styles( Classes?.Base ),
			nameof( BadgeSlots.Badge ) => styles( Classes?.Badge, Class ),
			_ => throw new NotImplementedException()
		};
	}
}