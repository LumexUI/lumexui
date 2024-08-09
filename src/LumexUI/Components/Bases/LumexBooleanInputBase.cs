using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public abstract class LumexBooleanInputBase : LumexInputBase<bool>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the input.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets the disabled state of the input.
    /// Derived classes can override this to determine the input's disabled state.
    /// </summary>
    /// <returns>A <see cref="bool"/> value indicating whether the input is disabled.</returns>
    protected internal virtual bool GetDisabledState() => Disabled;

    /// <summary>
    /// Gets the readonly state of the input.
    /// Derived classes can override this to determine the input's readonly state.
    /// </summary>
    /// <returns>A <see cref="bool"/> value indicating whether the input is readonly.</returns>
    protected internal virtual bool GetReadOnlyState() => ReadOnly;

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out bool result )
    {
        throw new NotSupportedException(
            $"This component does not parse string inputs. " +
            $"Bind to the '{nameof( CurrentValue )}' property, not '{nameof( CurrentValueAsString )}'." );
    }

    /// <inheritdoc />
    protected override ValueTask SetValidationMessageAsync( bool parsingFailed )
    {
        // This component doesn't have a validation message by default.
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Handles the change event asynchronously.
    /// Derived classes can override this to specify custom behavior when the input's value changes.
    /// </summary>
    /// <param name="args">The change event arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected virtual Task OnChangeAsync( ChangeEventArgs args )
    {
        if( GetDisabledState() || GetReadOnlyState() )
        {
            return Task.CompletedTask;
        }

        return SetCurrentValueAsync( (bool)args.Value! );
    }
}
