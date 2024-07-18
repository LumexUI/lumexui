// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace LumexUI;

/// <summary>
/// A component representing a navigation link within the application.
/// </summary>
public partial class LumexNavLink : LumexLinkBase
{
    /// <summary>
    /// Gets or sets a value representing the URL matching behavior.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="NavLinkMatch.All"/>
    /// </remarks>
    [Parameter] public NavLinkMatch Match { get; set; } = NavLinkMatch.All;

    private protected override string? RootClass =>
        TwMerge.Merge( Styles.NavLink.GetStyles( this ) );

    private NavLink? _navLink;
    private bool _isActive;

    /// <inheritdoc />
    protected override void OnAfterRender( bool firstRender )
    {
        if( !_isActive )
        {
            if( GetActiveState( _navLink! ) )
            {
                _isActive = true;
                StateHasChanged();
            }
        }
    }

    [UnsafeAccessor( UnsafeAccessorKind.Field, Name = "_isActive" )]
    private static extern ref bool GetActiveState( NavLink navLink );
}
