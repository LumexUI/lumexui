// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexAvatarGroup"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class AvatarGroupSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the count slot.
	/// </summary>
	public string? Count { get; set; }
}
