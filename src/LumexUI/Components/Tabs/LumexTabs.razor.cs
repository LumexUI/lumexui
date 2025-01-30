// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a tab container, managing a collection of <see cref="LumexTab"/>.
/// </summary>
public partial class LumexTabs : LumexComponentBase, ISlotComponent<TabsSlots>
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the tabs component.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the visual variant of the tabs.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="TabVariant.Solid"/>
	/// </remarks>
	[Parameter] public TabVariant Variant { get; set; }

	/// <summary>
	/// Gets or sets the color theme of the tabs.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the size of the tabs.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the border radius of the tabs.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets a value indicating whether the tabs container is full-width.
	/// </summary>
	[Parameter] public bool FullWidth { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether all tabs are disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a collection of tab IDs that should be disabled.
	/// </summary>
	[Parameter] public ICollection<object>? DisabledItems { get; set; }

	/// <summary>
	/// Gets or sets the ID of the currently selected tab.
	/// </summary>
	[Parameter] public object? SelectedId { get; set; }

	/// <summary>
	/// Gets or sets the callback invoked when the selected tab changes.
	/// </summary>
	[Parameter] public EventCallback<object> SelectedIdChanged { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the tabs slots.
	/// </summary>
	[Parameter] public TabsSlots? Classes { get; set; }

	internal TabsSlots Slots { get; private set; } = default!;

	private readonly TabsContext _context;
	private readonly Memoizer<TabsSlots> _slotsMemoizer;
	private readonly RenderFragment _renderTabs;
	private readonly string _layoutGroupId;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexTabs"/>.
	/// </summary>
	public LumexTabs()
	{
		_context = new TabsContext( this );
		_slotsMemoizer = new Memoizer<TabsSlots>();
		_layoutGroupId = Identifier.New();
		_renderTabs = RenderTabs;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		// Perform a re-building only if the dependencies have changed
		Slots = _slotsMemoizer.Memoize( GetSlots, [
			DisabledItems,
			FullWidth,
			Disabled,
			Variant,
			Radius,
			Color,
			Size,
			Class,
			Classes
		] );
	}

	internal Task SetSelectedIdAsync( object id )
	{
		var hasChanged = !EqualityComparer<object>.Default.Equals( SelectedId, id );
		if( SelectedId is null || hasChanged )
		{
			SelectedId = id;
			return SelectedIdChanged.InvokeAsync( id );
		}

		return Task.CompletedTask;
	}

	private TabsSlots GetSlots()
	{
		return Tabs.GetStyles( this, TwMerge );
	}
}