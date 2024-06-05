// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Utilities;

/// <summary>
/// Represents an in-line style for the rendered element.
/// </summary>
public record struct ElementStyle
{
    private string? _stringBuffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ElementStyle"/> with a specified style.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The value of the CSS property.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="property"/> is null, empty, or consists exclusively of white-space characters.
    /// </exception>
    public ElementStyle( string property, string? value )
    {
        if( string.IsNullOrWhiteSpace( property ) )
        {
            throw new ArgumentException( "CSS property value cannot be null, empty or consist exlusively of white-space characters.", nameof( property ) );
        }

        _stringBuffer = $"{property}:{value};";
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ElementStyle"/>.
    /// </summary>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    public static ElementStyle Empty() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="ElementStyle"/> with a specified style.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The value of the CSS property.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="property"/> is null, empty, or consists exclusively of white-space characters.
    /// </exception>
    public static ElementStyle Default( string property, string? value ) => new( property, value );

    /// <summary>
    /// Adds a style to the current <see cref="ElementStyle"/> instance if the value is not null or whitespace.
    /// </summary>
    /// <param name="value">The value of the CSS property.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    public ElementStyle Add( string? value ) => !string.IsNullOrWhiteSpace( value ) ? AddRaw( $"{value};" ) : this;

    /// <summary>
    /// Adds a style to the current <see cref="ElementStyle"/> instance.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The value of the CSS property.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="property"/> is null, empty, or consists exclusively of white-space characters.
    /// </exception>
    public ElementStyle Add( string property, string? value )
    {
        if( string.IsNullOrWhiteSpace( property ) )
        {
            throw new ArgumentException( "CSS property value cannot be null, empty or consist exlusively of white-space characters.", nameof( property ) );
        }

        return AddRaw( $"{property}:{value};" );
    }

    /// <summary>
    /// Conditionally adds a style to the current <see cref="ElementStyle"/> instance.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The value of the CSS property.</param>
    /// <param name="when">A boolean value that determines whether the style should be added.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="property"/> is null, empty, or consists exclusively of white-space characters.
    /// </exception>
    public ElementStyle Add( string property, string? value, bool when ) => when ? Add( property, value ) : this;

    /// <summary>
    /// Conditionally adds a style to the current <see cref="ElementStyle"/> instance.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">A function that returns the value of the CSS property.</param>
    /// <param name="when">A boolean value that determines whether the style should be added.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="property"/> is null, empty, or consists exclusively of white-space characters.
    /// </exception>
    public ElementStyle Add( string property, Func<string?> value, bool when ) => when ? Add( property, value() ) : this;

    /// <summary>
    /// Conditionally adds a style to the current <see cref="ElementStyle"/> instance.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">The value of the CSS property.</param>
    /// <param name="when">A function that returns a boolean value determining whether the style should be added.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="property"/> is null, empty, or consists exclusively of white-space characters.
    /// </exception>
    public ElementStyle Add( string property, string? value, Func<bool> when ) => Add( property, value, when() );

    /// <summary>
    /// Conditionally adds a style to the current <see cref="ElementStyle"/> instance.
    /// </summary>
    /// <param name="property">The CSS property name.</param>
    /// <param name="value">A function that returns the value of the CSS property.</param>
    /// <param name="when">A function that returns a boolean value determining whether the style should be added.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="property"/> is null, empty, or consists exclusively of white-space characters.
    /// </exception>
    public ElementStyle Add( string property, Func<string?> value, Func<bool> when ) => Add( property, value(), when() );

    /// <summary>
    /// Adds the styles from another <see cref="ElementStyle"/> instance to the current instance.
    /// </summary>
    /// <param name="elementStyle">The <see cref="ElementStyle"/> instance whose styles will be added.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    public ElementStyle Add( ElementStyle elementStyle ) => AddRaw( elementStyle.ToString() );

    /// <summary>
    /// Conditionally adds the styles from another <see cref="ElementStyle"/> instance to the current instance.
    /// </summary>
    /// <param name="elementStyle">The <see cref="ElementStyle"/> instance whose styles will be added.</param>
    /// <param name="when">A boolean value that determines whether the styles should be added.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    public ElementStyle Add( ElementStyle elementStyle, bool when ) => when ? AddRaw( elementStyle.ToString() ) : this;

    /// <summary>
    /// Conditionally adds the styles from another <see cref="ElementStyle"/> instance to the current instance.
    /// </summary>
    /// <param name="elementStyle">The <see cref="ElementStyle"/> instance whose styles will be added.</param>
    /// <param name="when">A function that returns a boolean value determining whether the styles should be added.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    public ElementStyle Add( ElementStyle elementStyle, Func<bool> when ) => Add( elementStyle, when() );

    /// <summary>
    /// Conditionally adds a CSS style to the current <see cref="ElementStyle"/> instance when it exists in the specified additional attributes.
    /// </summary>
    /// <param name="additionalAttributes">The additional attributes.</param>
    /// <returns>An <see cref="ElementStyle"/> instance.</returns>
    public ElementStyle Add( IReadOnlyDictionary<string, object>? additionalAttributes )
    {
        if( additionalAttributes is null )
        {
            return this;
        }

        if( additionalAttributes.TryGetValue( "style", out var value ) )
        {
            if( value is not null )
            {
                return AddRaw( value.ToString() );
            }
        }

        return this;
    }

    /// <summary>
    /// Returns a string representation of the current <see cref="ElementStyle"/> instance.
    /// </summary>
    /// <returns>A trimmed <see cref="string" /> representation of the styles if the internal buffer is not empty; otherwise, an empty string.</returns>
    public readonly override string ToString()
        => !string.IsNullOrEmpty( _stringBuffer ) ? _stringBuffer.Trim() : string.Empty;

    private ElementStyle AddRaw( string? value )
    {
        _stringBuffer += value;
        return this;
    }
}