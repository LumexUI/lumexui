namespace LumexUI.Common;

/// <summary>
/// Represents a method that resolves the indicator icon 
/// of the stateful component based on its active state.
/// </summary>
/// <param name="active">A boolean value indicating whether the component is in active state.</param>
/// <returns>A <see langword="string"/> representing the indicator icon; otherwise, <see langword="null"/> if no indicator is needed.</returns>
public delegate string? IndicatorResolver( bool active );
