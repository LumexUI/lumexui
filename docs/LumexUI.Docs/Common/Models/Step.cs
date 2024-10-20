using LumexUI.Docs.Client.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Common;

public class Step
{
    public RenderFragment? Body { get; init; }
    public CodeBlock? Code { get; init; }
    public string? Title { get; init; }
}
