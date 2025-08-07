using LumexUI.Docs.Client.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LumexUI.Docs.Client.Components;

public partial class PreviewCode
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter, EditorRequired] public CodeBlock Code { get; set; } = default!;
    [Parameter] public Preview.Slots? PreviewClasses { get; set; }
    [Parameter] public string? Class { get; set; }

    private string? BaseClass => ElementClass.Empty()
        .Add( "rounded-2xl" )
        .Add( "ring" )
        .Add( "ring-default-900/10" )
        .Add( "shadow-xs" )
        .Add( "overflow-hidden" )
        .Add( Class )
        .ToString();

    private string ToolbarClass => ElementClass.Empty()
        .Add( "p-2" )
        .Add( "bg-default-50/50" )
        .Add( "border-default-900/10" )
        .Add( "border-b", when: _expanded )
        .Add( "rounded-b-xl", when: !_expanded )
        .ToString();

    private readonly string _id = Identifier.New();
    private readonly Preview.Slots _previewClasses = new()
    {
        PreviewWrapper = "rounded-b-none",
    };

    private bool _expanded;
    private bool _copied;

    protected override void OnInitialized()
    {
        // temp solution
        _previewClasses.Preview = new ElementClass( _previewClasses.Preview )
            .Add( PreviewClasses?.Preview )
            .ToString();

        _previewClasses.PreviewWrapper = new ElementClass( _previewClasses.PreviewWrapper )
            .Add( PreviewClasses?.PreviewWrapper )
            .ToString();

        _previewClasses.Background = new ElementClass( _previewClasses.Background )
            .Add( PreviewClasses?.Background )
            .ToString();
    }

    private void Expand()
    {
        _expanded = !_expanded;
    }

    private async Task CopyToClipboard()
    {
        await JSRuntime.InvokeVoidAsync( "copyToClipboard", _id );
        _copied = true;
        StateHasChanged();

        await Task.Delay( 2000 );
        _copied = false;
        StateHasChanged();
    }
}
