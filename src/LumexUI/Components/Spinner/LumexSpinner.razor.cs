// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a spinner for indicating loading states.
/// </summary>
public partial class LumexSpinner : LumexComponentBase, ISlotComponent<SpinnerSlots>
{
	/// <summary>
	/// Gets or sets the content to render inside the spinner.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the label displayed alongside the spinner.
	/// </summary>
	[Parameter] public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the size of the spinner.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the color of the spinner.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Primary"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

	/// <summary>
	/// Gets or sets the color of the spinner label.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.None"/>.
	/// </remarks>
	[Parameter] public ThemeColor LabelColor { get; set; }

	/// <summary>
	/// Gets or sets the visual variant of the spinner.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="SpinnerVariant.Arc"/>.
	/// </remarks>
	[Parameter] public SpinnerVariant Variant { get; set; } = SpinnerVariant.Arc;

	/// <summary>
	/// Gets or sets the CSS class names for the spinner slots.
	/// </summary>
	[Parameter] public SpinnerSlots? Classes { get; set; }

	private string AriaLabel => Label ?? "Loading";

	private readonly RenderFragment _renderLabel;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexAvatar"/>.
	/// </summary>
	public LumexSpinner()
	{
		_renderLabel = RenderLabel;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var spinner = Styles.Spinner.Style( TwMerge );
		_slots = spinner( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( LabelColor )] = LabelColor.ToString()
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
			nameof( SpinnerSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( SpinnerSlots.Wrapper ) => styles( Classes?.Wrapper ),
			nameof( SpinnerSlots.Label ) => styles( Classes?.Label ),
			nameof( SpinnerSlots.Circle1 ) => styles( Classes?.Circle1 ),
			nameof( SpinnerSlots.Circle2 ) => styles( Classes?.Circle2 ),
			nameof( SpinnerSlots.Dots ) => styles( Classes?.Dots ),
			nameof( SpinnerSlots.Bars ) => styles( Classes?.Bars ),
			_ => throw new NotImplementedException()
		};
	}
}