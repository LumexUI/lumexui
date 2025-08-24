using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexRadio{TValue}"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class RadioSlots : SlotBase
{   
    /// <summary>
    /// Radio wrapper, it wraps the control element.
    /// </summary>
    public string? ControlWrapper { get; set; }
    
    /// <summary>
    /// Label and description wrapper.
    /// </summary>
    public string? LabelWrapper { get; set; }
    
    /// <summary>
    /// Label slot for the radio.
    /// </summary>
    public string? Label { get; set; }
    
    /// <summary>
    /// Control element, it is the circle element.
    /// </summary>
    public string? Control { get; set; }
    
    /// <summary>
    /// Description slot for the radio.
    /// </summary>
    public string? Description { get; set; }
}
