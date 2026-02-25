// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component representing the trigger of the <see cref="LumexModal"/>, controlling its display.
/// </summary>
[CompositionComponent( typeof( LumexModal ) )]
public partial class LumexModalTrigger : LumexButton
{
	[CascadingParameter] internal ModalContext Context { get; set; } = default!;

	private LumexModal Modal => Context.Owner;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexModalTrigger ) );
	}

	private async Task HandleClickAsync( MouseEventArgs args )
	{
		await Modal.OpenAsync();
		await OnClick.InvokeAsync( args );
	}
}
