using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Extensions;

internal static class InputExtensions
{
    public static bool TryParseSelectableValueFromString<TValue>(
        this LumexInputBase<TValue> input, 
        string? value, 
        [MaybeNullWhen( false )] out TValue result )
    {
        try
        {
            // We special-case bool values because BindConverter reserves bool conversion for conditional attributes.
            if( typeof( TValue ) == typeof( bool ) )
            {
                if( TryConvertToBool( value, out result ) )
                {
                    return true;
                }
            }
            else if( typeof( TValue ) == typeof( bool? ) )
            {
                if( TryConvertToNullableBool( value, out result ) )
                {
                    return true;
                }
            }
            else if( BindConverter.TryConvertTo<TValue>( value, CultureInfo.CurrentCulture, out var parsedValue ) )
            {
                result = parsedValue;
                return true;
            }

            result = default;
            return false;
        }
        catch( InvalidOperationException ex )
        {
            throw new InvalidOperationException( $"{input.GetType()} does not support the type '{typeof( TValue )}'.", ex );
        }
    }

    private static bool TryConvertToBool<TValue>( string? value, out TValue result )
    {
        if( bool.TryParse( value, out var @bool ) )
        {
            result = (TValue)(object)@bool;
            return true;
        }

        result = default!;
        return false;
    }

    private static bool TryConvertToNullableBool<TValue>( string? value, out TValue result )
    {
        if( string.IsNullOrEmpty( value ) )
        {
            result = default!;
            return true;
        }

        return TryConvertToBool( value, out result );
    }
}
