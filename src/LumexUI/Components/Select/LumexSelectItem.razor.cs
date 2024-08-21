// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexSelectItem<TValue> : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the select item.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal SelectContext<TValue> Context { get; set; } = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexSelectItem{TValue}"/>.
    /// </summary>
    public LumexSelectItem()
    {
        As = "li";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexSelectItem<TValue> ) );
    }
}
