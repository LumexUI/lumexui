using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;

using LumexUI.Common;
using LumexUI.Docs.Common;
using LumexUI.Docs.Components;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Pages.Api;

public partial class Api
{
    [Parameter] public string? ComponentName { get; set; }

    [CascadingParameter] private DocsContentLayout Layout { get; set; } = default!;

    private readonly XmlDocReader _xmlDocReader;

    private object? _component;
    private MethodInfo[] _methods = [];
    private PropertyInfo[] _properties = [];

    public Api()
    {
        _xmlDocReader = new XmlDocReader();
    }

    protected override void OnInitialized()
    {
        if( string.IsNullOrEmpty( ComponentName ) )
        {
            return;
        }

        var componentName = $"Lumex{FromKebabToPascalCase( ComponentName )}";
        var componentType = Type.GetType( $"LumexUI.{componentName}, LumexUI" );

        // To find the components with typeparams (need a better solution)
        componentType ??= Type.GetType( $"LumexUI.{componentName}`1, LumexUI" );

        if( componentType is null || !typeof( IComponent ).IsAssignableFrom( componentType ) )
        {
            return;
        }

        if( componentType.IsGenericTypeDefinition )
        {
            componentType = componentType.MakeGenericType( [typeof( T )] );
        }

        _component = Activator.CreateInstance( componentType );
        _properties = componentType.GetProperties();
        _methods = componentType
            .GetMethods( BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly )
            .Where( m => !m.IsSpecialName )
            .ToArray();

        var headings = new List<Heading>()
        {
            new("Examples"),
            new("Properties")
        };

        if( _methods.Length > 0 )
        {
            headings.Add( new( "Methods" ) );
        }

        Layout.Initialize(
            title: GetTypeName( componentType ),
            category: "Components API",
            description: $"API reference documentation for the {GetTypeName( componentType )} component. Explore details about its parameters, types and other APIs.",
            headings: [.. headings]
        );
    }

    private static string FromKebabToPascalCase( string value )
    {
        var words = value.Split( '-' );
        for( var i = 0; i < words.Length; i++ )
        {
            words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase( words[i] );
        }

        return string.Concat( words );
    }

    private static string GetAggregatorComponentName( object component )
    {
        var componentType = component.GetType();
        if( !Attribute.IsDefined( componentType, typeof( CompositionComponentAttribute ) ) )
        {
            return GetTypeName( componentType );
        }

        var attr = (CompositionComponentAttribute)Attribute.GetCustomAttribute( componentType, typeof( CompositionComponentAttribute ) )!;
        return GetTypeName( attr.AggregatorType );
    }

    [SuppressMessage( "Style", "IDE0011:Add braces", Justification = "<Pending>" )]
    private static string GetTypeName( Type type )
    {
        // Check if the type is a nullable type
        if( Nullable.GetUnderlyingType( type ) is not null )
        {
            var underlyingType = Nullable.GetUnderlyingType( type )!;
            return $"{GetTypeName( underlyingType )}?";
        }

        // Check if the type is a primitive type or common type
        if( type == typeof( int ) )
            return "int";
        if( type == typeof( string ) )
            return "string";
        if( type == typeof( bool ) )
            return "bool";
        if( type == typeof( float ) )
            return "float";
        if( type == typeof( double ) )
            return "double";
        if( type == typeof( decimal ) )
            return "decimal";
        if( type == typeof( object ) )
            return "object";
        if( type == typeof( char ) )
            return "char";
        if( type == typeof( byte ) )
            return "byte";
        if( type == typeof( sbyte ) )
            return "sbyte";
        if( type == typeof( short ) )
            return "short";
        if( type == typeof( long ) )
            return "long";
        if( type == typeof( uint ) )
            return "uint";
        if( type == typeof( ushort ) )
            return "ushort";
        if( type == typeof( ulong ) )
            return "ulong";

        // Check if the type is a generic type
        if( type.IsGenericType )
        {
            var typeName = type.Name[..type.Name.IndexOf( '`' )];
            var genericArgs = type.GetGenericArguments();
            var genericArgsString = string.Join( ", ", Array.ConvertAll( genericArgs, GetTypeName ) );

            return $"{typeName}<{genericArgsString}>";
        }

        return type.Name;
    }

    private string? GetDefaultValue( PropertyInfo property )
    {
        var value = property.GetValue( _component );
        if( value is null )
        {
            return "-";
        }

        return value.GetType() switch
        {
            Type t when t.IsClass || ( t.IsValueType && !t.IsPrimitive && !t.IsEnum ) => "-",
            Type t when t == typeof( string ) => $"\"{value}\"",
            Type t when t == typeof( bool ) => (bool)value ? "true" : "false",
            Type t when Nullable.GetUnderlyingType( t ) is not null => "-",
            _ => value.ToString(),
        };
    }

    private string? GetDescription( MemberInfo member )
    {
        return _xmlDocReader.GetSummary( member );
    }

    private sealed class XmlDocReader
    {
        private readonly string _path;
        private readonly XDocument _doc;
        private readonly IEnumerable<XElement> _descendants;

        public XmlDocReader()
        {
            _path = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "LumexUI.xml" );
            _doc = XDocument.Load( _path );
            _descendants = _doc.Descendants( "member" );
        }

        public string? GetSummary( MemberInfo member )
        {
            var memberName = GetMemberXmlName( member );
            var memberElement = _descendants.FirstOrDefault( x => x.Attribute( "name" )?.Value == memberName );
            return memberElement?.Element( "summary" )?.Value.Trim();
        }

        public static string? GetMemberXmlName( MemberInfo member )
        {
            if( member is PropertyInfo property )
            {
                var declaringType = property.DeclaringType;
                return $"P:{declaringType?.Namespace}.{declaringType?.Name}.{property.Name}";
            }

            if( member is MethodInfo method )
            {
                var declaringType = method.DeclaringType;
                var parameters = string.Join( ",", method.GetParameters().Select( p => p.ParameterType.FullName ) );
                return $"M:{declaringType?.Namespace}.{declaringType?.Name}.{method.Name}({parameters})";
            }

            return null;
        }
    }
}