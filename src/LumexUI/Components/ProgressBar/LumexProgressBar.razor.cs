// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

using Styles = LumexUI.Styles;

namespace LumexUI;

/// <summary>
/// A component representing a progress bar for displaying progress or loading states.
/// </summary>
public partial class LumexProgressBar : LumexComponentBase, ISlotComponent<ProgressBarSlots>
{
	/// <summary>
	/// Gets or sets the content to be rendered as the label.
	/// </summary>
	[Parameter] public RenderFragment<ProgressBarContext>? LabelContent { get; set; }

	/// <summary>
	/// Gets or sets the progress value (0 to <see cref="MaxValue"/>).
	/// </summary>
	/// <remarks>
	/// The default value is 0. When <see cref="IsLoadingBar"/> is <see langword="true"/>, this value is ignored.
	/// </remarks>
	[Parameter] public double Value { get; set; }

	/// <summary>
	/// Gets or sets the maximum value for the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is 100. This determines the upper bound for the <see cref="Value"/> parameter.
	/// </remarks>
	[Parameter] public double MaxValue { get; set; } = 100;

	/// <summary>
	/// Gets or sets a value indicating whether this is a loading bar with infinite animation.
	/// </summary>
	/// <remarks>
	/// When <see langword="true"/>, the progress bar will display an animated loading indicator
	/// instead of showing a specific progress value.
	/// </remarks>
	[Parameter] public bool IsLoadingBar { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to show the label with the progress percentage.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>. When <see cref="IsLoadingBar"/> is <see langword="true"/>,
	/// the label is not shown.
	/// </remarks>
	[Parameter] public bool ShowLabel { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the label should be displayed inline within the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>. When <see langword="true"/>, the label is rendered
	/// inside the progress bar track instead of below it.
	/// </remarks>
	[Parameter] public bool IsLabelInline { get; set; }

	/// <summary>
	/// Gets or sets the position of the inline label within the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Align.Center"/>. This parameter only applies when
	/// <see cref="IsLabelInline"/> is <see langword="true"/>.
	/// </remarks>
	[Parameter] public Align LabelPosition { get; set; } = Align.Center;

	/// <summary>
	/// Gets or sets the color of the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Primary"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

	/// <summary>
	/// Gets or sets the size of the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the border radius of the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets the CSS class names for the progress bar slots.
	/// </summary>
	[Parameter] public ProgressBarSlots? Classes { get; set; }

	private double NormalizedValue => Math.Clamp( Value, 0, MaxValue );
	private double Percentage => MaxValue > 0 ? ( NormalizedValue / MaxValue ) * 100 : 0;
	private string FillWidth => IsLoadingBar ? "100%" : $"{Percentage.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}%";
	private bool ShouldShowLabel => ShowLabel && !IsLoadingBar && ( LabelContent is not null || NormalizedValue > 0 );
	private ProgressBarContext Context => new( Percentage, NormalizedValue, Value, MaxValue );

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var progressBar = Styles.ProgressBar.Style( TwMerge );
		_slots = progressBar( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( IsLoadingBar )] = IsLoadingBar.ToString(),
			[nameof( IsLabelInline )] = IsLabelInline.ToString(),
			[nameof( LabelPosition )] = LabelPosition.ToString(),
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
			nameof( ProgressBarSlots.Track ) => styles( Classes?.Track, Class ),
			nameof( ProgressBarSlots.Fill ) => styles( Classes?.Fill ),
			nameof( ProgressBarSlots.Label ) => styles( Classes?.Label ),
			_ => throw new NotImplementedException()
		};
	}
}
