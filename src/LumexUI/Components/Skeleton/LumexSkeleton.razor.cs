// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a skeleton loader for displaying a placeholder while content is loading.
/// </summary>
public partial class LumexSkeleton : LumexComponentBase, ISlotComponent<SkeletonSlots>
{
	/// <summary>
	/// Gets or sets the content to render inside the skeleton.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the skeleton is in a loading state.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>.
	/// </remarks>
	[Parameter] public bool Loading { get; set; } = true;

	/// <summary>
	/// Gets or sets the CSS class names for the skeleton slots.
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