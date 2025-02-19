// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;

namespace LumexUI.Variants;

public class VariantValueCollection : IEnumerable<KeyValuePair<string, SlotCollection?>>
{
	private readonly Dictionary<string, SlotCollection?> _dictionary = [];

	public SlotCollection? this[string variantValueName]
	{
		get
		{
			_dictionary.TryGetValue( variantValueName, out var slots );
			return slots;
		}
		set
		{
			_dictionary[variantValueName] = value;
		}
	}

	public IEnumerable<string> VariantValues => _dictionary.Keys;
	public IEnumerable<SlotCollection?> Values => _dictionary.Values;

	public IEnumerator<KeyValuePair<string, SlotCollection?>> GetEnumerator()
		=> _dictionary.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
