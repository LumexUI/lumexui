// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexAccordion : LumexComponentBase, ISlotComponent<AccordionSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the accordion.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the selection mode for the accordion, 
    /// determining how items can be selected.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="SelectionMode.Single"/>.
    /// </remarks>
    [Parameter] public SelectionMode SelectionMode { get; set; } = SelectionMode.Single;

    /// <summary>
    /// Gets or sets a value indicating whether the accordion is full-width.
    /// </summary>
    /// <remarks>
    /// The default is <see langword="true"/>.
    /// </remarks>
    [Parameter] public bool FullWidth { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the accordion items are disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the set of item identifiers that are expanded by default in the accordion.
    /// </summary>
    [Parameter] public string[] DefaultExpandedItems { get; set; } = [];

    /// <summary>
    /// Gets or sets the CSS class names for the card slots.
    /// </summary>
    [Parameter] public AccordionSlots? Classes { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Accordion.GetStyles( this ) );

    private readonly AccordionContext _context;

    public LumexAccordion()
    {
        _context = new AccordionContext( this );
    }

    protected override void OnParametersSet()
    {
        if( SelectionMode is SelectionMode.Multiple && DefaultExpandedItems.Length > 0 )
        {
            throw new InvalidOperationException(
                $"{GetType()} requires '{nameof( SelectionMode )}' parameter to be " +
                $"'{nameof( SelectionMode.Single )}' if used with '{nameof( DefaultExpandedItems )}'." );
        }
    }
}