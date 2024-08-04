// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

// Some of the code was taken from
// https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputBase.cs

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// Represents a base class for input components.
/// </summary>
/// <typeparam name="TValue">The type of the input value.</typeparam>
public abstract class LumexInputBase<TValue> : LumexComponentBase
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
    /// Gets or sets a color of the input.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    /// <summary>
    /// Gets or sets the size of the input.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Size.Medium"/>
    /// </remarks>
    [Parameter] public Size Size { get; set; } = Size.Medium;

    /// <summary>
    /// Gets or sets the value of the input. This should be used with two-way binding.
    /// </summary>
    [Parameter] public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets a callback that is fired when the value of the input changes.
    /// </summary>
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets a callback that is fired when the input receives focus.
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnFocus { get; set; }

    /// <summary>
    /// Gets or sets a callback that is fired when the input loses focus.
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter] public Expression<Func<TValue>>? ValueExpression { get; set; }

    /// <summary>
    /// Gets or sets the current value of the input.
    /// </summary>
    protected TValue? CurrentValue
    {
        get => Value;
        set => _ = SetCurrentValueAsync( value );
    }

    /// <summary>
    /// Gets or sets the current value of the input, represented as a string.
    /// </summary>
    protected string? CurrentValueAsString
    {
        get => _parsingFailed ? _incomingValueBeforeParsing : FormatValueAsString( CurrentValue );
        set => _ = SetCurrentValueAsStringAsync( value );
    }

    /// <summary>
    /// Gets or sets a value indicating whether the input is focused.
    /// </summary>
    protected bool Focused { get; set; }

    private bool _parsingFailed;
    private bool _hasInitializedParameters;
    private string? _incomingValueBeforeParsing;
    private Type? _nullableUnderlyingType;

    /// <summary>
    /// Gives focus to an input component given its <see cref="ElementReference"/>
    /// </summary>
    /// <returns>The <see cref="ValueTask"/> representing the asynchronous focus operation.</returns>
    public ValueTask FocusAsync()
    {
        if( !ElementReference.HasValue )
        {
            return ValueTask.CompletedTask;
        }

        Focused = true;
        return ElementReference.Value.FocusAsync();
    }

    /// <inheritdoc />
    public override Task SetParametersAsync( ParameterView parameters )
    {
        parameters.SetParameterProperties( this );

        if( !_hasInitializedParameters )
        {
            _nullableUnderlyingType = Nullable.GetUnderlyingType( typeof( TValue ) );
            _hasInitializedParameters = true;
        }

        return base.SetParametersAsync( ParameterView.Empty );
    }

    /// <summary>
    /// Sets the current value of the input.
    /// </summary>
    /// <param name="value">The value to set.</param>
    protected internal async Task SetCurrentValueAsync( TValue? value )
    {
        var hasChanged = !EqualityComparer<TValue>.Default.Equals( value, Value );
        if( hasChanged )
        {
            _parsingFailed = false;

            Value = value;
            await ValueChanged.InvokeAsync( value );
        }
    }

    /// <summary>
    /// Sets the current value of the input, represented as a string.
    /// </summary>
    /// <param name="value">The value to set.</param>
    protected internal async Task SetCurrentValueAsStringAsync( string? value )
    {
        _incomingValueBeforeParsing = value;

        if( _nullableUnderlyingType is not null && string.IsNullOrEmpty( value ) )
        {
            // Assume if it's a nullable type, null/empty inputs should correspond to default(T)
            // Then all subclasses get nullable support almost automatically (they just have to
            // not reject Nullable<T> based on the type itself).
            _parsingFailed = false;
            CurrentValue = default!;
        }
        else if( TryParseValueFromString( value, out var parsedValue ) )
        {
            _parsingFailed = false;
            await SetCurrentValueAsync( parsedValue );
        }
        else
        {
            _parsingFailed = true;
        }
    }

    /// <summary>
    /// Handles the focus event asynchronously.
    /// Derived classes can override this to specify custom behavior when the component receives focus.
    /// </summary>
    /// <param name="args">The focus event arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous focus operation.</returns>
    protected virtual async Task OnFocusAsync( FocusEventArgs args )
    {
        await FocusAsync();
        await OnFocus.InvokeAsync( args );
    }

    /// <summary>
    /// Handles the blur event asynchronously.
    /// Derived classes can override this to specify custom behavior when the component loses focus.
    /// </summary>
    /// <param name="args">The blur event arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous blur operation.</returns>
    protected virtual Task OnBlurAsync( FocusEventArgs args )
    {
        Focused = false;
        return OnBlur.InvokeAsync( args );
    }

    /// <summary>
    /// Formats the input value as a string.
    /// Derived classes can override this to determine the formatting used for <see cref="CurrentValueAsString"/>.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representation of the input value.</returns>
    protected virtual string? FormatValueAsString( TValue? value ) => value?.ToString();

    /// <summary>
    /// Parses a string to create an instance of <typeparamref name="TValue"/>.
    /// Derived classes can override this to change how <see cref="CurrentValueAsString"/> interprets incoming values.
    /// </summary>
    /// <param name="value">The string value to be parsed.</param>
    /// <param name="result">An instance of <typeparamref name="TValue"/>.</param>
    /// <returns><see langword="true"/> if the value could be parsed; otherwise <see langword="false"/>.</returns>
    protected abstract bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out TValue? result );
}
