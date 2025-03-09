// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Utilities;

/// <summary>
/// Represents a CSS class for the rendered element.
/// </summary>
public record struct ElementClass
{
    private string? _stringBuffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementClass"/> with the specified value.
    /// </summary>
    /// <param name="value">The value to initialize the <see cref="ElementClass"/> instance with.</param>
    public ElementClass( string? value )
    {
        _stringBuffer = value;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ElementClass"/>.
    /// </summary>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public static ElementClass Empty() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="ElementClass"/> with the specified value.
    /// </summary>
    /// <param name="value">The value to be set for the new <see cref="ElementClass"/> instance.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public static ElementClass Default( string? value ) => new( value );

    /// <summary>
    /// Adds a CSS class to the current <see cref="ElementClass"/> instance.
    /// </summary>
    /// <param name="value">The CSS class to add.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( string? value )
    {
        if( !string.IsNullOrEmpty( value ) )
        {
            _stringBuffer += " " + value;
        }

        return this;
    }

    /// <summary>
    /// Conditionally adds a CSS class to the current <see cref="ElementClass"/> instance.
    /// </summary>
    /// <param name="value">The CSS class to add.</param>
    /// <param name="when">A boolean value that determines whether the CSS class should be added.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( string? value, bool when ) => when ? Add( value ) : this;

    /// <summary>
    /// Conditionally adds a CSS class to the current <see cref="ElementClass"/> instance.
    /// </summary>
    /// <param name="value">The CSS class to add.</param>
    /// <param name="when">A function that returns a boolean value determining whether the CSS class should be added.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( string? value, Func<bool> when ) => Add( value, when() );

    /// <summary>
    /// Conditionally adds a CSS class to the current <see cref="ElementClass"/> instance.
    /// </summary>
    /// <param name="value">A function that returns the CSS class to add.</param>
    /// <param name="when">A boolean value that determines whether the CSS class should be added.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( Func<string?> value, bool when ) => when ? Add( value() ) : this;

    /// <summary>
    /// Conditionally adds a CSS class to the current <see cref="ElementClass"/> instance.
    /// </summary>
    /// <param name="value">A function that returns the CSS class to add.</param>
    /// <param name="when">A function that returns a boolean value determining whether the CSS class should be added.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( Func<string?> value, Func<bool> when ) => Add( value, when() );

    /// <summary>
    /// Adds a CSS class from another <see cref="ElementClass"/> instance to the current instance.
    /// </summary>
    /// <param name="elementClass">The <see cref="ElementClass"/> instance whose CSS classes will be added.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( ElementClass elementClass ) => Add( elementClass.ToString() );

    /// <summary>
    /// Conditionally adds a CSS class from another <see cref="ElementClass"/> instance to the current instance.
    /// </summary>
    /// <param name="elementClass">The <see cref="ElementClass"/> instance whose CSS classes will be added.</param>
    /// <param name="when">A boolean value that determines whether the CSS class should be added.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( ElementClass elementClass, bool when ) => when ? Add( elementClass.ToString() ) : this;

    /// <summary>
    /// Conditionally adds a CSS class from another <see cref="ElementClass"/> instance to the current instance.
    /// </summary>
    /// <param name="elementClass">The <see cref="ElementClass"/> instance whose CSS classes will be added.</param>
    /// <param name="when">A function that returns a boolean value determining whether the CSS class should be added.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( ElementClass elementClass, Func<bool> when ) => Add( elementClass, when() );

    /// <summary>
    /// Conditionally adds a CSS class to the current <see cref="ElementClass"/> instance when it exists in the specified additional attributes.
    /// </summary>
    /// <param name="additionalAttributes">The additional attributes.</param>
    /// <returns>An <see cref="ElementClass"/> instance.</returns>
    public ElementClass Add( IReadOnlyDictionary<string, object>? additionalAttributes )
    {
        if( additionalAttributes is null )
        {
            return this;
        }

        if( additionalAttributes.TryGetValue( "class", out var value ) )
        {
            if( value is not null )
            {
                return Add( value.ToString() );
            }
        }

        return this;
    }

    /// <summary>
    /// Returns a string representation of the current <see cref="ElementClass"/> instance.
    /// </summary>
    /// <returns>A trimmed <see cref="string" /> representation of the CSS classes if the internal buffer is not empty; otherwise, an empty string.</returns>
    public readonly override string ToString()
        => !string.IsNullOrEmpty( _stringBuffer ) ? _stringBuffer.Trim() : string.Empty;

	/// <inheritdoc />
	public static implicit operator string( ElementClass el ) => el.ToString();
}