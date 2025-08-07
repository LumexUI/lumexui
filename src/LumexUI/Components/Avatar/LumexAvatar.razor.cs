// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Extensions;
using LumexUI.Shared.Icons;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI;

/// <summary>
/// A component that represents an avatar, typically displaying a user's profile image or initials.
/// </summary>
[CompositionComponent( typeof( LumexAvatarGroup ) )]
public partial class LumexAvatar : LumexComponentBase, ISlotComponent<AvatarSlots>, IAsyncDisposable
{
	private const string JavaScriptFile = "./_content/LumexUI/js/utils/dom.js";

	/// <summary>
	/// Gets or sets the content to render when the avatar image is unavailable.
	/// </summary>
	[Parameter] public RenderFragment? FallbackContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render as the icon when no image or initials are available.
	/// </summary>
	[Parameter] public RenderFragment IconContent { get; set; } = _renderDefaultIcon;

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
	/// Gets or sets a value indicating whether to show fallback content when the avatar image is unavailable.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>.
	/// </remarks>
	[Parameter] public bool ShowFallback { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether the border should be added around the avatar.
	/// </summary>
	[Parameter] public bool Bordered { get; set; }

	/// <summary>
	/// Gets or sets the size of the avatar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the color of the avatar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the border radius of the avatar.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Full"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Full;

	/// <summary>
	/// Gets or sets the function that resolves initials from the provided name.
	/// </summary>
	[Parameter] public Func<string, string> Initials { get; set; } = ExtractInitials;

	/// <summary>
	/// Gets or sets the CSS class names for the avatar slots.
	/// </summary>
	[Parameter] public AvatarSlots? Classes { get; set; }

	[CascadingParameter] private AvatarGroupContext? Context { get; set; }

	[Inject] private IJSRuntime JSRuntime { get; set; } = default!;

	private LumexAvatarGroup? Group => Context?.Owner;

	private static readonly RenderFragment _renderDefaultIcon = builder =>
	{
		builder.OpenComponent<UserIcon>( 0 );
		builder.CloseComponent();
	};

	private readonly RenderFragment _render;
	private readonly RenderFragment _renderFallback;

	private Dictionary<string, ComponentSlot> _slots = [];

	private ElementReference _ref;
	private IJSObjectReference _jsModule = default!;

	private bool _isCounter;
	private bool _imageLoaded;
	private bool _showFallback;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexAvatar"/>.
	/// </summary>
	public LumexAvatar()
	{
		_render = Render;
		_renderFallback = RenderFallback;

		As = "span";
	}

	/// <inheritdoc />
	public override Task SetParametersAsync( ParameterView parameters )
	{
		parameters.SetParameterProperties( this );

		if( parameters.TryGetValue<string>( nameof( Name ), out var value ) &&
			!string.IsNullOrWhiteSpace( value ) )
		{
			Alt = value;
		}

		if( Group is not null )
		{
			// Respect own parameter values if provided; otherwise, use the group's
			Size = parameters.GetParameterProperty( nameof( Size ), fallback: Group.Size );
			Color = parameters.GetParameterProperty( nameof( Color ), fallback: Group.Color );
			Radius = parameters.GetParameterProperty( nameof( Radius ), fallback: Group.Radius );
			Bordered = parameters.GetParameterProperty( nameof( Bordered ), fallback: Group.Bordered );
		}

		return base.SetParametersAsync( ParameterView.Empty );
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		if( Group is not null )
		{
			// A custom flag to mark an avatar as a group counter.
			// We need this because it appears in the render tree during
			// rendering when all children have already been collected.
			if( AdditionalAttributes?.TryGetValue( "data-counter", out var _ ) ?? false )
			{
				_isCounter = true;
			}
		}
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var avatar = Styles.Avatar.Style( TwMerge );
		_slots = avatar( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Bordered )] = Bordered.ToString(),
			[nameof( Group )] = ( Group is not null ).ToString(),
			[nameof( Group.Grid )] = ( Group?.Grid is true ).ToString()
		} );
	}

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			if( !string.IsNullOrEmpty( Src ) )
			{
				_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
				_imageLoaded = await _jsModule.InvokeAsync<bool>( "isImageLoaded", _ref );
			}

			/*
			 * Avatar fallback applies under 2 conditions:
			 * - If `Src` was passed and the image has failed to load
			 * - If `Src` wasn't passed
			 *
			 * In this case, we'll show either the name or default avatar
			 */
			_showFallback = ShowFallback && ( !_imageLoaded || string.IsNullOrEmpty( Src ) );

			if( Context is null )
			{
				StateHasChanged();
			}
			else
			{
				Context.Owner.Rerender();
			}
		}
	}

	private static string ExtractInitials( string name )
	{
		var names = name.Split( ' ', StringSplitOptions.RemoveEmptyEntries );
		return names.Length > 1
			? $"{names[0][0]}{names[^1][0]}".ToUpper()
			: ShortenIfNeeded( names[0] );

		static string ShortenIfNeeded( string text )
		{
			return text.Length <= 4 ? text : text[0..3];
		}
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
			nameof( AvatarSlots.Base ) => styles( Group?.AvatarClasses?.Base, Classes?.Base, Class ),
			nameof( AvatarSlots.Img ) => styles( Group?.AvatarClasses?.Img, Classes?.Img ),
			nameof( AvatarSlots.Fallback ) => styles( Group?.AvatarClasses?.Fallback, Classes?.Fallback ),
			nameof( AvatarSlots.Name ) => styles( Group?.AvatarClasses?.Name, Classes?.Name ),
			nameof( AvatarSlots.Icon ) => styles( Group?.AvatarClasses?.Icon, Classes?.Icon ),
			_ => throw new NotImplementedException()
		};
	}

	/// <inheritdoc />
	[ExcludeFromCodeCoverage]
	public async ValueTask DisposeAsync()
	{
		try
		{
			if( _jsModule is not null )
			{
				await _jsModule.DisposeAsync();
			}
		}
		catch( JSDisconnectedException )
		{
			// The JS side may routinely be gone already if the reason we're disposing is that
			// the client disconnected. This is not an error.
		}
	}
}