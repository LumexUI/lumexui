// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
public partial class LumexSpinner : LumexComponentBase
{
	/// <summary>
	/// 
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter] public string? Label { get; set; }

	private string AriaLabel => Label ?? "Loading";

	private readonly RenderFragment _renderContent;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexAvatar"/>.
	/// </summary>
	public LumexSpinner()
	{
		_renderContent = RenderContent;
	}
}