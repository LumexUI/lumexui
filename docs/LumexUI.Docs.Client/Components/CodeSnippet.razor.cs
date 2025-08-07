using LumexUI.Docs.Client.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;

namespace LumexUI.Docs.Client.Components;

public partial class CodeSnippet
{
    [Parameter] public string? Id { get; set; }
	[Parameter] public bool Expandable { get; set; }
    [Parameter, EditorRequired] public CodeBlock Code { get; set; } = default!;

    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

    private readonly RenderFragment _renderCodeSnippet;
    private ElementReference _ref;
	private bool _isExpanded;

	public CodeSnippet()
    {
        _renderCodeSnippet = RenderCodeSnippet;
    }

    protected override async Task OnAfterRenderAsync( bool firstRender )
    {
        if( firstRender )
        {
            await JSRuntime.InvokeVoidAsync( "Prism.highlightAllUnder", _ref );
        }
    }

    private void RenderCodeSnippet( RenderTreeBuilder __builder )
    {
        var resourceName = typeof( CodeSnippet ).Assembly
            .GetManifestResourceNames()
            .FirstOrDefault( x => x.Contains( $"{Code.Snippet}.html" ) );

        if( string.IsNullOrEmpty( resourceName ) )
        {
            return;
        }

        using var resourceStream = typeof( CodeSnippet ).Assembly.GetManifestResourceStream( resourceName );
        using var reader = new StreamReader( resourceStream! );
        var content = reader.ReadToEnd();

        __builder.AddMarkupContent( 0, content );
    }
}
