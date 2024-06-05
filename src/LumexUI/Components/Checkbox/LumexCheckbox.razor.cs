// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexCheckbox : LumexInputBase<bool>
{
    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, out bool result )
    {
        throw new NotSupportedException(
            $"This component does not parse string inputs. " +
            $"Bind to the '{nameof( CurrentValue )}' property, not '{nameof( CurrentValueAsString )}'." );
    }

    private Task OnChangeAsync( ChangeEventArgs args )
    {
        if( Disabled )
        {
            return Task.CompletedTask;
        }

        return SetCurrentValueAsync( (bool)args.Value! );
    }
}