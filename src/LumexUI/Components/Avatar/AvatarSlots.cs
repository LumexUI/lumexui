// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the slot names for the <see cref="LumexAvatar"/>, 
/// used to assign CSS classes to different parts of the component.
/// </summary>
[ExcludeFromCodeCoverage]
public class AvatarSlots : ISlot
{
	/// <summary>
	/// Gets or sets the CSS class for the root slot.
	/// </summary>
	[Obsolete( "Deprecated. This will be removed in the future releases. Use the 'Base' slot instead." )]
	public string? Root { get; }

	/// <summary>
	/// Gets or sets the CSS class for the base slot.
	/// </summary>
	public string? Base { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the img slot.
	/// </summary>
	public string? Img { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the fallback slot.
	/// </summary>
	public string? Fallback { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the name slot.
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the icon slot.
	/// </summary>
	public string? Icon { get; set; }
}
