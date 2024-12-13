// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

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
        base.OnInitialized();

        ContextNullException.ThrowIfNull( SelectContext, nameof( LumexSelectItem<TValue> ) );
        SelectContext.Register( this );
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        Debug.Assert( Value is not null );

        if( string.IsNullOrEmpty( TextValue ) )
        {
            TextValue = Value.ToString();
        }
    }

    /// <inheritdoc />
    public override void Dispose()
    {
        SelectContext.Unregister( this );
        base.Dispose();
    }
}