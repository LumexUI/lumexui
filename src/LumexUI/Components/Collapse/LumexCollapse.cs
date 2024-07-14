// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Extensions;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;

using Utils = LumexUI.Utilities.Utils;

namespace LumexUI;

public class LumexCollapse : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the collapse.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the collapse is expanded.
    /// </summary>
    [Parameter] public bool Expanded { get; set; }

    /// <summary>
    /// Gets or sets the callback to be invoked when a collapse/expand transition ends.
    /// </summary>
    [Parameter] public EventCallback OnTransitionEnd { get; set; }

    internal CollapseState State { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Collapse.GetStyles( this ) );

    private protected override string? RootStyle =>
        ElementStyle.Empty()
            .Add( "height", $"{_height}px", when: State is CollapseState.Collapsing or CollapseState.Expanding )
            .Add( base.RootStyle )
            .ToString();

    private int _height;
    private bool _expanded;
    private bool _isRendered;
    private bool _heightUpdated;

    /// <inheritdoc />
    protected override void BuildRenderTree( RenderTreeBuilder builder )
    {
        builder.OpenElement( 0, As );
        builder.AddAttribute( 1, "class", RootClass );
        builder.AddAttribute( 2, "style", RootStyle );
        builder.AddAttribute( 3, "data-state", Utils.GetDataAttributeValue( State ) );
        builder.AddAttribute( 4, "ontransitionend", EventCallback.Factory.Create( this, OnTransitionEndAsync ) );
        builder.AddMultipleAttributes( 5, AdditionalAttributes );
        builder.AddElementReferenceCapture( 6, elementReference => ElementReference = elementReference );
        builder.AddContent( 7, ChildContent );
        builder.CloseElement();
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        // We don't want to call `UpdateHeightAsync` every time the component is rendered.
        if( _expanded == Expanded )
        {
            return;
        }

        _expanded = Expanded;

        if( _isRendered )
        {
            _heightUpdated = false;
            SetTransitionState();
        }
        else if( _expanded )
        {
            State = CollapseState.Expanded;
        }
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync( bool firstRender )
    {
        if( _heightUpdated )
        {
            return;
        }

        if( firstRender )
        {
            _isRendered = true;
            await UpdateHeightAsync();
            return;
        }

        if( State is CollapseState.Expanding or CollapseState.Collapsing )
        {
            await UpdateHeightAsync();
            StateHasChanged();
        }
    }

    private async ValueTask UpdateHeightAsync()
    {
        try
        {
            _height = await ElementReference.GetScrollHeightAsync();

            if( State is CollapseState.Collapsing )
            {
                _height = 0;
            }

            _heightUpdated = true;
        }
        catch( Exception ex ) when( ex is JSDisconnectedException or TaskCanceledException )
        {
            _height = 0;
        }
    }

    private Task OnTransitionEndAsync()
    {
        if( State is CollapseState.Expanding )
        {
            State = CollapseState.Expanded;
        }
        else if( State is CollapseState.Collapsing )
        {
            State = CollapseState.Collapsed;
        }

        return OnTransitionEnd.InvokeAsync();
    }

    private void SetTransitionState()
    {
        if( State is CollapseState.Expanded )
        {
            State = CollapseState.Collapsing;
        }
        else if( State is CollapseState.Collapsed )
        {
            State = CollapseState.Expanding;
        }
    }

    internal enum CollapseState
    {
        Collapsed, Expanding, Expanded, Collapsing
    }
}
