// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component representing an input field for entering/editing <see cref="string"/> values.
/// </summary>
public partial class LumexTextBox : LumexDebouncedInputBase<string?>, ISlotComponent<TextBoxSlots>
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
    /// Gets or sets the description for the textbox.
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the error message for the textbox.
    /// This message is displayed only when the textbox is invalid.
    /// </summary>
    [Parameter] public string? ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the input type of the textbox.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="InputType.Text"/>
    /// </remarks>
    [Parameter] public InputType Type { get; set; } = InputType.Text;

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

    /// <summary>
    /// Gets or sets the input behavior, specifying when the textbox
    /// updates its value and triggers validation.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="InputBehavior.OnChange"/>
    /// </remarks>
    [Parameter] public InputBehavior Behavior { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the textbox should have a clear button.
    /// </summary>
    [Parameter] public bool Clearable { get; set; }

    /// <summary>
    /// Gets or sets a callback that is fired when the value in the textbox is cleared.
    /// </summary>
    [Parameter] public EventCallback OnCleared { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the textbox slots.
    /// </summary>
    [Parameter] public TextBoxSlots? Classes { get; set; }

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

    private string? ClearButtonClass =>
        TwMerge.Merge( TextBox.GetClearButtonStyles( this ) );

    private string? HelperWrapperClass =>
        TwMerge.Merge( TextBox.GetHelperWrapperStyles( this ) );

    private string? DescriptionClass =>
        TwMerge.Merge( TextBox.GetDescriptionStyles( this ) );

    private string? ErrorMessageClass =>
        TwMerge.Merge( TextBox.GetErrorMessageStyles( this ) );

    private bool HasHelper => !string.IsNullOrEmpty( Description ) || !string.IsNullOrEmpty( ErrorMessage );
    private bool HasValue => !string.IsNullOrEmpty( CurrentValueAsString );
    private bool ClearButtonVisible => Clearable && HasValue;
    private bool FilledOrFocused =>
        Focused ||
        HasValue ||
        StartContent is not null ||
        !string.IsNullOrEmpty( Placeholder );

    private readonly RenderFragment _renderMainWrapper;
    private readonly RenderFragment _renderInputWrapper;
    private readonly RenderFragment _renderHelperWrapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexTextBox"/>.
    /// </summary>
    public LumexTextBox()
    {
        _renderMainWrapper = RenderMainWrapper;
        _renderInputWrapper = RenderInputWrapper;
        _renderHelperWrapper = RenderHelperWrapper;

        As = "div";
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        if( DebounceDelay > 0 && Behavior is not InputBehavior.OnInput )
        {
            throw new InvalidOperationException( 
                $"{GetType()} requires '{nameof( InputBehavior.OnInput )}' behavior" +
                $" to be used when '{nameof( DebounceDelay )}' is not zero." );
        }
    }

    /// <inheritdoc />
    protected override Task OnInputAsync( ChangeEventArgs args )
    {
        if( Behavior is not InputBehavior.OnInput )
        {
            return Task.CompletedTask;
        }

        return base.OnInputAsync( args );
    }

    /// <inheritdoc />
    protected override Task OnChangeAsync( ChangeEventArgs args )
    {
        if( Behavior is not InputBehavior.OnChange )
        {
            return Task.CompletedTask;
        }

        return base.OnChangeAsync( args );
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

    private async Task ClearAsync( MouseEventArgs args )
    {
        await ClearAsyncCore();
    }

    private async Task ClearAsync( KeyboardEventArgs args )
    {
        if( args.Code is "Enter" or "Space" )
        {
            await ClearAsyncCore();
        }
    }

    private async Task ClearAsyncCore()
    {
        await SetCurrentValueAsync( string.Empty );
        await OnCleared.InvokeAsync();
        await FocusAsync();
    }
}
