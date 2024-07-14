// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a button that toggles the <see cref="LumexNavbarMenu"/>.
/// </summary>
public partial class LumexNavbarMenuToggle : LumexComponentBase
{
    [CascadingParameter] internal NavbarContext Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetToggleStyles( this ) );

    private string? ToggleIconClass =>
        TwMerge.Merge( Navbar.GetToggleIconStyles( this ) );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavbarMenuToggle"/>.
    /// </summary>
    public LumexNavbarMenuToggle()
    {
        As = "button";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarMenuToggle ) );
    }
}