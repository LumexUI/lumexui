// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Motion.Types;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a tab within <see cref="LumexTabs"/>.
/// </summary>
[CompositionComponent( typeof( LumexTab ) )]
public partial class LumexTab : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the tab panel.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the content to be rendered as the tab's title.
	/// </summary>
	[Parameter] public RenderFragment? TitleContent { get; set; }

	/// <summary>
	/// Gets or sets the unique identifier for the tab.
	/// </summary>
	[Parameter] public string Id { get; set; } = Identifier.New();

	/// <summary>
	/// Gets or sets the title text of the tab.
	/// </summary>
	[Parameter] public string? Title { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the tab is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	[CascadingParameter] internal TabsContext Context { get; set; } = default!;

	// Unfortunate hack to make `LumexTab` always re-render when the `SelectedTab` changes to prevent its removal.
	[CascadingParameter] private LumexTab SelectedTab { get; set; } = default!;

	[Inject] private NavigationManager NavigationManager { get; set; } = default!;

	private TabsSlots Slots => Context.Owner.Slots;
	private bool Selected => Context.GetSelectedTab() == this;

	private readonly MotionProps _motionProps;

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
	protected override Task OnInitializedAsync()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexTab ) );

		if( Context.GetSelectedTab() is null )
		{
			if( Context.Owner.SelectedId is not null )
			{
				if( Equals( Context.Owner.SelectedId, Id ) )
				{
					return Context.SetSelectedTabAsync( this );
				}

				return Task.CompletedTask;
			}

			return Context.SetSelectedTabAsync( this );
		}

		return Task.CompletedTask;
	}

	/// <inheritdoc />
	protected override async Task OnParametersSetAsync()
	{
		if( Id is null )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires a value for the {nameof( Id )} parameter." );
		}

		if( AdditionalAttributes?.TryGetValue( "href", out var value ) == true )
		{
			As = "a";

			// Set as active if current route's relative path contains href value.
			var href = value?.ToString();
			if( !Selected && !string.IsNullOrEmpty( href ) )
			{
				var relativePath = $"/{NavigationManager.ToBaseRelativePath( NavigationManager.Uri )}";
				if( relativePath.Equals( href, StringComparison.OrdinalIgnoreCase ) ||
					relativePath.StartsWith( href, StringComparison.OrdinalIgnoreCase ) )
				{
					await Context.SetSelectedTabAsync( this );
				}
			}
		}
	}

	private Task HandleClickAsync()
	{
		if( GetDisabledState() )
		{
			return Task.CompletedTask;
		}

		return Context.SetSelectedTabAsync( this );
	}

	private bool GetDisabledState() =>
		Disabled ||
		Context.Owner.Disabled ||
		Context.Owner.DisabledItems?.Contains( Id ) is true;
}