using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public class LumexBooleanInputBase : LumexInputBase<bool>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the input.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out bool result )
    {
        throw new NotSupportedException(
            $"This component does not parse string inputs. " +
            $"Bind to the '{nameof( CurrentValue )}' property, not '{nameof( CurrentValueAsString )}'." );
    }

    protected Task OnChangeAsync( ChangeEventArgs args )
    {
        return SetCurrentValueAsync( (bool)args.Value! );
    }
}
