// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace LumexUI;

/// <summary>
/// A component representing a navigation link within the application.
/// </summary>
public partial class LumexNavLink : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content of the navigation link.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets a value representing the URL route to be navigated to.
    /// </summary>
    [Parameter] public string Href { get; set; } = "#";
    
    /// <summary>
    /// Gets or sets a value representing the URL matching behavior.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="NavLinkMatch.All"/>
    /// </remarks>
    [Parameter] public NavLinkMatch Match { get; set; } = NavLinkMatch.All;

    /// <summary>
    /// Gets or sets a color of the navigation link.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Primary"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

    /// <summary>
    /// Gets or sets the CSS class name applied to the navigation link 
    /// when the current route matches the <see cref="Href"/>.
    /// </summary>
    [Parameter] public string? ActiveClass { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the navigation link is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavLink"/>.
    /// </summary>
    public LumexNavLink()
    {
        As = "li";
    }
}
