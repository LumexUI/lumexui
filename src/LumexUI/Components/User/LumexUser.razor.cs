// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents user information, such as an avatar, name, and email.
/// </summary>
public partial class LumexUser : LumexComponentBase, ISlotComponent<UserSlots>
{
	[Parameter] public string? Name { get; set; }

	[Parameter] public string? Description { get; set; }

	[Parameter] public bool IsFocusable { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the user slots.
	/// </summary>
	[Parameter] public UserSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc/>
	protected override void OnParametersSet()
	{
		var user = Styles.User.Style( TwMerge );
		_slots = user( new()
		{

		} );
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
			nameof( UserSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( UserSlots.Wrapper ) => styles( Classes?.Wrapper ),
			nameof( UserSlots.Name ) => styles( Classes?.Name ),
			nameof( UserSlots.Description ) => styles( Classes?.Description ),
			_ => throw new NotImplementedException()
		};
	}
}