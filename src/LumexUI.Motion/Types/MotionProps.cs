namespace LumexUI.Motion.Types;

/// <summary>
/// 
/// </summary>
public record MotionProps
{
    /// <summary>
    /// 
    /// </summary>
    public object? Enter { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public object? Exit { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public object? Transition { get; init; }
}