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
	/// <summary>
	/// Gets or sets the content to render when using a custom name element.
	/// </summary>
	[Parameter] public RenderFragment? NameContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render when using a custom description element.
	/// </summary>
	[Parameter] public RenderFragment? DescriptionContent { get; set; }

	/// <summary>
	/// Gets or sets the name of the user.
	/// </summary>
	[Parameter] public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the description of the user.
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the whether the user is focusable.
	/// </summary>
	[Parameter] public bool IsFocusable { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the user slots.
	/// </summary>
	[Parameter] public UserSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc/>
	protected override void OnParametersSet()
	{
		if( ( Name is not null ) && ( NameContent is not null ) )
		{
			throw new ArgumentException( $"Only one of '{nameof( Name )}' or '{nameof( NameContent )}' parameters can be set." );
		}

		if( ( Description is not null ) && ( DescriptionContent is not null ) )
		{
			throw new ArgumentException( $"Only one of '{nameof( Description )}' or '{nameof( DescriptionContent )}' parameters can be set." );
		}

		var user = Styles.User.Style( TwMerge );
		_slots = user();
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