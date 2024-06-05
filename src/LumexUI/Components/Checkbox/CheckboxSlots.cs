using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

[ExcludeFromCodeCoverage]
public class CheckboxSlots : ISlot
{
    public string? Root { get; set; }
    public string? Wrapper { get; set; }
    public string? Icon { get; set; }
    public string? Label { get; set; }
}
