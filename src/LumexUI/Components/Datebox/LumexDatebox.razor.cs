// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using LumexUI.Extensions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using InputDateType = LumexUI.Common.InputDateType;

namespace LumexUI;

/// <summary>
/// A component that represents an input field for entering date values.
/// </summary>
/// <remarks>
/// The supported types for the date value are:
///		<list type="bullet">
///		<item><description><see cref="DateTime"/></description></item>
///		<item><description><see cref="DateTimeOffset"/></description></item>
///		<item><description><see cref="DateOnly"/></description></item>
///		<item><description><see cref="TimeOnly"/></description></item>
///		</list>
/// </remarks>
public partial class LumexDatebox<TValue> : LumexInputFieldBase<TValue>
{
	private const string DateFormat = "yyyy-MM-dd";                     // Compatible with HTML 'date' inputs
	private const string DateTimeLocalFormat = "yyyy-MM-ddTHH:mm:ss";   // Compatible with HTML 'datetime-local' inputs
	private const string MonthFormat = "yyyy-MM";                       // Compatible with HTML 'month' inputs
	private const string TimeFormat = "HH:mm:ss";                       // Compatible with HTML 'time' inputs

	/// <summary>
	/// Gets or sets the input type of the datebox.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="InputDateType.Date"/>
	/// </remarks>
	[Parameter]
	public InputDateType Type { get; set; } = InputDateType.Date;

	/// <inheritdoc/>
	protected override bool FilledOrFocused => true;

	private string _format = default!;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexDatebox{TValue}"/>.
	/// </summary>
	public LumexDatebox()
	{
		var type = Nullable.GetUnderlyingType( typeof( TValue ) ) ?? typeof( TValue );

		if( type != typeof( DateTime ) &&
			type != typeof( DateTimeOffset ) &&
			type != typeof( DateOnly ) &&
			type != typeof( TimeOnly ) )
		{
			throw new InvalidOperationException( $"Unsupported {GetType()} type param '{type}'." );
		}
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		SetInputType( Type.ToDescription() );

		_format = Type switch
		{
			InputDateType.Date => DateFormat,
			InputDateType.DateTimeLocal => DateTimeLocalFormat,
			InputDateType.Month => MonthFormat,
			InputDateType.Time => TimeFormat,
			_ => throw new InvalidOperationException( $"Unsupported {nameof( InputDateType )} '{Type}'." )
		};		
	}

	/// <inheritdoc />
	[ExcludeFromCodeCoverage]
	protected override string FormatValueAsString( TValue? value )
	{
		return value switch
		{
			DateTime dateTimeValue => BindConverter.FormatValue( dateTimeValue, _format, CultureInfo.InvariantCulture ),
			DateTimeOffset dateTimeOffsetValue => BindConverter.FormatValue( dateTimeOffsetValue, _format, CultureInfo.InvariantCulture ),
			DateOnly dateOnlyValue => BindConverter.FormatValue( dateOnlyValue, _format, CultureInfo.InvariantCulture ),
			TimeOnly timeOnlyValue => BindConverter.FormatValue( timeOnlyValue, _format, CultureInfo.InvariantCulture ),
			_ => string.Empty, // Handles null for Nullable<DateTime>, etc.
		};
	}

	/// <inheritdoc />
	protected override bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out TValue result )
	{
		if( BindConverter.TryConvertTo( value, CultureInfo.InvariantCulture, out result ) )
		{
			Debug.Assert( result != null );
			return true;
		}
		else
		{
			return false;
		}
	}
}