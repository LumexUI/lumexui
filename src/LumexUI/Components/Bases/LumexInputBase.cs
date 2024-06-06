// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

// Some of the code was taken from
// https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputBase.cs

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

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
    /// Gets or sets a color of the input.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; }

    /// <summary>
    /// Gets or sets the border radius of the input.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="Radius.Medium"/>
    /// </remarks>
    [Parameter] public Radius Radius { get; set; } = Radius.Medium;

    /// <summary>
    /// Gets or sets the size of the input.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Size.Medium"/>
    /// </remarks>
    [Parameter] public Size Size { get; set; } = Size.Medium;

    /// <summary>
    /// Gets or sets the value of the input. This should be used with two-way binding.
    /// </summary>
    [Parameter] public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets a callback that updates the bound value.
    /// </summary>
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter] public Expression<Func<TValue>>? ValueExpression { get; set; }

    /// <summary>
    /// Gets or sets the associated <see cref="ElementReference"/>.
    /// </summary>
    public ElementReference Element { get; protected set; }

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

    private bool _parsingFailed;
    private bool _hasInitializedParameters;
    private string? _incomingValueBeforeParsing;
    private Type? _nullableUnderlyingType;

    /// <inheritdoc />
    public override Task SetParametersAsync( ParameterView parameters )
    {
        parameters.SetParameterProperties( this );

        if( !_hasInitializedParameters )
        {
            // This is the first run
            // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()
            if( ValueExpression is null )
            {
                throw new InvalidOperationException(
                    $"{GetType()} requires a value for the '{nameof( ValueExpression )}' parameter. " +
                    $"Normally this is provided automatically when using '@bind-Value'." );
            }

            _nullableUnderlyingType = Nullable.GetUnderlyingType( typeof( TValue ) );
            _hasInitializedParameters = true;
        }

        return base.SetParametersAsync( ParameterView.Empty );
    }

    /// <summary>
    /// Parses a string to create an instance of <typeparamref name="TValue"/>.
    /// Derived classes can override this to change how <see cref="CurrentValueAsString"/> interprets incoming values.
    /// </summary>
    /// <param name="value">The string value to be parsed.</param>
    /// <param name="result">An instance of <typeparamref name="TValue"/>.</param>
    /// <returns><see langword="true"/> if the value could be parsed; otherwise <see langword="false"/>.</returns>
    protected abstract bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out TValue? result );

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
    /// Formats the input value as a string.
    /// Derived classes can override this to determine the formatting used for <see cref="CurrentValueAsString"/>.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representation of the input value.</returns>
    protected virtual string? FormatValueAsString( TValue? value ) => value?.ToString();
}
