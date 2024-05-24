// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Styles;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

public partial class LumexAccordionItem : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the accordion item.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the title of the accordion item.
    /// </summary>
    [Parameter] public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the subtitle of the accordion item.
    /// </summary>
    [Parameter] public string? Subtitle { get; set; }

    /// <summary>
    /// Gets or sets a callback that is fired whenever the accordion item is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [CascadingParameter] internal AccordionContext Context { get; set; } = default!;

    private protected override string? RootClass
        => TwMerge.Merge( AccordionItem.GetStyles( this ) );

    private string HeadingClass
        => TwMerge.Merge( AccordionItem.GetHeadingStyles( this ) );

    private string TriggerClass
        => TwMerge.Merge( AccordionItem.GetTriggerStyles( this ) );

    private string TitleWrapperClass 
        => TwMerge.Merge( AccordionItem.GetTitleWrapperStyles( this ) );

    private string TitleClass
        => TwMerge.Merge( AccordionItem.GetTitleStyles( this ) );

    private string SubtitleClass
        => TwMerge.Merge( AccordionItem.GetSubtitleStyles( this ) );

    protected override void OnInitialized()
    {
        AccordionContext.ThrowMissingParentComponentException( Context, nameof( LumexAccordionItem ) );
    }

    private Task OnClickAsync( MouseEventArgs args )
    {
        // TODO: Implement toggling
        return Context.Owner.Disabled ? Task.CompletedTask : OnClick.InvokeAsync( args );
    }
}