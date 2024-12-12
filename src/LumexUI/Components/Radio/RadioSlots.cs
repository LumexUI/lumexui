using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Style slots for <see cref="LumexRadio{TValue}"/>
/// </summary>
[ExcludeFromCodeCoverage]
public class RadioSlots : ISlot
{
    /// <summary>
    /// Radio root wrapper, it wraps all elements.
    /// </summary>
    public string? Root { get; set; }
    
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
