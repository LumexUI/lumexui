// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a group of the <see cref="LumexAvatar"/> components.
/// </summary>
public partial class LumexAvatarGroup : LumexComponentBase, ISlotComponent<AvatarGroupSlots>
{
	/// <summary>
	/// Gets or sets the content to render inside the avatar group.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render for the count of additional avatars beyond the maximum limit.
	/// </summary>
	[Parameter] public RenderFragment<int> CountContent { get; set; } = _renderCount;

	/// <summary>
	/// Gets or sets the maximum number of avatars to display.
	/// </summary>
	/// <remarks>
	/// The default value is <c>5</c>.
	/// </remarks>
	[Parameter] public int Max { get; set; } = 5;

	/// <summary>
	/// Gets or sets a value indicating whether the avatars should be displayed in a grid layout.
	/// </summary>
	[Parameter] public bool Grid { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the border should be added around the avatars.
	/// </summary>
	[Parameter] public bool Bordered { get; set; }

	/// <summary>
	/// Gets or sets the color of the avatars.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the size of the avatars.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the border radius of the avatars.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Full"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Full;

	/// <summary>
	/// Gets or sets the CSS class names for the avatar group slots.
	/// </summary>
	[Parameter] public AvatarGroupSlots? Classes { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the avatars slots.
	/// </summary>
	[Parameter] public AvatarSlots? AvatarClasses { get; set; }

	private int RemainingCount => _context.Items.Count - Max;

	private static readonly RenderFragment<int> _renderCount = count => builder =>
	{
		builder.OpenComponent<LumexAvatar>( 0 );
		builder.AddComponentParameter( 1, nameof( LumexAvatar.Name ), $"+{count}" );

		// A custom flag to store this instance as a group counter.
		// We need this because it appears in the render tree only after all children have been collected.
		builder.AddAttribute( 2, "data-counter", "true" );
		builder.CloseComponent();
	};

	private readonly AvatarGroupContext _context;
	private readonly RenderFragment _render;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexAvatarGroup"/>.
	/// </summary>
	public LumexAvatarGroup()
	{
		_context = new AvatarGroupContext( this );
		_render = Render;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var avatarGroup = Styles.AvatarGroup.Style( TwMerge );
		_slots = avatarGroup( new()
		{
			[nameof( Grid )] = Grid.ToString()
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
			nameof( AvatarGroupSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( AvatarGroupSlots.Count ) => styles( Classes?.Count ),
			_ => throw new NotImplementedException()
		};
	}
}