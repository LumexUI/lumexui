// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Extensions;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI;

/// <summary>
/// A component representing a collapsible menu for the <see cref="LumexNavbar"/>.
/// </summary>
public partial class LumexNavbarMenu : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar menu.
    /// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal NavbarContext Context { get; set; } = default!;

    [Inject] private IJSRuntime JS { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetMenuStyles( this ) );

    private protected override string? RootStyle =>
        ElementStyle.Empty()
            .Add( "--navbar-height", $"{Context.Owner.Height}" )
            .Add( base.RootStyle )
            .ToString();

    private LumexCollapse? _collapse;

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

        Context.Register( this );
        Context.OnMenuToggle += StateHasChanged;
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync( bool firstRender )
    {
        if( firstRender )
        {
            await _collapse!.ElementReference.PortalToAsync();
        }
    }
}