// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI;

/// <summary>
/// A component representing a selectable item within the <see cref="LumexSelect{TValue}"/>.
/// </summary>
/// <typeparam name="TValue">The type of the value associated with the select item.</typeparam>
public class LumexSelectItem<TValue> : LumexListboxItem<TValue>, IDisposable
{
    /// <summary>
    /// Gets or sets a text representation of the select item value.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="LumexListboxItem{TValue}.Value"/>
    /// </remarks>
    [Parameter] public string? TextValue { get; set; }

    [CascadingParameter] internal SelectContext<TValue> SelectContext { get; set; } = default!;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( SelectContext, nameof( LumexSelectItem<TValue> ) );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        if( Value is null )
        {
            throw new InvalidOperationException(
                $"{GetType()} requires a value for the {nameof( Value )} parameter." );
        }

        if( string.IsNullOrEmpty( TextValue ) )
        {
            TextValue = BindConverter.FormatValue( Value.ToString() );
        }
    }

    /// <inheritdoc />
    protected override void BuildRenderTree( RenderTreeBuilder builder )
    {
        SelectContext.Register( this );
    }

    /// <inheritdoc />
    public override void Dispose()
    {
        SelectContext.Unregister( this );
        base.Dispose();
    }
}