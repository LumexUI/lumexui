// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Variants;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI.Internal;

public partial class MenuItem : LumexComponentBase
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
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

	[CascadingParameter] internal MenuContext Context { get; set; } = default!;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="MenuItem"/>.
	/// </summary>
	public MenuItem()
	{
		As = "li";
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( MenuItem ) );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var menuItem = Styles.MenuItem.Style( TwVariant );
		_slots = menuItem( new()
		{
			[nameof( Disabled )] = Disabled.ToString()
		} );
	}

	private Task OnClickAsync( MouseEventArgs args )
	{
		return OnClick.InvokeAsync( args );
	}
}