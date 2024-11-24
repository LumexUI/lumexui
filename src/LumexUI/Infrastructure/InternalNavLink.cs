using System.ComponentModel;
using System.Runtime.CompilerServices;

using LumexUI.Utilities;

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;

namespace LumexUI.Infrastructure;

/// <summary>
/// An internal component representing the navigation link that 
/// overrides default behavior of the native <see cref="NavLink"/>.
/// </summary>
/// <remarks>
/// For internal use only.
/// </remarks>
[EditorBrowsable( EditorBrowsableState.Never )]
public class InternalNavLink : NavLink
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalNavLink"/>.
    /// </summary>
    public InternalNavLink()
    {
        ActiveClass = string.Empty;
    }

    /// <inheritdoc/>
    protected override void BuildRenderTree( RenderTreeBuilder builder )
    {
        var isActive = GetActiveState( this );

        builder.OpenElement( 0, "a" );
        builder.AddMultipleAttributes( 1, AdditionalAttributes );

        if( isActive )
        {
            builder.AddAttribute( 2, "data-active", Utils.GetDataAttributeValue( isActive ) );
            builder.AddAttribute( 3, "aria-current", "page" );
        }

        builder.AddContent( 4, ChildContent );
        builder.CloseElement();
    }

    [UnsafeAccessor( UnsafeAccessorKind.Field, Name = "_isActive" )]
    private static extern ref bool GetActiveState( NavLink navLink );
}
