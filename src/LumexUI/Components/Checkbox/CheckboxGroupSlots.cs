using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

[ExcludeFromCodeCoverage]
public class CheckboxGroupSlots : ISlot
{
    public string? Root { get; set; }
    public string? Wrapper { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }
}
