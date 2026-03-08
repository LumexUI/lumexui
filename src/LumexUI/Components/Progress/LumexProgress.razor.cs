// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;
using System.Globalization;

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
	[Parameter] public bool Indeterminate { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether to show the value label with the progress percentage.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>. When <see langword="true"/>, the value label is shown.
	/// </remarks>
	[Parameter] public bool ShowValueLabel { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether the progress bar is disabled.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>.
	/// </remarks>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the progress bar should have a striped appearance.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="false"/>.
	/// </remarks>
	[Parameter] public bool Striped { get; set; }

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
			[nameof( Indeterminate )] = Indeterminate.ToString(),
			[nameof( Striped )] = Striped.ToString(),
			[nameof( Disabled )] = Disabled.ToString(),
		} );

		UpdateAdditionalAttributes();

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


	private string? GetAriaValueNow()
	{
		if( Indeterminate )
			return null;

		return ClampedValue.ToString( "0.##", CultureInfo.InvariantCulture );
	}

	private string? GetAriaValueMin()
	{
		return MinValue.ToString( "0.##", CultureInfo.InvariantCulture );
	}

	private string? GetAriaValueMax()
	{
		return MaxValue.ToString( "0.##", CultureInfo.InvariantCulture );
	}

	private string? GetAriaValueText()
	{
		return Indeterminate ? ( string.IsNullOrWhiteSpace( ValueLabel ) ? "Loading" : ValueLabel ) : ValueText;
	}

	private string GetTransformValue()
	{
		var width = Indeterminate ? 100 : Percentage;
		var transformWith = 100 - width;
		return String.Format("-{0}{1}", ( transformWith ).ToString( "0.##", CultureInfo.InvariantCulture ) ,"%");
	}

	private string GetIndicatorStyle()
	{
		var transform = $"transform: translateX({GetTransformValue()})";

		if( Striped )
		{
			var (color, lightColor) = Color switch
			{
				ThemeColor.Default => ("var(--color-default)", "var(--color-default-100)"),
				ThemeColor.Primary => ("var(--color-primary)", "var(--color-primary-100)"),
				ThemeColor.Secondary => ("var(--color-secondary)", "var(--color-secondary-100)"),
				ThemeColor.Success => ("var(--color-success)", "var(--color-success-100)"),
				ThemeColor.Warning => ("var(--color-warning)", "var(--color-warning-100)"),
				ThemeColor.Danger => ("var(--color-danger)", "var(--color-danger-100)"),
				ThemeColor.Info => ("var(--color-info)", "var(--color-info-100)"),
				_ => ("currentColor", "rgba(255, 255, 255, 0.15)")
			};

			return $"{transform}; --stripe-color: {color}; --stripe-color-light: {lightColor};";
		}

		return transform;
	}

	private void UpdateAdditionalAttributes()
	{
		var hasAriaLabel = AdditionalAttributes is not null && AdditionalAttributes.ContainsKey( "aria-label" );
		if( !hasAriaLabel )
		{
			if( ConvertToDictionary( AdditionalAttributes, out var additionalAttributes ) )
			{
				AdditionalAttributes = additionalAttributes;
			}

			additionalAttributes["aria-label"] = Label ?? ( Indeterminate ? "Loading" : "Progress" );
		}
	}

	[ExcludeFromCodeCoverage]
	private static bool ConvertToDictionary( IReadOnlyDictionary<string, object>? source, out Dictionary<string, object> result )
	{
		var newDictionaryCreated = true;

		if( source is null )
		{
			result = [];
		}
		else if( source is Dictionary<string, object> currentDictionary )
		{
			result = currentDictionary;
			newDictionaryCreated = false;
		}
		else
		{
			result = [];

			foreach( var item in source )
			{
				result.Add( item.Key, item.Value );
			}
		}

		return newDictionaryCreated;
	}
}

