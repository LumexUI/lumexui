// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using TailwindMerge;

namespace LumexUI.Utilities;

internal delegate Dictionary<string, ComponentSlot> ComponentVariant( Dictionary<string, string>? overrides = null );

internal delegate string? ComponentSlot( params string?[] classNames );

[ExcludeFromCodeCoverage]
internal class TwVariants( TwMerge twMerge )
{
	public ComponentVariant Create( VariantConfig config )
	{
		return ( overrides ) =>
		{
			var (@base, slots, variants, compoundVariants) = config;
			var result = new Dictionary<string, ComponentSlot>();
			var hasOverrides = overrides is not null;

			// 1. Start with the base slot values.
			if( slots is not null )
			{
				foreach( var (slot, classes) in slots )
				{
					result[slot] = CreateComponentSlot( classes );
				}
			}
			else if( !string.IsNullOrEmpty( @base ) )
			{
				result["Base"] = CreateComponentSlot( @base );
			}

			// 2. Merge variant-specific values.
			if( variants is not null )
			{
				foreach( var (variant, values) in variants )
				{
					var selectedValue = GetOverrideValue( overrides, variant );

					// If a value was provided and exists in our collection...
					if( !string.IsNullOrEmpty( selectedValue ) &&
						values[selectedValue] is SlotCollection variantSlots )
					{
						// Merge each slot defined in the variant value.
						foreach( var (slot, slotValues) in variantSlots )
						{
							if( result.TryGetValue( slot, out var value ) )
							{
								result[slot] = CreateComponentSlot( value(), slotValues );
							}
							else
							{
								result[slot] = CreateComponentSlot( slotValues );
							}
						}
					}
				}
			}

			// 3. Merge compound variants.
			if( compoundVariants is not null )
			{
				foreach( var cv in compoundVariants )
				{
					// Check if all conditions for this compound variant match.
					var match = true;
					foreach( var (key, value) in cv.Conditions )
					{
						var conditionValue = GetOverrideValue( overrides, key );
						if( conditionValue != value )
						{
							match = false;
							break;
						}
					}

					if( match )
					{
						// Merge the compound variant's CSS classes into the appropriate slots.
						foreach( var (slot, values) in cv.Classes )
						{
							if( result.TryGetValue( slot, out var value ) )
							{
								result[slot] = CreateComponentSlot( value(), values );
							}
							else
							{
								result[slot] = CreateComponentSlot( values );
							}
						}
					}
				}
			}

			return result;
		};
	}

	private static string GetOverrideValue( Dictionary<string, string>? overrides, string key )
	{
		return overrides != null && overrides.TryGetValue( key, out var value )
			? value
			: string.Empty;
	}

	private ComponentSlot CreateComponentSlot( params string?[] classNames )
	{
		return ( extraClassNames ) => twMerge.Merge( [.. classNames, .. extraClassNames] );
	}
}
