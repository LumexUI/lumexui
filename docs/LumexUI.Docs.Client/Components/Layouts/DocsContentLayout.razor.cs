using LumexUI.Docs.Client.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Components;

public partial class DocsContentLayout
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    private string RelativePath => NavigationManager.ToBaseRelativePath( NavigationManager.Uri );

    private readonly List<DocsSection> _sections = [];
    private Heading[] _tableOfContents = [];
    private ComponentLinksProps? _linksProps;

    private string? _title;
    private string? _category;
    private string? _description;

    public void Initialize(
        string title,
        string category,
        string description,
        Heading[] headings,
        ComponentLinksProps? linksProps = null )
    {
        _title = title;
        _category = category;
        _description = description;
        _tableOfContents = headings;
        _linksProps = linksProps;

        StateHasChanged();
    }
}
