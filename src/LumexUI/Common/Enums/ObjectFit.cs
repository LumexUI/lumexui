// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the object fit of an image
/// </summary>
public enum ObjectFit
{
	/// <summary>
	/// No scaling. The image keeps its intrinsic size.
	/// (CSS: object-fit: none)
	/// </summary>
	None,

	/// <summary>
	/// The image is resized to fill the container. May be cropped.
	/// (CSS: object-fit: cover)
	/// </summary>
	Cover,

	/// <summary>
	/// The entire image is visible inside the container, keeping aspect ratio.
	/// (CSS: object-fit: contain)
	/// </summary>
	Contain,

	/// <summary>
	/// The image is stretched to fill the container, ignoring aspect ratio.
	/// (CSS: object-fit: fill)
	/// </summary>
	Fill,

	/// <summary>
	/// Scale the image down to fit only if it is larger than the container.
	/// (CSS: object-fit: scale-down)
	/// </summary>
	ScaleDown
}
