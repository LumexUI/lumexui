// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Motion.Types;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexTab : LumexComponentBase
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter, EditorRequired] public object Id { get; set; } = default!;

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? TitleContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public string? Title { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	[CascadingParameter] internal TabsContext Context { get; set; } = default!;

	// Do not use.
	// Unfortunate hack to make `LumexTab` always re-render when the `ActiveTab` changes to prevent its removal.
	[CascadingParameter] private LumexTab ActiveTab { get; set; } = default!;

	[Inject] private NavigationManager NavigationManager { get; set; } = default!;

	private TabsSlots Slots => Context.Owner.Slots;
	private bool Selected => Context.ActiveTab == this;

	private readonly MotionProps _motionProps;

	private bool _isLink;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexTab"/>.
	/// </summary>
	public LumexTab()
	{
		_motionProps = new MotionProps
		{
			Transition = new
			{
				Type = "spring",
				Bounce = 0.15,
				Duration = 0.5
			}
		};

		As = "button";
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexTab ) );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( Id is null )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires a value for the {nameof( Id )} parameter." );
		}

		if( AdditionalAttributes?.TryGetValue( "href", out var value ) == true )
		{
			As = "a";
			_isLink = true;

			// Set as active if current route's relative path contains href value.
			var href = value?.ToString();
			if( !Selected && !string.IsNullOrEmpty( href ) )
			{
				var relativePath = $"/{NavigationManager.ToBaseRelativePath( NavigationManager.Uri )}";
				if( relativePath.Contains( href ) )
				{
					Context.ActiveTab = this;
				}
			}
		}
	}

	private void HandleClick()
	{
		if( GetDisabledState() )
		{
			return;
		}

		Context.ActiveTab = this;
	}

	private bool GetDisabledState() =>
		Disabled ||
		Context.Owner.Disabled ||
		Context.Owner.DisabledItems?.Contains( Id ) is true;
}