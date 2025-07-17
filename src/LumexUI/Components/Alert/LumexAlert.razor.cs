// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexAlert : LumexComponentBase, ISlotComponent<AlertSlots>
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? TitleContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? DescriptionContent { get; set; }

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
	[Parameter] public string? Title { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public string? Icon { get; set; }

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Medium"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Primary"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="AlertVariant.Flat"/>.
	/// </remarks>
	[Parameter] public AlertVariant Variant { get; set; } = AlertVariant.Flat;

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public bool HideIcon { get; set; }

	/// <summary>
	/// 
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
	/// 
	/// </summary>
	[Parameter] public AlertSlots? Classes { get; set; }

	private string AlertIcon => Icon ?? _icons[Color];
	private bool HasTitle => TitleContent is not null || !string.IsNullOrEmpty( Title );
	private bool HasDescription => DescriptionContent is not null || !string.IsNullOrEmpty( Description );

	private readonly Dictionary<ThemeColor, string> _icons = new()
	{
		[ThemeColor.Default] = Icons.Rounded.Info,
		[ThemeColor.Primary] = Icons.Rounded.Info,
		[ThemeColor.Secondary] = Icons.Rounded.Info,
		[ThemeColor.Success] = Icons.Rounded.CheckCircle,
		[ThemeColor.Warning] = Icons.Rounded.GppMaybe,
		[ThemeColor.Danger] = Icons.Rounded.Report,
		[ThemeColor.Info] = Icons.Rounded.Info
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