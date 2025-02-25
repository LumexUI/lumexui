// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents an avatar, typically displaying a user's profile image or initials.
/// </summary>
public partial class LumexAvatar : LumexComponentBase, ISlotComponent<AvatarSlots>
{
	/// <summary>
	/// Gets or sets the content to render when the avatar image is unavailable.
	/// </summary>
	[Parameter] public RenderFragment? FallbackContent { get; set; }

	/// <summary>
	/// Gets or sets the URL of the avatar image.
	/// </summary>
	[Parameter] public string? Src { get; set; }

	/// <summary>
	/// Gets or sets the alternative text for the avatar image.
	/// </summary>
	/// <remarks>
	/// The default value is <c>"avatar"</c>.
	/// </remarks>
	[Parameter] public string Alt { get; set; } = "avatar";

	/// <summary>
	/// Gets or sets the name associated with the avatar, 
	/// used to generate initials if no image is provided.
	/// </summary>
	[Parameter] public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the icon displayed when no image or initials are available.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Icons.Rounded.Person"/>.
	/// </remarks>
	[Parameter] public string Icon { get; set; } = Icons.Rounded.Person;

	/// <summary>
	/// Gets or sets the color of the avatar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the size of the avatar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the border radius of the avatar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Full"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Full;

	/// <summary>
	/// Gets or sets a value indicating whether the border should be added around the avatar.
	/// </summary>
	[Parameter] public bool Bordered { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the avatar is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets the function that resolves initials from the provided name.
	/// </summary>
	[Parameter] public InitialsResolver Initials { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the avatar slots.
	/// </summary>
	[Parameter] public AvatarSlots? Classes { get; set; }

	private readonly RenderFragment _renderFallback;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexAvatar"/>.
	/// </summary>
	public LumexAvatar()
	{
		_renderFallback = RenderFallback;

		As = "span";
		Initials = ExtractInitials;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( !string.IsNullOrWhiteSpace( Name ) )
		{
			Alt = Name;
		}

		var avatar = Styles.Avatar.Style( TwMerge );
		_slots = avatar( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Bordered )] = Bordered.ToString(),
			[nameof( Disabled )] = Disabled.ToString()
		} );
	}

	private string ExtractInitials( string name )
	{
		var names = name.Split( ' ', StringSplitOptions.RemoveEmptyEntries );
		return names.Length > 1
			? $"{names[0][0]} {names[^1][0]}".ToUpper()
			: ShortenIfNeeded( names[0] );

		static string ShortenIfNeeded( string text )
		{
			return text.Length <= 4 ? text : text[0..3];
		}
	}

	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( AvatarSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( AvatarSlots.Img ) => styles( Classes?.Img ),
			nameof( AvatarSlots.Fallback ) => styles( Classes?.Fallback ),
			nameof( AvatarSlots.Name ) => styles( Classes?.Name ),
			nameof( AvatarSlots.Icon ) => styles( Classes?.Icon ),
			_ => throw new NotImplementedException()
		};
	}
}