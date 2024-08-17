// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexPopoverTrigger : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the popover trigger.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] internal PopoverContext Context { get; set; } = default!;

    private string _id = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexPopoverTrigger"/>.
    /// </summary>
    public LumexPopoverTrigger()
    {
        As = "button";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexPopoverTrigger ) );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _id = $"popoverref-{Context.Owner.Id}";
    }
}
