// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexLink : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the link.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets a value representing the URL route to be navigated to.
    /// </summary>
    [Parameter] public string Href { get; set; } = "#";

    /// <summary>
    /// Gets or sets a color of the link.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ThemeColor.Primary"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

    /// <summary>
    /// Gets or sets the underline style for the link.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Underline.None"/>
    /// </remarks>
    [Parameter] public Underline Underline { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the link is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the link should open in the new tab.
    /// </summary>
    /// <remarks>
    /// Sets target to <c>_blank</c> and rel to <c>noopener noreferrer</c>.
    /// </remarks>
    [Parameter] public bool External { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Link.GetStyles( this ) );

    private IReadOnlyDictionary<string, object> Attributes
    {
        get
        {
            var attributes = new Dictionary<string, object>( AdditionalAttributes ?? new Dictionary<string, object>() )
            {
                { "href", Href }
            };

            if( External )
            {
                attributes["target"] = "_blank";
                attributes["rel"] = "noopener noreferrer";
            }

            return attributes;
        }
    }
}