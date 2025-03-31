// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using LumexUI.Common;
using LumexUI.Extensions;

namespace LumexUI;

/// <summary>
/// A component that represents an input field for entering <see cref="DateTime"/> values.
/// </summary>
public partial class LumexDatePicker : LumexInputFieldBase<DateTime?>
{
	private readonly InputType _type = InputType.DateTime;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		SetInputType( _type.ToDescription() );

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

		if( DateTime.TryParseExact( value, "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dt ) )
		{
			result = dt;
			return true;
		}

		if( DateTime.TryParse( value, CultureInfo.CurrentCulture, DateTimeStyles.None, out dt ) )
		{
			result = dt;
			return true;
		}

		result = null;
		return false;
	}

	/// <inheritdoc />
	protected override string FormatValueAsString( DateTime? value )
	{
		return value.HasValue
			? value.Value.ToString( "O", CultureInfo.InvariantCulture )
			: string.Empty;
	}
}
