// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the body of the <see cref="LumexModal"/>.
/// </summary>
[CompositionComponent( typeof( LumexModal ) )]
public partial class LumexModalBody : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the modal body.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal ModalContext Context { get; set; } = default!;

	private LumexModal Modal => Context.Owner;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexModalBody ) );
	}
}
