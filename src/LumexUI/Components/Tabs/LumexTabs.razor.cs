// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexTabs : LumexComponentBase, IDisposable
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public TabVariant Variant { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public Size Size { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public Radius Radius { get; set; }

	internal TabsSlots Slots { get; private set; } = default!;

	private readonly TabsContext _context;
	private readonly Memoizer<TabsSlots> _slotsMemoizer;
	private readonly RenderFragment _renderTabs;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexTabs"/>.
	/// </summary>
	public LumexTabs()
	{
		_context = new TabsContext( this );
		_slotsMemoizer = new Memoizer<TabsSlots>();
		_renderTabs = RenderTabs;
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		_context.OnTabsChanged += StateHasChanged;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		// Perform a re-building only if the dependencies have changed
		Slots = _slotsMemoizer.Memoize( GetSlots, [
			Variant,
			Size,
			Class
		] );
	}

	private TabsSlots GetSlots()
	{
		return Tabs.GetStyles( this, TwMerge );
	}

	/// <inheritdoc />
	public void Dispose()
	{
		_context.OnTabsChanged -= StateHasChanged;
	}
}