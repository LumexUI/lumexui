// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexAccordionItem : LumexComponentBase, IDisposable
{
    /// <summary>
    /// Gets or sets content to be rendered inside the accordion item.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the accordion item.
    /// </summary>
    [Parameter, EditorRequired] public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the accordion item.
    /// </summary>
    [Parameter] public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the subtitle of the accordion item.
    /// </summary>
    [Parameter] public string? Subtitle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the accordion item is expanded.
    /// </summary>
    [Parameter] public bool Expanded { get; set; }

    /// <summary>
    /// Gets or sets the callback that is invoked when the expanded state of the accordion item changes.
    /// </summary>
    [Parameter] public EventCallback<bool> ExpandedChanged { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the accordion item is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    [CascadingParameter] internal AccordionContext Context { get; set; } = default!;

    private protected override string? RootClass =>
        TwMerge.Merge( AccordionItem.GetStyles( this ) );

    private string HeadingClass =>
        TwMerge.Merge( AccordionItem.GetHeadingStyles( this ) );

    private string TriggerClass =>
        TwMerge.Merge( AccordionItem.GetTriggerStyles( this ) );

    private string TitleWrapperClass =>
        TwMerge.Merge( AccordionItem.GetTitleWrapperStyles( this ) );

    private string TitleClass =>
        TwMerge.Merge( AccordionItem.GetTitleStyles( this ) );

    private string SubtitleClass =>
        TwMerge.Merge( AccordionItem.GetSubtitleStyles( this ) );

    private string ContentClass =>
        TwMerge.Merge( AccordionItem.GetSubtitleStyles( this ) );

    private bool _disposed;
    private bool _disabled;
    private bool _expanded;

    public Task ExpandAsync()
    {
        return SetExpandedStateTo( true );
    }

    public Task CollapseAsync()
    {
        return SetExpandedStateTo( false );
    }

    protected override void OnInitialized()
    {
        AccordionContext.ThrowMissingParentComponentException( Context, nameof( LumexAccordionItem ) );

        Context.Register( this );
    }

    protected override void OnParametersSet()
    {
        if( string.IsNullOrWhiteSpace( Id ) )
        {
            throw new InvalidOperationException(
                $"{GetType()} requires a non-null, non-empty, non-whitespace value for parameter '{nameof( Id )}'." );
        }

        _disabled = Disabled || Context.Owner.Disabled;
        _expanded = Expanded || Context.Owner.DefaultExpandedItems.Contains( Id );
    }

    private async Task ToggleExpansionAsync()
    {
        if( _disabled )
        {
            return;
        }

        _expanded = !_expanded;

        await Context.ToggleExpansionAsync( this );
        await ExpandedChanged.InvokeAsync( _expanded );
    }

    private Task SetExpandedStateTo( bool expanded )
    {
        _expanded = expanded;
        StateHasChanged();

        return ExpandedChanged.InvokeAsync( _expanded );
    }

    public void Dispose()
    {
        Dispose( disposing: true );
        GC.SuppressFinalize( this );
    }

    protected virtual void Dispose( bool disposing )
    {
        if( !_disposed )
        {
            if( disposing )
            {
                Context.Unregister( this );
            }

            _disposed = true;
        }
    }
}