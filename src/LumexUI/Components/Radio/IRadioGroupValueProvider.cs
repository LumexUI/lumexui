// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI;

/// <summary>
/// Interface for providing the value of a radio group.
/// </summary>
/// <typeparam name="TValue">Type of value the radio group represents.</typeparam>
public interface IRadioGroupValueProvider<out TValue>
{
    /// <summary>
    /// The currently-selected value of the radio group.
    /// </summary>
    public TValue? CurrentValue { get; }
}