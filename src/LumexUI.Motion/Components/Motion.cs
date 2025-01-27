using System.Diagnostics;

using LumexUI.Motion.Types;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI.Motion;

/// <summary>
/// 
/// </summary>
public class Motion : ComponentBase
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public string As { get; set; } = "div";

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public object? Key { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public object? Enter { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public object? Exit { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public object? Transition { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public string? LayoutId { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter( CaptureUnmatchedValues = true )]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

	[CascadingParameter] private LayoutGroup? LayoutGroupContext { get; set; }
	[CascadingParameter] private PresenceContext? PresenceContext { get; set; }

	[Inject] private MotionInterop Interop { get; set; } = default!;

	private ElementReference _ref;
	private MotionProps? _props;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( Exit is not null && PresenceContext is null )
		{
			throw new InvalidOperationException(
				$"{GetType()} must be wrapped within the '{nameof( AnimatePresence )}' component " +
				$"when the '{nameof( Exit )}' parameter is set." );
		}

		if( Enter is not null ||
			Exit is not null ||
			Transition is not null )
		{
			_props = new MotionProps
			{
				Enter = Enter,
				Exit = Exit,
				Transition = Transition
			};
		}
	}

	/// <inheritdoc />
	protected override void BuildRenderTree( RenderTreeBuilder builder )
	{
		if( PresenceContext is not null )
		{
			PresenceContext.Register( this );
		}
		else
		{
			Render( builder );
		}
	}

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			await OnAnimatingAsync();
		}
	}

	internal void Render( RenderTreeBuilder builder )
	{
		builder.OpenElement( 0, As );
		builder.AddMultipleAttributes( 1, AdditionalAttributes );
		builder.AddElementReferenceCapture( 2, elementReference => _ref = elementReference );
		builder.AddContent( 3, ChildContent );
		builder.CloseElement();
	}

	internal Task OnAnimatingAsync()
	{
		if( string.IsNullOrEmpty( LayoutId ) )
		{
			return AnimateEnterAsync();
		}
		else
		{
			return AnimateLayoutIdAsync();
		}
	}

	internal Task AnimateEnterAsync()
	{
		if( _props is null || _props.Enter is null )
		{
			return Task.CompletedTask;
		}

		return Interop.AnimateEnterAsync( _ref, _props );
	}

	internal Task AnimateExitAsync()
	{
		if( _props is null || _props.Exit is null )
		{
			return Task.CompletedTask;
		}

		return Interop.AnimateExitAsync( _ref, _props );
	}

	internal Task AnimateLayoutIdAsync()
	{
		Debug.Assert( LayoutId is not null );

		var layoutId = LayoutGroupContext is not null
			? $"{LayoutGroupContext.Id}-{LayoutId}"
			: LayoutId;

		return Interop.AnimateLayoutIdAsync( _ref, _props, layoutId );
	}
}