// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

namespace LumexUI.Theme;

// TODO: Think why this is not an implementation of the `IDictionary`?

/// <summary>
/// Represents a scale of colors, 
/// implementing <see cref="ICollection{T}"/> for managing color values associated with keys.
/// </summary>
public record ColorScale : ICollection<KeyValuePair<string, string>>
{
    private readonly Dictionary<string, string> _colors;

    /// <inheritdoc />
    public int Count => ( (ICollection<KeyValuePair<string, string>>)_colors ).Count;

    /// <inheritdoc />
    public bool IsReadOnly => ( (ICollection<KeyValuePair<string, string>>)_colors ).IsReadOnly;

    /// <summary>
    /// Gets or sets the color associated with the specified key.
    /// </summary>
    /// <param name="key">The key of the color to get or set.</param>
    /// <returns>The color associated with the specified key, or null if the key is not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the key or value are null or empty.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the key is not found in the color scale.</exception>
    public string this[string key]
    {
        get => _colors[key];
        set => _colors[key] = value;
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
    /// <param name="defaultColor">The default color to be set in the color scale.</param>
    public ColorScale( string defaultColor ) : this()
    {
        _colors["default"] = defaultColor;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorScale"/> with a set of colors.
    /// </summary>
    /// <remarks>
    /// The default color key is '500'.
    /// </remarks>
    /// <param name="colors">The dictionary of color values to initialize the color scale with.</param>
    /// <param name="defaultKey">The key of the default color to be set in the color scale.</param>
    /// <exception cref="ArgumentNullException">Thrown when the colors dictionary or the default color key is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the default color key is not found in the colors dictionary.</exception>
    public ColorScale( IReadOnlyDictionary<string, string> colors, string defaultKey = "500" )
    {
        if( colors is null )
        {
            throw new ArgumentNullException( nameof( colors ), "Colors dictionary cannot be null." );
        }

        if( string.IsNullOrEmpty( defaultKey ) )
        {
            throw new ArgumentNullException( nameof( defaultKey ), "Default color key cannot be null or empty." );
        }

        if( !colors.ContainsKey( defaultKey ) )
        {
            throw new KeyNotFoundException( $"The key '{defaultKey}' was not found in the provided colors dictionary." );
        }

        _colors = new Dictionary<string, string>( colors );
        SetAsDefault( defaultKey );
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
    public bool TryGetValue( string key, out string? value )
    {
        var result = _colors.TryGetValue( key, out var _value );
        value = _value;
        return result;
    }

    /// <inheritdoc />
    public void Add( KeyValuePair<string, string> item )
        => ( (ICollection<KeyValuePair<string, string>>)_colors ).Add( item );

    /// <inheritdoc />
    public void Clear()
        => ( (ICollection<KeyValuePair<string, string>>)_colors ).Clear();

    /// <inheritdoc />
    public bool Contains( KeyValuePair<string, string> item )
        => ( (ICollection<KeyValuePair<string, string>>)_colors ).Contains( item );

    /// <inheritdoc />
    public void CopyTo( KeyValuePair<string, string>[] array, int arrayIndex )
        => ( (ICollection<KeyValuePair<string, string>>)_colors ).CopyTo( array, arrayIndex );

    /// <inheritdoc />
    public bool Remove( KeyValuePair<string, string> item )
        => ( (ICollection<KeyValuePair<string, string>>)_colors ).Remove( item );

    /// <inheritdoc />
    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        => _colors.GetEnumerator();

    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
