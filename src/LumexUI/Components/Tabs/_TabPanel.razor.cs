// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Internal;

/// <summary>
/// 
/// </summary>
public partial class _TabPanel : LumexComponentBase
{
    /// <summary>
    /// 
    /// </summary>
    [Parameter] public LumexTab ActiveTab { get; set; } = default!;

    [CascadingParameter] internal TabsContext Context { get; set; } = default!;

    private TabsSlots Slots => Context.Owner.Slots;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( _TabPanel ) );
    }
}