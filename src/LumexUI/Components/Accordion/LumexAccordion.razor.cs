// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexAccordion : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the accordion.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets an appearance style of the accordion.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="Variant.Light"/>
    /// </remarks>
    [Parameter] public AccordionVariant Variant { get; set; }

    /// <summary>
    /// Gets or sets the selection mode for the accordion, 
    /// determining how items can be selected.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="SelectionMode.Single"/>
    /// </remarks>
    [Parameter] public SelectionMode SelectionMode { get; set; } = SelectionMode.Single;

    /// <summary>
    /// Gets or sets a value indicating whether the accordion is full-width.
    /// </summary>
    /// <remarks>
    /// The default is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool FullWidth { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the accordion items are disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display a divider 
    /// under each accordion item (except the last one).
    /// </summary>
    /// <remarks>
    /// The default is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool ShowDivider { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to display an indicator in each accordion item.
    /// </summary>
    /// <remarks>
    /// The default is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool ShowIndicators { get; set; } = true;

    /// <summary>
    /// Gets or sets the set of accordion item identifiers that are expanded by default in the accordion.
    /// </summary>
    [Parameter] public string[] ExpandedItems { get; set; } = [];

    /// <summary>
    /// Gets or sets the set of accordion item identifiers that are disabled in the accordion.
    /// </summary>
    [Parameter] public string[] DisabledItems { get; set; } = [];

    /// <summary>
    /// Gets or sets the CSS class names for the accordion items slots.
    /// </summary>
    [Parameter] public AccordionItemSlots? ItemClasses { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Accordion.GetStyles( this ) );

    private readonly AccordionContext _context;

    public LumexAccordion()
    {
        _context = new AccordionContext( this );
    }

    protected override void OnParametersSet()
    {
        if( SelectionMode is SelectionMode.Single && ExpandedItems.Length > 0 )
        {
            throw new InvalidOperationException(
                $"{GetType()} requires '{nameof( SelectionMode )}' parameter to be " +
                $"'{nameof( SelectionMode.Multiple )}' if used with '{nameof( ExpandedItems )}'." );
        }
    }
}