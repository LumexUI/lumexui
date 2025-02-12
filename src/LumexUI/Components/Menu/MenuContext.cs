﻿// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Internal;

namespace LumexUI;

internal sealed class MenuContext( Menu owner ) : IComponentContext<Menu>
{
	private bool _collectingItems;

	public Menu Owner { get; } = owner;
	public List<MenuItem> Items { get; } = [];

	public void Register( MenuItem item )
	{
		if( !_collectingItems )
		{
			return;
		}

		Items.Add( item );
	}

	public void StartCollectingItems()
	{
		Items.Clear();
		_collectingItems = true;
	}

	public void StopCollectingItems()
	{
		_collectingItems = false;
	}
}
