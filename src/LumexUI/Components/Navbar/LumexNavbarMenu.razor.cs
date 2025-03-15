// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace LumexUI;

/// <summary>
/// A component representing a collapsible menu for the <see cref="LumexNavbar"/>.
/// </summary>
[CompositionComponent( typeof( LumexNavbar ) )]
public partial class LumexNavbarMenu : LumexComponentBase, IDisposable
{
	/// <summary>
	/// Gets or sets content to be rendered inside the navbar menu.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal NavbarContext Context { get; set; } = default!;

	[Inject] private NavigationManager NavigationManager { get; set; } = default!;

	internal bool Expanded { get; private set; }

	private protected override string? RootClass =>
		TwMerge.Merge( Navbar.GetMenuStyles( this ) );

	private protected override string? RootStyle =>
		ElementStyle.Empty()
			.Add( "--navbar-height", $"{Context.Owner.Height}" )
			.Add( base.RootStyle )
			.ToString();

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexNavbarMenu"/>.
	/// </summary>
	public LumexNavbarMenu()
	{
		As = "ul";
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarMenu ) );

		Context.RegisterMenu( this );
		NavigationManager.LocationChanged += HandleLocationChanged;
	}

	internal void Toggle()
	{
		Expanded = !Expanded;
		StateHasChanged();
	}

	private void HandleLocationChanged( object? sender, LocationChangedEventArgs e )
	{
		if( Expanded )
		{
			Toggle();
		}
	}

	/// <inheritdoc />
	public void Dispose()
	{
		NavigationManager.LocationChanged -= HandleLocationChanged;
	}
}