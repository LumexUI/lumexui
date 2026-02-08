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
/// A component representing a image.
/// </summary>
public partial class LumexImage : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the source of the image.
	/// </summary>
	[Parameter] public string Src { get; set; }

	/// <summary>
	/// Gets or sets the alt of the image.
	/// </summary>
	[Parameter] public string Alt { get; set; }

	/// <summary>
	/// Gets or sets the width of the image
	/// </summary>
	[Parameter] public int Width { get; set; }

	/// <summary>
	/// Gets or sets the height of the image
	/// </summary>
	[Parameter] public int Height { get; set; }

	/// <summary>
	/// Gets or sets the fit of the image
	/// </summary>
	[Parameter] public ObjectFit Fit { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the image is full-width.
	/// </summary>
	[Parameter] public bool FullWidth { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the image is full-height.
	/// </summary>
	[Parameter] public bool FullHeight { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the image is gray scaled.
	/// </summary>
	[Parameter] public bool GrayScale { get; set; }

	/// <summary>
	/// Gets or sets the shadow of the image.
	/// </summary>
	/// <remarks>
	/// Default value is <see cref="Shadow.Small"/>
	/// </remarks>
	[Parameter] public Shadow Shadow { get; set; } = Shadow.Small;

	/// <summary>
	/// Gets or sets a value indicating whether the image is blurred.
	/// </summary>
	[Parameter] public Blur Blur { get; set; } = Blur.None;

	/// <summary>
	/// Gets or sets the radius of the image.
	/// </summary>
	/// <remarks>
	/// Default value is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets a callback that is fired whenever the image is clicked.
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

	private protected override string? RootClass =>
		TwMerge.Merge( Image.GetStyles( this ) );

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexImage"/>.
	/// </summary>
	public LumexImage()
	{
		As = "img";
	}

	private protected virtual Task OnClickAsync( MouseEventArgs args )
	{
		return OnClick.InvokeAsync( args );
	}
}
