// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace LumexUI;

/// <summary>
/// A component representing a navigation link within the application.
/// </summary>
public partial class LumexNavLink : LumexLinkBase
{
    /// <summary>
    /// Gets or sets a value representing the URL matching behavior.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="NavLinkMatch.All"/>
    /// </remarks>
    [Parameter] public NavLinkMatch Match { get; set; } = NavLinkMatch.All;

    /// <summary>
    /// Gets or sets the CSS class name applied to the navigation link 
    /// when the current route matches the <see cref="LumexLinkBase.Href"/>.
    /// </summary>
    [Parameter] public string? ActiveClass { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexNavLink"/>.
    /// </summary>
    public LumexNavLink()
    {
        As = "li";
    }
}
