using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexRadioGroup{TValue}"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class RadioGroupSlots : SlotBase
{
    /// <summary>
    /// Radio group wrapper, it wraps all Radios.
    /// </summary>
    public string? Wrapper { get; set; }
    
    /// <summary>
    /// Radio group label, it is placed before the wrapper.
    /// </summary>
    public string? Label { get; set; }
    
    /// <summary>
    /// Description slot for the radio group.
    /// </summary>
    public string? Description { get; set; }
}
