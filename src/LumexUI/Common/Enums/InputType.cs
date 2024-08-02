// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

namespace LumexUI.Common;

/// <summary>
/// Specifies the different types of input elements.
/// </summary>
public enum InputType
{
    /// <summary>
    /// A text input field.
    /// </summary>
    [Description( "text" )]
    Text,

    /// <summary>
    /// A password input field.
    /// </summary>
    [Description( "password" )]
    Password,

    /// <summary>
    /// An email input field.
    /// </summary>
    [Description( "email" )]
    Email,

    /// <summary>
    /// A hidden input field.
    /// </summary>
    [Description( "hidden" )]
    Hidden,

    /// <summary>
    /// A number input field.
    /// </summary>
    [Description( "number" )]
    Number,

    /// <summary>
    /// A search input field.
    /// </summary>
    [Description( "search" )]
    Search,

    /// <summary>
    /// A telephone input field.
    /// </summary>
    [Description( "tel" )]
    Telephone,

    /// <summary>
    /// A URL input field.
    /// </summary>
    [Description( "url" )]
    Url,

    /// <summary>
    /// A color input field.
    /// </summary>
    [Description( "color" )]
    Color,

    /// <summary>
    /// A date input field.
    /// </summary>
    [Description( "date" )]
    Date,

    /// <summary>
    /// A date-time input field (local time).
    /// </summary>
    [Description( "datetime-local" )]
    DateTimeLocal,

    /// <summary>
    /// A month input field.
    /// </summary>
    [Description( "month" )]
    Month,

    /// <summary>
    /// A time input field.
    /// </summary>
    [Description( "time" )]
    Time,

    /// <summary>
    /// A week input field.
    /// </summary>
    [Description( "week" )]
    Week
}
