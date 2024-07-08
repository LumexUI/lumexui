// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexNavbar : LumexComponentBase, ISlotComponent<NavbarSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the navbar slots.
    /// </summary>
    [Parameter] public NavbarSlots? Classes { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetStyles( this ) );

    private readonly NavbarContext _context;

    public LumexNavbar()
    {
        _context = new( this );

        As = "header";
    }
}