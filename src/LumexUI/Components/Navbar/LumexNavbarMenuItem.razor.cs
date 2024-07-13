// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a navigation item within the <see cref="LumexNavbarMenu"/>.
/// </summary>
public partial class LumexNavbarMenuItem : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar menu item.
    /// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal NavbarContext Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetMenuItemStyles( this ) );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavbarMenuItem"/>.
    /// </summary>
    public LumexNavbarMenuItem()
    {
        As = "li";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarMenuItem ) );
    }
}