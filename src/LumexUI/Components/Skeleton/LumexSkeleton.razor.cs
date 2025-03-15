// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexSkeleton : LumexComponentBase, ISlotComponent<SkeletonSlots>
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>.
	/// </remarks>
	[Parameter] public bool Loading { get; set; } = true;

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public SkeletonSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var skeleton = Styles.Skeleton.Style( TwMerge );
		_slots = skeleton();
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( SkeletonSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( SkeletonSlots.Content ) => styles( Classes?.Content ),
			_ => throw new NotImplementedException()
		};
	}
}