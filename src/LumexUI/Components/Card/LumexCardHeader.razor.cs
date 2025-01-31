// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents the header section of the <see cref="LumexCard"/>.
/// </summary>
[CompositionComponent( typeof( LumexCard ) )]
public partial class LumexCardHeader : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the card header.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal CardContext Context { get; set; } = default!;

	private protected override string? RootClass
		=> TwMerge.Merge( Card.GetHeaderStyles( this ) );

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexCardHeader ) );
	}
}
