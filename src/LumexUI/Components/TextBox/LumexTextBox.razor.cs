// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Styles;

namespace LumexUI;

/// <summary>
/// A component representing an input field for entering/editing <see cref="string"/> values.
/// </summary>
public partial class LumexTextBox : LumexInputBase<string?>
{
    private protected override string? RootClass =>
        TwMerge.Merge( TextBox.GetStyles( this ) );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexTextBox"/>.
    /// </summary>
    public LumexTextBox()
    {
        As = "div";
    }
}