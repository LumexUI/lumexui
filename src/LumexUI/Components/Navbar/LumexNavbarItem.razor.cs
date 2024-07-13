// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a navigation item within the <see cref="LumexNavbarContent"/>.
/// </summary>
public partial class LumexNavbarItem : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar item.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal NavbarContext Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetItemStyles( this ) );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavbarItem"/>.
    /// </summary>
    public LumexNavbarItem()
    {
        As = "li";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarItem ) );
    }
}