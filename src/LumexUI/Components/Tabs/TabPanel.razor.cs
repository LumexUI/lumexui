// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Internal;

/// <summary>
/// Represents an internal tab panel component.
/// This component is intended for internal use only.
/// </summary>
[EditorBrowsable( EditorBrowsableState.Never )]
public partial class TabPanel : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the currently selected tab associated with this panel.
	/// </summary>
	/// <remarks>
	/// Internal use only.
	/// </remarks>
	[Parameter] public LumexTab? SelectedTab { get; set; }

	[CascadingParameter] internal TabsContext Context { get; set; } = default!;

	private TabsSlots Slots => Context.Owner.Slots;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( TabPanel ) );
	}
}