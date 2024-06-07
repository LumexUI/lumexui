// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexCheckboxGroup : LumexComponentBase, ISlotComponent<CheckboxGroupSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the checkbox group.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the label for the checkbox group.
    /// </summary>
    [Parameter] public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the description for the checkbox group.
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the checkbox group is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the checkbox group slots.
    /// </summary>
    [Parameter] public CheckboxGroupSlots? Classes { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the checkboxes slots.
    /// </summary>
    [Parameter] public CheckboxSlots? CheckboxClasses { get; set; }

    private protected override string RootClass =>
        TwMerge.Merge( CheckboxGroup.GetStyles( this ) );

    private string LabelClass =>
        TwMerge.Merge( CheckboxGroup.GetLabelStyles( this ) );

    private string WrapperClass =>
        TwMerge.Merge( CheckboxGroup.GetWrapperStyles( this ) );

    private string DescriptionClass =>
        TwMerge.Merge( CheckboxGroup.GetDescriptionStyles( this ) );

    private readonly CheckboxGroupContext _context;

    public LumexCheckboxGroup()
    {
        _context = new CheckboxGroupContext( this );
    }
}