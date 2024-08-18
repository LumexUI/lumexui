// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the trigger element for a <see cref="LumexPopover"/> component, 
/// which controls the display of the popover.
/// </summary>
public partial class LumexPopoverTrigger : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the popover trigger.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets a color of the popover.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    [CascadingParameter] internal PopoverContext Context { get; set; } = default!;

    private string _id = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexPopoverTrigger"/>.
    /// </summary>
    public LumexPopoverTrigger()
    {
        As = "button";
    }

    public override async Task SetParametersAsync( ParameterView parameters )
    {
        await base.SetParametersAsync( parameters );

        Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
            ? color
            : Context.Owner.Color;
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
