// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

[CompositionComponent( typeof( LumexRadioGroup<> ) )]
public partial class LumexRadio<TValue> : LumexComponentBase, ISlotComponent<RadioSlots>
{
    /// <summary>
    /// Gets or sets a value indicating whether the input is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the input is read-only.
    /// </summary>
    [Parameter] public bool ReadOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the input is required.
    /// </summary>
    [Parameter] public bool Required { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the input is invalid.
    /// </summary>
    [Parameter] public bool Invalid { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the checkbox slots.
    /// </summary>
    [Parameter] public RadioSlots? Classes { get; set; }

    /// <summary>
    /// Gets or sets a color of the radio button.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

    /// <summary>
    /// Gets or sets the size of the radio button.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Size.Medium"/>
    /// </remarks>
    [Parameter] public Size Size { get; set; } = Size.Medium;

    /// <summary>
    /// Gets or sets the description for this particular option.
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the value of this input.
    /// </summary>
    [Parameter] public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered inside the input.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter( Name = "Context" )] internal RadioGroupContext<TValue> Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( Radio.GetStyles( this ) );

    private string? ControlWrapperClass =>
        TwMerge.Merge( Radio.GetControlWrapperStyles( this ) );

    private string? ControlClass =>
        TwMerge.Merge( Radio.GetControlStyles( this ) );

    private string? LabelWrapperClass =>
        TwMerge.Merge( Radio.GetLabelWrapperStyles( this ) );

    private string? LabelClass =>
        TwMerge.Merge( Radio.GetLabelStyles( this ) );

    private string? DescriptionClass =>
        TwMerge.Merge( Radio.GetDescriptionStyles( this ) );

    /// <inheritdoc />
    public override async Task SetParametersAsync( ParameterView parameters )
    {
        await base.SetParametersAsync( parameters );

        Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
            ? color
            : Context.Owner.Color;

        Size = parameters.TryGetValue<Size>( nameof( Size ), out var size )
            ? size
            : Context.Owner.Size;
    }

    /// <summary>
    /// Gets the disabled state of the input.
    /// Derived classes can override this to determine the input's disabled state.
    /// </summary>
    /// <returns>A <see cref="bool"/> value indicating whether the input is disabled.</returns>
    protected internal bool GetDisabledState() => Disabled || Context.Owner.Disabled;

    /// <summary>
    /// Gets the readonly state of the input.
    /// Derived classes can override this to determine the input's readonly state.
    /// </summary>
    /// <returns>A <see cref="bool"/> value indicating whether the input is readonly.</returns>
    protected internal bool GetReadOnlyState() => ReadOnly || Context.Owner.ReadOnly;

    /// <summary>
    /// Indicates whether this radio button is selected.
    /// Derived classes can override this to determine the input's selected state.
    /// </summary>
    /// <returns><c>true</c> if the <see cref="Value"/> of this <see cref="LumexRadio{TValue}"/> matches
    /// the <c>CurrentValue</c> property in the parent <see cref="Context"/>. Otherwise <c>false</c>.</returns>
    protected internal bool GetSelectedState() => Context.CurrentValue?.Equals( Value ) ?? false;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexRadio<TValue> ) );
    }
}