using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI.Motion;

public class LayoutGroup : ComponentBase
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter, EditorRequired] public string Id { get; set; } = default!;

	protected override void BuildRenderTree( RenderTreeBuilder builder )
	{
		builder.OpenComponent<CascadingValue<LayoutGroup>>( 0 );
		builder.AddComponentParameter( 1, nameof( CascadingValue<LayoutGroup>.Value ), this );
		builder.AddComponentParameter( 2, nameof( CascadingValue<LayoutGroup>.IsFixed ), true );
		builder.AddComponentParameter( 3, nameof( CascadingValue<LayoutGroup>.ChildContent ), ChildContent );
		builder.CloseComponent();
	}
}
