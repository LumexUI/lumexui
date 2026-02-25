// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the header of the <see cref="LumexModal"/>.
/// </summary>
[CompositionComponent( typeof( LumexModal ) )]
public partial class LumexModalHeader : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the modal header.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal ModalContext Context { get; set; } = default!;

	private LumexModal Modal => Context.Owner;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexModalHeader"/>.
	/// </summary>
	public LumexModalHeader()
	{
		As = "header";
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexModalHeader ) );
	}
}
