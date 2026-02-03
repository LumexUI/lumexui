namespace BlazorApp2.Utilities;

public record struct ElementClass
{
    private string? _stringBuffer;

    public ElementClass( string? value )
    {
        _stringBuffer = value;
    }

    public static ElementClass Default( string? value ) => new( value );

    public ElementClass Add( string? value )
    {
        if( !string.IsNullOrEmpty( value ) )
        {
            _stringBuffer += " " + value;
        }

        return this;
    }

    public ElementClass Add( string? value, bool when ) => when ? Add( value ) : this;

    public readonly override string ToString()
        => !string.IsNullOrEmpty( _stringBuffer ) ? _stringBuffer.Trim() : string.Empty;

	public static implicit operator string( ElementClass el ) => el.ToString();
}