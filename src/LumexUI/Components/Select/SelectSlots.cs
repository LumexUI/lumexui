using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// 
/// </summary>
[ExcludeFromCodeCoverage]
public class SelectSlots : ISlot
{
    /// <summary>
    /// 
    /// </summary>
    public string? Root { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? MainWrapper { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Trigger { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? InnerWrapper { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? SelectorIcon { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Listbox { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? PopoverContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? HelperWrapper { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ErrorMessage { get; set; }
}
