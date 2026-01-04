// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;

namespace LumexUI.Common;

/// <summary>
/// Specifies the type of the <see cref="LumexDatebox"/>.
/// </summary>
public enum InputDateType
{
	/// <summary>
	/// Represents a date value without a time component.
	/// </summary>
	[Description( "date" )]
	Date,

	/// <summary>
	/// Represents a date and time value without a time zone.
	/// </summary>
	[Description( "datetime-local" )]
	DateTimeLocal,

	/// <summary>
	/// Represents the month component of a date or time value.
	/// </summary>
	[Description( "month" )]
	Month,

	/// <summary>
	/// Represents a time value to indicate a specific time of day without a date component.
	/// </summary>
	[Description( "time" )]
	Time,
}