// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Variants;

public class CompoundVariant
{
	public Dictionary<string, string> Conditions { get; set; } = [];

	public SlotCollection Classes { get; set; } = [];
}
