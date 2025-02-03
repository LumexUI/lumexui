// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Collections;

namespace LumexUI.Variants;

public class CompoundVariantCollection : IEnumerable<CompoundVariant>
{
	private readonly List<CompoundVariant> _list = [];

	public void Add( CompoundVariant variant )
	{
		_list.Add( variant );
	}

	public IEnumerator<CompoundVariant> GetEnumerator()
		=> _list.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
