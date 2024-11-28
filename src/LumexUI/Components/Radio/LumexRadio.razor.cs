// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexRadio<TValue> : LumexInputBase<TValue>, ISlotComponent<RadioSlots>
{
    /// <summary>
    /// Gets or sets the CSS class names for the checkbox slots.
    /// </summary>
    [Parameter]
    public RadioSlots? Classes { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered inside the input.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter]
    internal RadioGroupContext<TValue>? Context { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Radio.GetStyles( this ) );

    private string? WrapperClass =>
        TwMerge.Merge( Radio.GetWrapperStyles( this ) );

    private string? ControlClass =>
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

        Color = parameters.TryGetValue<ThemeColor>( nameof(Color), out var color )
            ? color
            : Context?.Owner.Color ?? ThemeColor.Primary;

        Size = parameters.TryGetValue<Size>( nameof(Size), out var size )
            ? size
            : Context?.Owner.Size ?? Size.Medium;
    }

    /// <summary>
    /// Handles the change event asynchronously.
    /// Derived classes can override this to specify custom behavior when the input's value changes.
    /// </summary>
    /// <param name="args">The change event arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected virtual Task OnChangeAsync( ChangeEventArgs args )
    {
        if( GetDisabledState() || GetReadOnlyState() || Context is null)
        {
            return Task.CompletedTask;
        }

        return Context.ChangeEventCallback.InvokeAsync( args );
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out TValue result )
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override ValueTask SetValidationMessageAsync( bool parsingFailed )
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the disabled state of the input.
    /// Derived classes can override this to determine the input's disabled state.
    /// </summary>
    /// <returns>A <see cref="bool"/> value indicating whether the input is disabled.</returns>
    protected internal virtual bool GetDisabledState() => Disabled || ( Context?.Owner.Disabled ?? false );

    /// <summary>
    /// Gets the readonly state of the input.
    /// Derived classes can override this to determine the input's readonly state.
    /// </summary>
    /// <returns>A <see cref="bool"/> value indicating whether the input is readonly.</returns>
    protected internal virtual bool GetReadOnlyState() => ReadOnly || ( Context?.Owner.ReadOnly ?? false );
}