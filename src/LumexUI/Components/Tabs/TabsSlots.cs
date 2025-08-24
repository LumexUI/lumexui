// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexTabs"/> component.
/// </summary>
public class TabsSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the tab list container that holds all tabs.
	/// </summary>
	public string? TabList { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for an individual tab within the tab list.
	/// </summary>
	public string? Tab { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the content inside a tab.
	/// </summary>
	public string? TabContent { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the panel associated with the selected tab.
	/// </summary>
	public string? TabPanel { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the cursor indicator that highlights the active tab.
	/// </summary>
	public string? Cursor { get; set; }
}
