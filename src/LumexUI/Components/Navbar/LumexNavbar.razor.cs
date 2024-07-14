// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a navigation bar.
/// </summary>
public partial class LumexNavbar : LumexComponentBase, ISlotComponent<NavbarSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the maximum width of the navbar wrapper.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="MaxWidth.XLarge"/>
    /// </remarks>
    [Parameter] public MaxWidth MaxWidth { get; set; } = MaxWidth.XLarge;

    /// <summary>
    /// Gets or sets the height of the navbar.
    /// The value should be a valid CSS unit (e.g., 'px', 'rem', '%').
    /// </summary>
    /// <remarks>
    /// The default value is `4rem (64px)`
    /// </remarks>
    [Parameter] public string Height { get; set; } = "4rem";

    /// <summary>
    /// Gets or sets a value indicating whether the navbar is sticky.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false"/>
    /// </remarks>
    [Parameter] public bool Sticky { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the navbar has a bottom border.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false"/>
    /// </remarks>
    [Parameter] public bool Bordered { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the navbar background is blurred.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool Blurred { get; set; } = true;

    /// <summary>
    /// Gets or sets the CSS class names for the navbar slots.
    /// </summary>
    [Parameter] public NavbarSlots? Classes { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetStyles( this ) );

    private string? WrapperClass =>
        TwMerge.Merge( Navbar.GetWrapperStyles( this ) );

    private protected override string? RootStyle =>
        new ElementStyle()
            .Add( "--navbar-height", $"{Height}", when: !string.IsNullOrEmpty( Height ) )
            .ToString();

    private readonly NavbarContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavbar"/>.
    /// </summary>
    public LumexNavbar()
    {
        _context = new( this );

        As = "header";
    }
}