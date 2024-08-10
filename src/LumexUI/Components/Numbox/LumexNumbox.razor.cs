// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

// Portions of the code in this file are based on code from Blazor.
// See https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputNumber.cs

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing an input field for entering/editing numeric types.
/// </summary>
public partial class LumexNumbox<TValue> : LumexInputFieldBase<TValue>
{
    private static readonly string _stepAttributeValue = GetStepAttributeValue();

    /// <inheritdoc />
    public override Task SetParametersAsync( ParameterView parameters )
    {
        parameters.SetParameterProperties( this );

        UpdateAdditionalAttributes();

        return base.SetParametersAsync( parameters );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        SetInputType( "number" );

        base.OnParametersSet();
    }

    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    protected override string? FormatValueAsString( TValue? value )
    {
        // Avoiding a cast to IFormattable to avoid boxing.
        return value switch
        {
            null => null,
            int @int => BindConverter.FormatValue( @int, CultureInfo.InvariantCulture ),
            long @long => BindConverter.FormatValue( @long, CultureInfo.InvariantCulture ),
            short @short => BindConverter.FormatValue( @short, CultureInfo.InvariantCulture ),
            float @float => BindConverter.FormatValue( @float, CultureInfo.InvariantCulture ),
            double @double => BindConverter.FormatValue( @double, CultureInfo.InvariantCulture ),
            decimal @decimal => BindConverter.FormatValue( @decimal, CultureInfo.InvariantCulture ),
            _ => throw new InvalidOperationException( $"Unsupported type {value.GetType()}" )
        };
    }

    private void UpdateAdditionalAttributes()
    {
        var hasStep = AdditionalAttributes is not null && AdditionalAttributes.ContainsKey( "step" );
        if( !hasStep )
        {
            if( ConvertToDictionary( AdditionalAttributes, out var additionalAttributes ) )
            {
                AdditionalAttributes = additionalAttributes;
            }

            additionalAttributes["step"] = _stepAttributeValue;
        }
    }

    private static string GetStepAttributeValue()
    {
        // Unwrap Nullable<T>, because LumexInputBase already deals with the Nullable aspect
        // of it for us. We will only get asked to parse the T for nonempty inputs.
        var targetType = Nullable.GetUnderlyingType( typeof( TValue ) ) ?? typeof( TValue );
        if( targetType == typeof( int ) ||
            targetType == typeof( long ) ||
            targetType == typeof( short ) ||
            targetType == typeof( float ) ||
            targetType == typeof( double ) ||
            targetType == typeof( decimal ) )
        {
            return "1";
        }
        else
        {
            throw new InvalidOperationException( $"The type '{targetType}' is not a supported numeric type." );
        }
    }

    [ExcludeFromCodeCoverage]
    private static bool ConvertToDictionary( IReadOnlyDictionary<string, object>? source, out Dictionary<string, object> result )
    {
        var newDictionaryCreated = true;

        if( source is null )
        {
            result = [];
        }
        else if( source is Dictionary<string, object> currentDictionary )
        {
            result = currentDictionary;
            newDictionaryCreated = false;
        }
        else
        {
            result = [];

            foreach( var item in source )
            {
                result.Add( item.Key, item.Value );
            }
        }

        return newDictionaryCreated;
    }
}
