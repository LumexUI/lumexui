// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// <see cref="LumexKbd"/> is a component to display which key or combination of keys performs a given action.
/// </summary>
public partial class LumexKbd : LumexComponentBase, ISlotComponent<KbdSlots>
{
	/// <summary>
	/// Gets or sets the CSS class names for the kbd slots.
	/// </summary>
	public KbdSlots? Classes { get; }
}
