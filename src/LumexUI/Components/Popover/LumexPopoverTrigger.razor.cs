// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component representing the trigger of the <see cref="LumexPopover"/> component, controlling its display.
/// </summary>
[Obsolete( "Deprecated. This will be removed in the future releases. See the Popover usage in the docs." )]
[CompositionComponent( typeof( LumexPopover ) )]
public partial class LumexPopoverTrigger : LumexButton
{
	[CascadingParameter] internal PopoverContext Context { get; set; } = default!;

	private LumexPopover Popover => Context.Owner;

	/// <inheritdoc />
	public override Task SetParametersAsync( ParameterView parameters )
	{
		parameters.SetParameterProperties( this );

		Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
			? color
			: Popover.Color;

		return base.SetParametersAsync( parameters );
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexPopoverTrigger ) );

		Class = Popover.Slots["Trigger"]( Popover.Classes?.Trigger, Class );

		SetAdditionalAttributes();
	}

	private void SetAdditionalAttributes()
	{
		if( TryConvertToDictionary( AdditionalAttributes, out var additionalAttributes ) )
		{
			AdditionalAttributes = additionalAttributes;
		}

		additionalAttributes["data-slot"] = "trigger";
		additionalAttributes["data-popoverref"] = Popover.Id;
	}

	private protected override async Task OnClickAsync( MouseEventArgs args )
	{
		if( Disabled )
		{
			return;
		}

		//await Context.ToggleAsync();
		await OnClick.InvokeAsync( args );
	}

	// TODO: Move to the extensions (duplicate of ConvertToDictionary in LumexNumbox)
	[ExcludeFromCodeCoverage]
	private static bool TryConvertToDictionary( IReadOnlyDictionary<string, object>? source, out Dictionary<string, object> result )
	{
		var newDictionaryCreated = true;

		if( source is null )
		{
			result = [];
		}
		else if( source is Dictionary<string, object> currentDictionary )
		{
			result = currentDictionary;
			newDictionaryCreated = false;
		}
		else
		{
			result = [];

			foreach( var item in source )
			{
				result.Add( item.Key, item.Value );
			}
		}

		return newDictionaryCreated;
	}
}
