// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;

namespace LumexUI.Variants;

public class SlotCollection : IEnumerable<KeyValuePair<string, string?>>
{
	private readonly Dictionary<string, string?> _dictionary = [];

	public string? this[string slotName]
	{
		get
		{
			_dictionary.TryGetValue( slotName, out var classes );
			return classes;
		}
		set
		{
			_dictionary[slotName] = value;
		}
	}

	public IEnumerable<string> Slots => _dictionary.Keys;
	public IEnumerable<string?> Values => _dictionary.Values;

	public IEnumerator<KeyValuePair<string, string?>> GetEnumerator()
		=> _dictionary.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}