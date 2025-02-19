// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;

namespace LumexUI.Variants;

public class VariantCollection : IEnumerable<KeyValuePair<string, VariantValueCollection?>>
{
	private readonly Dictionary<string, VariantValueCollection?> _dictionary = [];

	public VariantValueCollection? this[string variantName]
	{
		get
		{
			_dictionary.TryGetValue( variantName, out var variantValues );
			return variantValues;
		}
		set
		{
			_dictionary[variantName] = value;
		}
	}

	public IEnumerable<string> Variants => _dictionary.Keys;
	public IEnumerable<VariantValueCollection?> Values => _dictionary.Values;

	public IEnumerator<KeyValuePair<string, VariantValueCollection?>> GetEnumerator()
		=> _dictionary.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
