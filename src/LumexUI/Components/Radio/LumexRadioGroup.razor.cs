// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexRadioGroup<TValue> : LumexInputBase<TValue>, ISlotComponent<RadioGroupSlots>, ILumexRadioValueProvider<TValue>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the radio group.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the label for the radio group.
    /// </summary>
    [Parameter] public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the description for the radio group.
    /// </summary>
    [Parameter] public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets the orientation of the radio group.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Orientation.Vertical"/>
    /// </remarks>
    [Parameter] public Orientation Orientation { get; set; } = Orientation.Vertical;
    
    /// <summary>
    /// Gets or sets the CSS class names for the radio group slots.
    /// </summary>
    [Parameter] public RadioGroupSlots? Classes { get; set; }
    
    /// <summary>
    /// Gets or sets the CSS class names for the radio button slots.
    /// </summary>
    [Parameter] public RadioSlots? RadioClasses { get; set; }
    
    private readonly RadioGroupContext<TValue> _context;
    
    /// <summary>
    /// Sets the currently-selected value of the radio group.
    /// </summary>
    /// <param name="value"></param>
    public async ValueTask SetValueAsync( TValue? value )
    {
        await SetCurrentValueAsync( value );
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, [MaybeNullWhen(false)] out TValue result )
    {
        try
        {
            // We special-case bool values because BindConverter reserves bool conversion for conditional attributes.
            if (typeof(TValue) == typeof(bool))
            {
                if (TryConvertToBool(value, out result))
                {
                    return true;
                }
            }
            else if (typeof(TValue) == typeof(bool?))
            {
                if (TryConvertToNullableBool(value, out result))
                {
                    return true;
                }
            }
            else if (BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var parsedValue))
            {
                result = parsedValue;
                return true;
            }

            result = default;
            
            return false;
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException($"{Label} does not support the type '{typeof(TValue)}'.", ex);
        }
    }
    
    private static bool TryConvertToBool(string? value, out TValue result)
    {
        if (bool.TryParse(value, out var @bool))
        {
            result = (TValue)(object)@bool;
            return true;
        }

        result = default!;
        return false;
    }

    private static bool TryConvertToNullableBool(string? value, out TValue result)
    {
        if (string.IsNullOrEmpty(value))
        {
            result = default!;
            return true;
        }

        return TryConvertToBool(value, out result);
    }

    /// <inheritdoc />
    protected override ValueTask SetValidationMessageAsync( bool parsingFailed )
    {
        return ValueTask.CompletedTask;
    }
    
    private protected override string? RootClass =>
        TwMerge.Merge( RadioGroup.GetStyles( this ) );

    private string? LabelClass =>
        TwMerge.Merge( RadioGroup.GetLabelStyles( this ) );

    private string? WrapperClass =>
        TwMerge.Merge( RadioGroup.GetWrapperStyles( this ) );

    private string? DescriptionClass =>
        TwMerge.Merge( RadioGroup.GetDescriptionStyles( this ) );
    
    /// <summary>
    /// Initializes a new instance of the <see cref="LumexRadioGroup"/>.
    /// </summary>
    public LumexRadioGroup()
    {
        _context = new RadioGroupContext<TValue>( this );
    }

    public TValue? CurrentValue { get; }
}