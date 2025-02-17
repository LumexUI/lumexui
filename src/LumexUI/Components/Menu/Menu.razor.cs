// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Variants;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Internal;

/// <summary>
/// 
/// </summary>
public partial class Menu : LumexComponentBase, ISlotComponent<MenuSlots>
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? EmptyContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public MenuVariant Variant { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public ICollection<object>? DisabledItems { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public MenuSlots? Classes { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public MenuItemSlots? ItemClasses { get; set; }

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
		var menu = Styles.Menu.Style( TwVariant );
		_slots = menu();
	}
}