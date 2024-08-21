// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TValue"></typeparam>
[CascadingTypeParameter( nameof( TValue ) )]
public partial class LumexSelect<TValue> : LumexInputFieldBase<TValue>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the select.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Select.GetStyles( this ) );

    private new string? MainWrapperClass =>
        TwMerge.Merge( Select.GetMainWrapperStyles( this ) );

    private string? TriggerClass =>
        TwMerge.Merge( Select.GetTriggerStyles( this ) );

    private string? PopoverContentClass =>
        TwMerge.Merge( Select.GetPopoverContentStyles( this ) );

    private readonly SelectContext<TValue> _context;

    private LumexPopover? _popoverRef;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexSelect{TValue}"/>.
    /// </summary>
    public LumexSelect()
    {
        _context = new SelectContext<TValue>( this );

        As = "button";
    }

    private Task TriggerPopoverAsync()
    {
        if( _popoverRef is null )
        {
            return Task.CompletedTask;
        }

        return _popoverRef.TriggerAsync();
    }
}
