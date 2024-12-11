// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class LumexSelectItem<TValue> : LumexListboxItem<TValue> 
{
    [CascadingParameter] internal new SelectContext<TValue> Context { get; set; } = default!;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexSelectItem<TValue> ) );
    }
}