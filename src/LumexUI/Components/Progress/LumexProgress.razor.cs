// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a progress bar for displaying progress or loading states.
/// </summary>
public partial class LumexProgress : LumexComponentBase, ISlotComponent<ProgressSlots>
{
	/// <summary>
	/// Gets or sets the label to be rendered above the progress bar.
	/// </summary>
	[Parameter] public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the ARIA label for accessibility. If not provided, defaults to the Label or "Progress"/"Loading".
	/// </summary>
	/// <remarks>
	/// This is required for accessibility when the <see cref="Label"/> prop is not provided.
	/// </remarks>
	[Parameter] public string? AriaLabel { get; set; }

	/// <summary>
	/// Gets or sets custom content for the value label.
	/// </summary>
	[Parameter] public string? ValueLabel { get; set; }

	/// <summary>
	/// Gets or sets the progress value (from <see cref="MinValue"/> to <see cref="MaxValue"/>).
	/// </summary>
	/// <remarks>
	/// The default value is 0.
	/// </remarks>
	[Parameter] public double Value { get; set; }

	/// <summary>
	/// Gets or sets the minimum value for the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is 0.
	/// </remarks>
	[Parameter] public double MinValue { get; set; }

	/// <summary>
	/// Gets or sets the maximum value for the progress bar.
	/// </summary>
	/// <remarks>
	/// The default value is 100. This determines the upper bound for the <see cref="Value"/> parameter.
	/// </remarks>
	[Parameter] public double MaxValue { get; set; } = 100;

	/// <summary>
	/// Gets or sets a value indicating whether the progress bar is in an indeterminate state.
	/// </summary>
	/// <remarks>
	/// When <see langword="true"/>, the progress bar will display an animated loading indicator
	/// instead of showing a specific progress value. This is useful when the duration of an operation is unknown.
	/// </remarks>
	[Parameter] public bool IsIndeterminate { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to show the value label with the progress percentage.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>. When <see langword="true"/>, the value label is shown.
	/// </remarks>
	[Parameter] public bool ShowValueLabel { get; set; } = false;

	/// <summary>
	/// Gets or sets a value indicating whether animation is disabled.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>. When <see langword="true"/>, animations are not applied.
	/// </remarks>
	[Parameter] public bool DisableAnimation { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the progress bar is disabled.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>.
	/// </remarks>
	[Parameter] public bool IsDisabled { get; set; }

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
	/// The default value is <see cref="Radius.Full"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Full;

	/// <summary>
	/// Gets or sets the CSS class names for the progress bar slots.
	/// </summary>
	[Parameter] public ProgressSlots? Classes { get; set; }

	private double ClampedValue => MaxValue > MinValue ? Math.Clamp( Value, MinValue, MaxValue ) : MinValue;
	private double Percentage => MaxValue > MinValue ? ( ( ClampedValue - MinValue ) / ( MaxValue - MinValue ) ) * 100 : 0;
	private string IndicatorWidth => IsIndeterminate ? "100%" : $"{Percentage.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}%";

	private string ComputedAriaLabel => AriaLabel ?? Label ?? (IsIndeterminate ? "Loading" : "Progress");
	private string ValueText => !string.IsNullOrEmpty( ValueLabel ) ? ValueLabel : $"{Percentage:F0}%";

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var progressBar = Styles.Progress.Style( TwMerge );
		_slots = progressBar( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( IsIndeterminate )] = IsIndeterminate.ToString(),
			[nameof( DisableAnimation )] = DisableAnimation.ToString(),
			[nameof( IsDisabled )] = IsDisabled.ToString(),
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
			nameof( ProgressSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( ProgressSlots.LabelWrapper ) => styles( Classes?.LabelWrapper ),
			nameof( ProgressSlots.Label ) => styles( Classes?.Label ),
			nameof( ProgressSlots.Value ) => styles( Classes?.Value ),
			nameof( ProgressSlots.Track ) => styles( Classes?.Track ),
			nameof( ProgressSlots.Indicator ) => styles( Classes?.Indicator ),
			_ => throw new NotImplementedException()
		};
	}
}

