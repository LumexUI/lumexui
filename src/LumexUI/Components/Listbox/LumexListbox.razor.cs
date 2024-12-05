// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[CascadingTypeParameter( nameof( T ) )]
public partial class LumexListbox<T> : LumexComponentBase
{
    /// <summary>
    /// 
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public RenderFragment? EmptyContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public IEnumerable<T>? Items { get; set; }

    private readonly ListboxContext<T> _context;

    private ListboxSlots _slots = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexListbox{T}"/>.
    /// </summary>
    public LumexListbox()
    {
        _context = new ListboxContext<T>( this );

        As = "ul";
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _slots ??= Listbox.GetStyles( this, TwMerge );
    }
}