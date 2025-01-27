using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI.Motion.Internal;

/// <remarks>
/// For internal use only.
/// </remarks>
[EditorBrowsable( EditorBrowsableState.Never )]
[SuppressMessage( "Style", "IDE1006:Naming Styles", Justification = "For internal use only" )]
public class _Defer : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    protected override void BuildRenderTree( RenderTreeBuilder builder )
    {
        builder.AddContent( 0, ChildContent );
    }
}
