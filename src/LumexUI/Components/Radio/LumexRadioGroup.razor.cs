// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexRadioGroup : LumexComponentBase, ISlotComponent<RadioGroupSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the radio group.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the label for the radio group.
    /// </summary>
    [Parameter] public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the description for the radio group.
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the radio group is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the radio group is read-only.
    /// </summary>
    [Parameter] public bool ReadOnly { get; set; }

    /// <summary>
    /// Gets or sets a color of the radio group.
    /// </summary>
    /// <remarks>
    /// The default is <see cref="ThemeColor.Primary"/>
    /// </remarks>
    [Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

    /// <summary>
    /// Gets or sets the size of the radio group.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Size.Medium"/>
    /// </remarks>
    [Parameter] public Size Size { get; set; } = Size.Medium;
    
    /// <summary>
    /// Gets or sets the orientation of the radio group.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="Orientation.Vertical"/>
    /// </remarks>
    [Parameter] public Orientation Orientation { get; set; } = Orientation.Vertical;
    
    /// <summary>
    /// Gets or sets the CSS class names for the radio group slots.
    /// </summary>
    [Parameter] public RadioGroupSlots? Classes { get; set; }
    
    /// <summary>
    /// Gets or sets the CSS class names for the radio button slots.
    /// </summary>
    [Parameter] public RadioSlots? RadioClasses { get; set; }
    
    private protected override string? RootClass =>
        TwMerge.Merge( RadioGroup.GetStyles( this ) );

    private string? LabelClass =>
        TwMerge.Merge( RadioGroup.GetLabelStyles( this ) );

    private string? WrapperClass =>
        TwMerge.Merge( RadioGroup.GetWrapperStyles( this ) );

    private string? DescriptionClass =>
        TwMerge.Merge( RadioGroup.GetDescriptionStyles( this ) );
    
    private readonly RadioGroupContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexRadioGroup"/>.
    /// </summary>
    public LumexRadioGroup()
    {
        _context = new RadioGroupContext( this );
    }
}