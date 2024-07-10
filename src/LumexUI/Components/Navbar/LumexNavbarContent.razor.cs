// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the content section of the <see cref="LumexNavbar"/>.
/// </summary>
public partial class LumexNavbarContent : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar content section.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the alignment for the content section of the navbar.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="null"/> 
    /// </remarks>
    [Parameter] public Align? Align { get; set; }

    [CascadingParameter] internal NavbarContext Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Navbar.GetContentStyles( this ) );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavbarContent"/>.
    /// </summary>
    public LumexNavbarContent()
    {
        As = "ul";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarContent ) );
    }
}