using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

[ExcludeFromCodeCoverage]
public class SwitchSlots : ISlot
{
    public string? Root { get; set; }
    public string? Wrapper { get; set; }
    public string? Thumb { get; set; }
    public string? Label { get; set; }
    public string? StartIcon { get; set; }
    public string? EndIcon { get; set; }
    public string? ThumbIcon { get; set; }
}
