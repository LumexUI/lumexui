// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the brand section of the <see cref="LumexNavbar"/>.
/// </summary>
public partial class LumexNavbarBrand : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar brand section.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal NavbarContext Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetBrandStyles( this ) );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavbarBrand"/>.
    /// </summary>
    public LumexNavbarBrand()
    {
        As = "div";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarBrand ) );
    }
}