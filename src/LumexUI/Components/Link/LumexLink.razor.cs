// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexLink : LumexLinkBase
{
    /// <summary>
    /// Gets or sets the underline style for the link.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Underline.None"/>
    /// </remarks>
    [Parameter] public Underline Underline { get; set; }

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
            var attributes = new Dictionary<string, object>()
            {
                ["href"] = Href
            };

            if( External )
            {
                attributes["target"] = "_blank";
                attributes["rel"] = "noopener noreferrer";
            }

            if( AdditionalAttributes is not null )
            {
                foreach( var attribute in AdditionalAttributes )
                {
                    attributes[attribute.Key] = attribute.Value;
                }
            }

            return attributes;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexLink"/>.
    /// </summary>
    public LumexLink()
    {
        As = "a";
    }
}