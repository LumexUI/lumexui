// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a menu, containing one or more <see cref="MenuItem"/>.
/// </summary>
public abstract partial class Menu : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the content to render inside the menu.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render when the menu is empty.
	/// </summary>
	[Parameter] public RenderFragment? EmptyContent { get; set; }

	/// <summary>
	/// Gets or sets the visual variant of the menu.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="MenuVariant.Solid"/>.
	/// </remarks>
	[Parameter] public MenuVariant Variant { get; set; }

	/// <summary>
	/// Gets or sets the theme color of the menu.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets a collection of items that should be disabled in the menu.
	/// </summary>
	[Parameter] public ICollection<string>? DisabledItems { get; set; }

	internal MenuSlots? Classes { get; set; }
	internal MenuItemSlots? ItemClasses { get; set; }

	private readonly static RenderFragment _emptyContent = builder =>
	{
		builder.AddContent( 0, "No items." );
	};

	private readonly MenuContext _context;
	private readonly RenderFragment _renderItems;
	private readonly RenderFragment _renderEmptyContent;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="Menu"/>.
	/// </summary>
	public Menu()
	{
		_context = new MenuContext( this );
		_renderItems = RenderItems;
		_renderEmptyContent = RenderEmptyContent;

		As = "ul";
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var menu = Styles.Menu.Style( TwMerge );
		_slots = menu();
	}
}