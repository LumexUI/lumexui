// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing an input field for entering/editing <see cref="string"/> values.
/// </summary>
public partial class LumexTextBox : LumexInputBase<string?>
{
    /// <summary>
    /// Gets or sets the label for the textbox.
    /// </summary>
    [Parameter] public string? Label { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( TextBox.GetStyles( this ) );

    private string? LabelClass =>
        TwMerge.Merge( TextBox.GetLabelStyles() );

    private string? InputWrapperClass =>
        TwMerge.Merge( TextBox.GetInputWrapperStyles() );

    private string? InnerWrapperClass =>
        TwMerge.Merge( TextBox.GetInnerWrapperStyles() );

    private string? InputClass =>
        TwMerge.Merge( TextBox.GetInputStyles() );

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexTextBox"/>.
    /// </summary>
    public LumexTextBox()
    {
        As = "div";
    }
}