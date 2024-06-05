// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexIcon : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the icon.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the name or path of the icon to be displayed.
    /// </summary>
    [Parameter] public string? Icon { get; set; }

    /// <summary>
    /// Gets or sets the dimensions of the icon.
    /// </summary>
    /// <remarks>
    /// The default is 24x24
    /// </remarks>
    [Parameter] public Dimensions Size { get; set; } = new( "24" );

    /// <summary>
    /// Gets or sets the viewBox attribute of the SVG element representing the icon.
    /// </summary>
    /// <remarks>
    /// The default value is "0 -960 960 960" (<seealso href="https://fonts.google.com/icons">Material Symbols</seealso>)
    /// </remarks>
    [Parameter] public string ViewBox { get; set; } = "0 -960 960 960";

    /// <summary>
    /// Gets or sets a color of the icon.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Styles.Icon.GetStyles( this ) );

    private string FontIconStyle => ElementStyle.Empty()
        .Add( "font-size", Size.W, when: Size.W == Size.H )
        .Add( RootStyle )
        .ToString();

    [MemberNotNullWhen( true, nameof( Icon ) )]
    private bool IsSvgIcon => !string.IsNullOrEmpty( Icon ) && Icon.Trim().StartsWith( '<' );

    /// <summary>
    /// Represents the dimensions of an icon with width and height.
    /// </summary>
    /// <param name="w">The width of the icon.</param>
    /// <param name="h">The height of the icon.</param>
    public readonly struct Dimensions( string w, string h )
    {
        /// <summary>
        /// Gets the width of the icon.
        /// </summary>
        public readonly string W = w;

        /// <summary>
        /// Gets the height of the icon.
        /// </summary>
        public readonly string H = h;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dimensions"/> 
        /// with equal width and height for the icon.
        /// </summary>
        /// <param name="size">The size to be used for both width and height.</param>
        public Dimensions( string size ) : this( size, size ) { }
    }
}