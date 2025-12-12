// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using System.Globalization;
using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents an input field for entering <see cref="DateTime"/> values.
/// </summary>
public partial class LumexDatebox : LumexInputFieldBase<DateTime?>
{
	private const string DateFormat = "yyyy-MM-dd";
	private const string DefaultParsingErrorMessage = "The {0} field must be a date.";

	/// <summary>
	/// Gets or sets the date box type of the.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="InputDateboxType.Date"/>
	/// </remarks>
	[Parameter]
	public InputDateboxType DateboxType { get; set; } = InputDateboxType.Date;

	/// <summary>
	/// Optional custom parsing error message
	/// </summary>
	[Parameter]
	public string? ParsingErrorMessage { get; set; }

	private string _parsingErrorText = DefaultParsingErrorMessage;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( DateboxType != InputDateboxType.Date )
		{
			throw new InvalidOperationException(
				$"LumexDatebox does not currently support {DateboxType}. Only Date is implemented." );
		}

		SetInputType( "date" );

		_parsingErrorText = string.IsNullOrWhiteSpace( ParsingErrorMessage )
			? DefaultParsingErrorMessage
			: ParsingErrorMessage!;

		if( !Disabled && !ReadOnly )
		{
			Focused = true;
		}

		base.OnParametersSet();
	}

	/// <inheritdoc />
	protected override bool TryParseValueFromString( string? value, out DateTime? result )
	{
		if( string.IsNullOrWhiteSpace( value ) )
		{
			result = null;
			return true;
		}

		if( DateTime.TryParseExact(
				   value,
				   DateFormat,
				   CultureInfo.InvariantCulture,
				   DateTimeStyles.None,
				   out DateTime dt ) )
		{
			result = dt;
			return true;
		}

		result = null;
		return false;
	}

	/// <inheritdoc />
	protected override string FormatValueAsString( DateTime? value )
		=> value.HasValue
			? value.Value.ToString( DateFormat, CultureInfo.InvariantCulture )
			: string.Empty;
}