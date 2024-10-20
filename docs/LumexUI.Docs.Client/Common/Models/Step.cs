using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Common;

public class Step
{
    public RenderFragment? Body { get; init; }
    public CodeBlock? Code { get; init; }
    public string? Title { get; init; }
}
