// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI;

internal sealed class DropdownContext( LumexDropdown owner ) : IComponentContext<LumexDropdown>
{
	public LumexDropdown Owner { get; } = owner;
}
