using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI.Infrastructure;

/// <summary>
/// A component that is used to move some of the components' body rendering 
/// to the end of the render queue so we can collect the list of child components first.
/// </summary>
/// <remarks>
/// For internal use only.
/// </remarks>
[ExcludeFromCodeCoverage(Justification = "Taken from the Blazor QuickGrid.")]
[EditorBrowsable( EditorBrowsableState.Never )]
public class Defer : ComponentBase
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [Parameter] public RenderFragment? ChildContent { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <inheritdoc />
    protected override void BuildRenderTree( RenderTreeBuilder builder )
    {
        builder.AddContent( 0, ChildContent );
    }
}
