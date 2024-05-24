// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexCardBody : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the card body.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal CardContext Context { get; set; } = default!;

    private protected override string? RootClass
        => TwMerge.Merge( Card.GetBodyStyles( this ) );

    protected override void OnInitialized()
    {
        CardContext.ThrowMissingParentComponentException( Context, nameof( LumexCardBody ) );
    }
}