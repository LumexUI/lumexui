// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Shared.Icons;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component that represents an alert used to display important messages or statuses.
/// </summary>
public partial class LumexAlert : LumexComponentBase, ISlotComponent<AlertSlots>
{
	/// <summary>
	/// Gets or sets the content to render inside the alert.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render as the alert title.
	/// </summary>
	[Parameter] public RenderFragment? TitleContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render as the alert description.
	/// </summary>
	[Parameter] public RenderFragment? DescriptionContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the start of the alert.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the end of the alert.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render as the alert icon.
	/// </summary>
	[Parameter] public RenderFragment? IconContent { get; set; }

	/// <summary>
	/// Gets or sets the title of the alert.
	/// </summary>
	[Parameter] public string? Title { get; set; }

	/// <summary>
	/// Gets or sets the description of the alert.
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the border radius of the alert.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets the color of the alert.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the visual variant of the alert.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="AlertVariant.Flat"/>
	/// </remarks>
	[Parameter] public AlertVariant Variant { get; set; } = AlertVariant.Flat;

	/// <summary>
	/// Gets or sets a value indicating whether the icon is hidden.
	/// </summary>
	[Parameter] public bool HideIcon { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the alert can be closed.
	/// </summary>
	[Parameter] public bool Closeable { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the alert is visible.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>
	/// </remarks>
	[Parameter] public bool Visible { get; set; } = true;

	/// <summary>
	/// Gets or sets the callback invoked when the <see cref="Visible"/> property changes.
	/// </summary>
	[Parameter] public EventCallback<bool> VisibleChanged { get; set; }

	/// <summary>
	/// Gets or sets the callback invoked when the alert is closed.
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the alert slots.
	/// </summary>
	[Parameter] public AlertSlots? Classes { get; set; }

	private Type Icon => _icons[Color];
	private bool HasTitle => TitleContent is not null || !string.IsNullOrEmpty( Title );
	private bool HasDescription => DescriptionContent is not null || !string.IsNullOrEmpty( Description );

	private readonly Dictionary<ThemeColor, Type> _icons = new()
	{
		[ThemeColor.None] = typeof( InfoFilledIcon ),
		[ThemeColor.Default] = typeof( InfoFilledIcon ),
		[ThemeColor.Primary] = typeof( InfoFilledIcon ),
		[ThemeColor.Secondary] = typeof( InfoFilledIcon ),
		[ThemeColor.Success] = typeof( CircleCheckFilledIcon ),
		[ThemeColor.Warning] = typeof( ShieldAlertFilledIcon ),
		[ThemeColor.Danger] = typeof( OctagonAlertFilledIcon ),
		[ThemeColor.Info] = typeof( InfoFilledIcon )
	};

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var alert = Styles.Alert.Style( TwMerge );
		_slots = alert( new()
		{
			[nameof( Color )] = Color.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( HideIcon )] = HideIcon.ToString(),
		} );
	}

	private async Task OnCloseAsync()
	{
		Visible = false;
		await VisibleChanged.InvokeAsync( false );
		await OnClose.InvokeAsync();
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( AlertSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( AlertSlots.MainWrapper ) => styles( Classes?.MainWrapper ),
			nameof( AlertSlots.Title ) => styles( Classes?.Title ),
			nameof( AlertSlots.Description ) => styles( Classes?.Description ),
			nameof( AlertSlots.CloseButton ) => styles( Classes?.CloseButton ),
			nameof( AlertSlots.IconWrapper ) => styles( Classes?.IconWrapper ),
			nameof( AlertSlots.Icon ) => styles( Classes?.Icon ),
			_ => throw new NotImplementedException()
		};
	}
}