// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing an input field for entering/editing <see cref="string"/> values.
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

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexTextbox"/>.
    /// </summary>
    public LumexTextbox()
    {
        SetInputType( Type.ToDescription() );
    }
}
