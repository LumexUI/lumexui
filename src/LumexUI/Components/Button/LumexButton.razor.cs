// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using TailwindMerge;

namespace LumexUI;

/// <summary>
/// A component representing a button.
/// </summary>
public partial class LumexButton : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the button.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered before the label of the button.
    /// </summary>
    [Parameter] public RenderFragment? StartContent { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered after the label of the button.
    /// </summary>
    [Parameter] public RenderFragment? EndContent { get; set; }

    /// <summary>
    /// Gets or sets the type of the button.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ButtonType.Button"/>
    /// </remarks>
    [Parameter] public ButtonType Type { get; set; }

    /// <summary>
    /// Gets or sets an appearance style of the button.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Variant.Solid"/>
    /// </remarks>
    [Parameter] public Variant Variant { get; set; }

    /// <summary>
    /// Gets or sets a color of the button.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ThemeColor.Default"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

    /// <summary>
    /// Gets or sets the size of the button.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Size.Medium"/>
    /// </remarks>
    [Parameter] public Size Size { get; set; } = Size.Medium;

    /// <summary>
    /// Gets or sets the radius of the button.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Radius.Medium"/>
    /// </remarks>
    [Parameter] public Radius Radius { get; set; } = Radius.Medium;

    /// <summary>
    /// Gets or sets a value indicating whether the button is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the button is full-width.
	/// </summary>
	[Parameter] public bool FullWidth { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the button should have the same width and height.
	/// </summary>
	[Parameter] public bool IconOnly { get; set; }

	/// <summary>
	/// Gets or sets a callback that is fired whenever the button is clicked.
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

	private protected override string? RootClass => 
        TwMerge.Merge( Button.GetStyles( this ) );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexButton"/>.
    /// </summary>
    public LumexButton()
    {
        As = "button";
    }

    private protected virtual Task OnClickAsync( MouseEventArgs args )
    {
        return Disabled ? Task.CompletedTask : OnClick.InvokeAsync( args );
    }
}
