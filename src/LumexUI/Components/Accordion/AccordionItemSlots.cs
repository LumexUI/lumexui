using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

[ExcludeFromCodeCoverage]
public class AccordionItemSlots : ISlot
{
    public string? Root { get; set; }
    public string? Heading { get; set; }
    public string? Trigger { get; set; }
    public string? TitleWrapper { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public string? StartContent { get; set; }
    public string? Indicator { get; set; }
    public string? Content { get; set; }
}
