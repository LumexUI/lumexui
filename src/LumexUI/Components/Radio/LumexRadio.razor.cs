// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexRadio : LumexBooleanInputBase, ISlotComponent<RadioSlots>
{
    /// <summary>
    /// Gets or sets the icon to be used for indicating a checked state of the checkbox.
    /// </summary>
    [Parameter] public string? CheckIcon { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the checkbox slots.
    /// </summary>
    [Parameter] public RadioSlots? Classes { get; set; }

    [CascadingParameter] internal RadioGroupContext? Context { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Radio.GetStyles( this ) );

    private string? WrapperClass =>
        TwMerge.Merge( Radio.GetWrapperStyles( this ) );

    private string? IconClass =>
        TwMerge.Merge( Radio.GetControlStyles( this ) );

    private string? LabelClass =>
        TwMerge.Merge( Radio.GetLabelStyles( this ) );


    /// <summary>
    /// Initializes a new instance of the <see cref="LumexRadio"/>.
    /// </summary>
    public LumexRadio()
    {
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync( ParameterView parameters )
    {
        await base.SetParametersAsync( parameters );

        Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
            ? color
            : Context?.Owner.Color ?? ThemeColor.Primary;

        Size = parameters.TryGetValue<Size>( nameof( Size ), out var size )
            ? size
            : Context?.Owner.Size ?? Size.Medium;
    }

    /// <inheritdoc />
    protected internal override bool GetDisabledState() => 
        Disabled || ( Context?.Owner.Disabled ?? false );

    /// <inheritdoc />
    protected internal override bool GetReadOnlyState() =>
        ReadOnly || ( Context?.Owner.ReadOnly ?? false );
}
