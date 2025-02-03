// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Variants;

public record VariantConfig
{
	public string? Base { get; init; }
	public SlotCollection? Slots { get; init; }
	public VariantCollection? Variants { get; init; }
	public CompoundVariantCollection? CompoundVariants { get; init; }

	public void Deconstruct(
		out string? @base,
		out SlotCollection? slots,
		out VariantCollection? variants,
		out CompoundVariantCollection? compoundVariants )
	{
		@base = Base;
		slots = Slots;
		variants = Variants;
		compoundVariants = CompoundVariants;
	}
}
