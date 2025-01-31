// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents an input field for entering <see cref="string"/> values.
/// </summary>
public partial class LumexTextbox : LumexInputFieldBase<string?>
{
	/// <summary>
	/// Gets or sets the input type of the textbox.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="InputType.Text"/>
	/// </remarks>
	[Parameter] public InputType Type { get; set; } = InputType.Text;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		SetInputType( Type.ToDescription() );

		base.OnParametersSet();
	}

	/// <inheritdoc />
	protected override bool TryParseValueFromString( string? value, out string? result )
	{
		result = value;
		return true;
	}
}
