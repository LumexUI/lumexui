// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents the body section of the <see cref="LumexCard"/>.
/// </summary>
[CompositionComponent( typeof( LumexCard ) )]
public partial class LumexCardBody : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the card body.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal CardContext Context { get; set; } = default!;

	private protected override string? RootClass
		=> TwMerge.Merge( Card.GetBodyStyles( this ) );

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexCardBody ) );
	}
}
