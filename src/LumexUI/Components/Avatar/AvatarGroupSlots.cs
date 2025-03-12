// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the slot names for the <see cref="LumexAvatarGroup"/>, 
/// used to assign CSS classes to different parts of the component.
/// </summary>
[ExcludeFromCodeCoverage]
public class AvatarGroupSlots : ISlot
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
	/// Gets or sets the CSS class for the count slot.
	/// </summary>
	public string? Count { get; set; }
}
