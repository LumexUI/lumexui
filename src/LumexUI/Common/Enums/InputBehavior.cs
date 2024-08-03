// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies when the input component updates its value and triggers validation.
/// </summary>
public enum InputBehavior
{
    /// <summary>
    /// Updates the value and triggers validation 
    /// on each input event (e.g., when the user types in the input field).
    /// </summary>
    OnInput,

    /// <summary>
    /// Updates the value and triggers validation 
    /// on change events (e.g., when the input field loses focus or the user presses enter).
    /// </summary>
    OnChange
}
