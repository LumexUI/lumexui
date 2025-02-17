// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Extensions;
using LumexUI.Variants;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI.Internal;

/// <summary>
/// 
/// </summary>
public partial class MenuItem : LumexComponentBase, ISlotComponent<MenuItemSlots>
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter, EditorRequired] public object Id { get; set; } = default!;

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public string? Description { get; set; }

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
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public MenuItemSlots? Classes { get; set; }

	[CascadingParameter] internal MenuContext Context { get; set; } = default!;

	private Menu Menu => Context.Owner;

	private Dictionary<string, ComponentSlot> _slots = [];
	private bool _disabled;

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

		var menuItem = Styles.MenuItem.Style( TwVariant );
		_slots = menuItem( new()
		{
			[nameof( Color )] = Color.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Disabled )] = _disabled.ToString(),
		} );
	}

	private Task OnClickAsync( MouseEventArgs args )
	{
		return OnClick.InvokeAsync( args );
	}
}