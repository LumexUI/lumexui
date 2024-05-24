// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexCard : LumexComponentBase, ISlotComponent<CardSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the card.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the border radius of the card.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Radius.Large"/>
    /// </remarks>
    [Parameter] public Radius Radius { get; set; } = Radius.Large;

    /// <summary>
    /// Gets or sets the shadow of the card.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Shadow.Medium"/>
    /// </remarks>
    [Parameter] public Shadow Shadow { get; set; } = Shadow.Small;

    /// <summary>
    /// Gets or sets a value indicating whether the card is full-width.
    /// </summary>
    [Parameter] public bool FullWidth { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the card is blurred.
    /// </summary>
    [Parameter] public bool Blurred { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the card slots.
    /// </summary>
    [Parameter] public CardSlots? Classes { get; set; }

    private protected override string? RootClass
        => TwMerge.Merge( Card.GetStyles( this ) );

    private readonly CardContext _context;

    public LumexCard()
    {
        _context = new CardContext( this );
    }
}