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

    private string ToolbarClass => ElementClass.Empty()
        .Add( "p-2" )
        .Add( "border-t" )
        .Add( "border-foreground-950/5" )
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
        _previewClasses.Preview += PreviewClasses?.Background;
        _previewClasses.PreviewWrapper += PreviewClasses?.Background;
        _previewClasses.Background += PreviewClasses?.Background;
    }

    private void Expand()
    {
        _expanded = !_expanded;
    }

    private async Task CopyToClipboard()
    {
        await JSRuntime.InvokeVoidAsync( "LumexDocs.copyToClipboard", _id );
        _copied = true;
        StateHasChanged();

        await Task.Delay( 2000 );
        _copied = false;
        StateHasChanged();
    }
}
