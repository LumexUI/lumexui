using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace LumexUI.Extensions;

[ExcludeFromCodeCoverage]
internal static class TypeExtensions
{
    private static readonly HashSet<Type?> _numericTypes = [
        typeof(sbyte),
        typeof(byte),
        typeof(short),
        typeof(ushort),
        typeof(int),
        typeof(uint),
        typeof(long),
        typeof(ulong),
        typeof(float),
        typeof(double),
        typeof(decimal),
        typeof(BigInteger)
    ];

    public static bool IsNumeric( this Type type )
    {
        return _numericTypes.Contains( type ) ||
               _numericTypes.Contains( Nullable.GetUnderlyingType( type ) );
    }

    public static bool IsString( this Type type )
    {
        return typeof( string ) == type;
    }
}
