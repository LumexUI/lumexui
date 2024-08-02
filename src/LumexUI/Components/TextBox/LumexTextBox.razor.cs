// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing an input field for entering/editing <see cref="string"/> values.
/// </summary>
public partial class LumexTextBox : LumexInputBase<string?>
{
    /// <summary>
    /// Gets or sets content to be rendered at the start of the textbox.
    /// </summary>
    [Parameter] public RenderFragment? StartContent { get; set; }

    /// <summary>
    /// Gets or sets content to be rendered at the end of the textbox.
    /// </summary>
    [Parameter] public RenderFragment? EndContent { get; set; }

    /// <summary>
    /// Gets or sets the label for the textbox.
    /// </summary>
    [Parameter] public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the placeholder for the textbox.
    /// </summary>
    [Parameter] public string? Placeholder { get; set; }

    /// <summary>
    /// Gets or sets the variant for the textbox.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="InputVariant.Flat"/>
    /// </remarks>
    [Parameter] public InputVariant Variant { get; set; }

    /// <summary>
    /// Gets or sets the border radius of the textbox.
    /// </summary>
    [Parameter] public Radius? Radius { get; set; }

    /// <summary>
    /// Gets or sets the placement of the label for the textbox.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="LabelPlacement.Inside"/>
    /// </remarks>
    [Parameter] public LabelPlacement LabelPlacement { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the textbox is full-width.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="true"/>
    /// </remarks>
    [Parameter] public bool FullWidth { get; set; } = true;

    private protected override string? RootClass =>
        TwMerge.Merge( TextBox.GetStyles( this ) );

    private string? LabelClass =>
        TwMerge.Merge( TextBox.GetLabelStyles( this ) );

    private string? MainWrapperClass =>
        TwMerge.Merge( TextBox.GetMainWrapperStyles( this ) );

    private string? InputWrapperClass =>
        TwMerge.Merge( TextBox.GetInputWrapperStyles( this ) );

    private string? InnerWrapperClass =>
        TwMerge.Merge( TextBox.GetInnerWrapperStyles( this ) );

    private string? InputClass =>
        TwMerge.Merge( TextBox.GetInputStyles( this ) );

    private bool HasValue => !string.IsNullOrEmpty( CurrentValueAsString );
    private bool FilledOrFocused =>
        _focused ||
        HasValue ||
        StartContent is not null ||
        !string.IsNullOrEmpty( Placeholder );

    private readonly RenderFragment _renderMainWrapper;
    private readonly RenderFragment _renderInputWrapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexTextBox"/>.
    /// </summary>
    public LumexTextBox()
    {
        _renderMainWrapper = RenderMainWrapper;
        _renderInputWrapper = RenderInputWrapper;

        As = "div";
    }

    protected virtual Task OnChangeAsync( ChangeEventArgs args )
    {
        if( Disabled || ReadOnly )
        {
            return Task.CompletedTask;
        }

        return SetCurrentValueAsync( (string?)args.Value );
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, out string? result )
    {
        result = value;
        return true;
    }

    private async Task FocusInputAsync()
    {
        if( !Disabled && !ReadOnly )
        {
            await FocusAsync();
        }
    }
}
