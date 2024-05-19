// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

namespace LumexUI.Theme;

/// <summary>
/// Represents a scale of colors, accessible via string keys.
/// Implements <see cref="IEnumerable{T}"/> to allow enumeration of key-value pairs.
/// </summary>
public record ColorScale : IEnumerable<KeyValuePair<string, string>>
{
    private readonly Dictionary<string, string> _colors;

    /// <summary>
    /// Gets or sets the color associated with the specified key.
    /// </summary>
    /// <param name="key">The key of the color to get or set.</param>
    /// <returns>The color associated with the specified key, or null if the key is not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the key or value are null or empty.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the key is not found in the color scale.</exception>
    public string this[string key]
    {
        get
        {
            if( string.IsNullOrEmpty( key ) )
            {
                throw new ArgumentNullException( nameof( key ), "Key cannot be null or empty." );
            }

            return _colors.TryGetValue( key, out var value )
                ? value
                : throw new KeyNotFoundException( $"The key '{key}' was not found in the color scale." );
        }
        set
        {
            if( string.IsNullOrEmpty( key ) )
            {
                throw new ArgumentNullException( nameof( key ), "Key cannot be null or empty." );
            }

            _colors[key] = value ?? throw new ArgumentNullException( nameof( value ), "Value cannot be null." );
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorScale"/>.
    /// </summary>
    public ColorScale()
    {
        _colors = [];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorScale"/> with a default color.
    /// </summary>
    /// <param name="default">The default color to be set in the color scale.</param>
    public ColorScale( string @default ) : this()
    {
        _colors["default"] = @default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorScale"/> with a set of colors and a key of the default color.
    /// </summary>
    /// <param name="colors">The dictionary of color values to initialize the color scale with.</param>
    /// <param name="defaultColorKey">The key of the default color to be set in the color scale.</param>
    /// <exception cref="ArgumentNullException">Thrown when the colors dictionary or the default color key is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the default color key is not found in the colors dictionary.</exception>
    public ColorScale( IDictionary<string, string> colors, string defaultColorKey )
    {
        if( colors is null )
        {
            throw new ArgumentNullException( nameof( colors ), "Colors dictionary cannot be null." );
        }

        if( string.IsNullOrEmpty( defaultColorKey ) )
        {
            throw new ArgumentNullException( nameof( defaultColorKey ), "Default color key cannot be null or empty." );
        }

        if( !colors.ContainsKey( defaultColorKey ) )
        {
            throw new KeyNotFoundException( $"The key '{defaultColorKey}' was not found in the provided colors dictionary." );
        }

        _colors = new Dictionary<string, string>( colors );
        SetAsDefault( defaultColorKey );
    }

    /// <summary>
    /// Sets the default color in the color scale based on the specified key.
    /// Updates the foreground color to be readable against the new default color.
    /// </summary>
    /// <param name="key">The key of the color to set as the default.</param>
    /// <returns>The updated <see cref="ColorScale"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the key is null or empty.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the specified key is not found in the color scale.</exception>    
    public ColorScale SetAsDefault( string key )
    {
        if( string.IsNullOrEmpty( key ) )
        {
            throw new ArgumentNullException( nameof( key ), "Key cannot be null or empty." );
        }

        if( !_colors.TryGetValue( key, out var value ) )
        {
            throw new KeyNotFoundException( $"The key '{key}' was not found in the color scale." );
        }

        _colors["default"] = value;
        _colors["foreground"] = ColorUtils.GetReadableColor( value );

        return this;
    }

    /// <inheritdoc />
    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        => _colors.GetEnumerator();

    // Enables the spread operator functionality.
    internal void Add( KeyValuePair<string, string> item ) =>
        _colors.Add( item.Key, item.Value );

    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
