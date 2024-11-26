using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Extensions;

[ExcludeFromCodeCoverage]
internal static class BooleanExtensions
{
    public static string ToAttributeValue( this bool value ) => value ? "true" : "false";
}
