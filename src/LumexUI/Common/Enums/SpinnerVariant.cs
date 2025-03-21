// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the visual variants for the <see cref="LumexSpinner"/>.
/// </summary>
public enum SpinnerVariant
{
	/// <summary>
	/// A circular ring-shaped spinner.
	/// </summary>
	Ring,

	/// <summary>
	/// An arc-shaped spinner.
	/// </summary>
	Arc,

	/// <summary>
	/// An arc-shaped spinner with gradient coloring.
	/// </summary>
	ArcGradient,

	/// <summary>
	/// A spinner consisting of dots in a wave animation.
	/// </summary>
	DotsWave,

	/// <summary>
	/// A spinner consisting of dots with fade animation.
	/// </summary>
	DotsFade,

	/// <summary>
	/// A classic spinner style.
	/// </summary>
	Classic
}
