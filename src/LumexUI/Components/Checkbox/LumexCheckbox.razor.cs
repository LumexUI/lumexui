// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexCheckbox : LumexInputBase<bool>, ISlotComponent<CheckboxSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the checkbox.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the icon to be used for indicating a checked state of the checkbox.
    /// </summary>
    [Parameter] public string? CheckIcon { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the checkbox slots.
    /// </summary>
    [Parameter] public CheckboxSlots? Classes { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Checkbox.GetStyles( this ) );

    private string WrapperClass =>
        TwMerge.Merge( Checkbox.GetWrapperStyles( this ) );

    private string IconClass =>
        TwMerge.Merge( Checkbox.GetIconStyles( this ) );

    private string LabelClass =>
        TwMerge.Merge( Checkbox.GetLabelStyles( this ) );

    private readonly RenderFragment _renderCheckIcon;

    private bool Checked => CurrentValue;

    public LumexCheckbox()
    {
        _renderCheckIcon = RenderCheckIcon;
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, out bool result )
    {
        throw new NotSupportedException(
            $"This component does not parse string inputs. " +
            $"Bind to the '{nameof( CurrentValue )}' property, not '{nameof( CurrentValueAsString )}'." );
    }

    private Task OnChangeAsync( ChangeEventArgs args )
    {
        if( Disabled || ReadOnly )
        {
            return Task.CompletedTask;
        }

        return SetCurrentValueAsync( (bool)args.Value! );
    }
}