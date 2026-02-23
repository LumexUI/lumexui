// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI;

/// <summary>
/// Provides context information for the progress bar label content.
/// </summary>
public readonly record struct ProgressBarContext
{
	/// <summary>
	/// Gets the percentage value (0-100) representing the progress.
	/// </summary>
	public double Percentage { get; }

	/// <summary>
	/// Gets the normalized value (clamped between 0 and <see cref="MaxValue"/>).
	/// </summary>
	public double ClampedValue { get; }

	/// <summary>
	/// Gets the raw value of the progress bar.
	/// </summary>
	public double Value { get; }

	/// <summary>
	/// Gets the maximum value of the progress bar.
	/// </summary>
	public double MaxValue { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="ProgressBarContext"/> struct.
	/// </summary>
	/// <param name="percentage">The percentage value (0-100).</param>
	/// <param name="clampedValue">The clamped value.</param>
	/// <param name="value">The raw value.</param>
	/// <param name="maxValue">The maximum value.</param>
	public ProgressBarContext( double percentage, double clampedValue, double value, double maxValue )
	{
		Percentage = percentage;
		ClampedValue = clampedValue;
		Value = value;
		MaxValue = maxValue;
	}
}
