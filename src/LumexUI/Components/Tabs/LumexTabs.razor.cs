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
	/// <remarks>
	/// The default value is <see cref="TabVariant.Solid"/>
	/// </remarks>
	[Parameter] public TabVariant Variant { get; set; }

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public bool FullWidth { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

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
			FullWidth,
			Disabled,
			Variant,
			Radius,
			Color,
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