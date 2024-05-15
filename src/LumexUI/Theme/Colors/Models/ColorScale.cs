// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;

namespace LumexUI.Theme;

/// <summary>
/// Represents a color with various shades.
/// </summary>
public readonly record struct ColorScale : IEnumerable<KeyValuePair<string, string?>>
{
    private readonly Dictionary<string, string?> _colors;

    public string? this[string key]
	{
		get => _colors.TryGetValue( key, out var color ) ? color : null;
		set => _colors[key] = value;
	}

	public ColorScale()
    {
        _colors = [];
    }

    /// <inheritdoc />
    public IEnumerator<KeyValuePair<string, string?>> GetEnumerator() 
        => _colors.GetEnumerator();

    // To enable the spread operator
    internal void Add( KeyValuePair<string, string?> item ) => 
        _colors.Add( item.Key, item.Value );

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
