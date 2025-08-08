// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Extensions;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component that represents an item within a <see cref="Menu"/>.
/// </summary>
public abstract partial class MenuItem : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the content to render inside the menu item.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the start of the menu item.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the end of the menu item.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets the unique identifier for the menu item.
	/// </summary>
	[Parameter] public string Id { get; set; } = Identifier.New();

	/// <summary>
	/// Gets or sets the description of the menu item.
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the visual variant of the menu item.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="MenuVariant.Solid"/>.
	/// </remarks>
	[Parameter] public MenuVariant Variant { get; set; }

	/// <summary>
	/// Gets or sets the theme color of the menu item.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets a value indicating whether a divider should be displayed after the menu item.
	/// </summary>
	[Parameter] public bool ShowDivider { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the menu item is read-only.
	/// </summary>
	[Parameter] public bool ReadOnly { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the menu item is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets the callback invoked when the menu item is clicked.
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

	[CascadingParameter] internal MenuContext Context { get; set; } = default!;

	internal MenuItemSlots? Classes { get; set; }

	private Menu Menu => Context.Owner;

	private Dictionary<string, ComponentSlot> _slots = [];
	private protected bool _disabled;

	/// <summary>
	/// Initializes a new instance of the <see cref="MenuItem"/>.
	/// </summary>
	public MenuItem()
	{
		As = "li";
	}

	/// <inheritdoc />
	public override Task SetParametersAsync( ParameterView parameters )
	{
		parameters.SetParameterProperties( this );

		// Respect own parameter values if provided; otherwise, use the menu's
		Color = parameters.GetParameterProperty( nameof( Color ), fallback: Menu.Color );
		Variant = parameters.GetParameterProperty( nameof( Variant ), fallback: Menu.Variant );

		return base.SetParametersAsync( ParameterView.Empty );
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( MenuItem ) );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( Id is null )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires a value for the {nameof( Id )} parameter." );
		}

		_disabled = Disabled || Menu.DisabledItems?.Contains( Id ) is true;

		var menuItem = Styles.MenuItem.Style( TwMerge );
		_slots = menuItem( new()
		{
			[nameof( Color )] = Color.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Disabled )] = _disabled.ToString(),
			[nameof( ReadOnly )] = ReadOnly.ToString(),
			[nameof( ShowDivider )] = ShowDivider.ToString(),
		} );
	}

	private protected abstract Task OnClickAsync( MouseEventArgs args );
}