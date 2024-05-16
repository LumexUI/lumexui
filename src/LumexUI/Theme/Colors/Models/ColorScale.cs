// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;

namespace LumexUI.Theme;

/// <summary>
/// Represents a scale of colors, accessible via string keys.
/// Implements <see cref="IEnumerable{T}"/> to allow enumeration of key-value pairs.
/// </summary>
public readonly record struct ColorScale : IEnumerable<KeyValuePair<string, string?>>
{
    private readonly Dictionary<string, string?> _colors;

    /// <summary>
    /// Gets or sets the color associated with the specified key.
    /// </summary>
    /// <param name="key">The key of the color to get or set.</param>
    /// <returns>The color associated with the specified key, or null if the key is not found.</returns>
    public string? this[string key]
	{
		get => _colors.TryGetValue( key, out var color ) ? color : null;
		set => _colors[key] = value;
	}

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorScale"/>.
    /// </summary>
    public ColorScale()
    {
        _colors = [];
    }

    /// <inheritdoc />
    public IEnumerator<KeyValuePair<string, string?>> GetEnumerator() 
        => _colors.GetEnumerator();

    // Enables the spread operator functionality.
    internal void Add( KeyValuePair<string, string?> item ) => 
        _colors.Add( item.Key, item.Value );

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
