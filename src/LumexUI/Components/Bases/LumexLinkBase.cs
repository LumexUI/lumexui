using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A base class for link components.
/// </summary>
public abstract class LumexLinkBase : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the link.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets a value representing the URL of the link.
    /// </summary>
    [Parameter] public string Href { get; set; } = "#";

    /// <summary>
    /// Gets or sets a color of the link.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Primary"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

    /// <summary>
    /// Gets or sets a value indicating whether the link is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }
}
