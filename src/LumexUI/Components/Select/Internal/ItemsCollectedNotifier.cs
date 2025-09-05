// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

using Microsoft.AspNetCore.Components;

using IComponent = Microsoft.AspNetCore.Components.IComponent;

namespace LumexUI.Internal;

/// <summary>
/// For internal use only.
/// </summary>
[EditorBrowsable( EditorBrowsableState.Never )]
public sealed class ItemsCollectedNotifier<TValue> : IComponent
{
	[CascadingParameter] private SelectContext<TValue> Context { get; set; } = default!;

	private LumexSelect<TValue> Select => Context.Owner;

	private bool _isFirstRender = true;

	void IComponent.Attach( RenderHandle renderHandle )
	{
		// This component never renders, so we can ignore the renderHandle
	}

	Task IComponent.SetParametersAsync( ParameterView parameters )
	{
		if( _isFirstRender )
		{
			parameters.SetParameterProperties( this );

			if( Context.IsMultipleSelect )
			{
				Context.UpdateSelectedItems( Select.Values );
			}
			else
			{
				Context.UpdateSelectedItem( Select.Value );
			}

			_isFirstRender = false;
			return Task.CompletedTask;
		}
		else
		{
			return Task.CompletedTask;
		}
	}
}
