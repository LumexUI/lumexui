using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Style slots for <see cref="LumexRadioGroup{TValue}"/>
/// </summary>
[ExcludeFromCodeCoverage]
public class RadioGroupSlots : ISlot
{
    /// <summary>
    /// Radio group root wrapper, it wraps the label and the wrapper.
    /// </summary>
    public string? Root { get; set; }
    
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
