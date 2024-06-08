// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexCheckbox : LumexInputBase<bool>, ISlotComponent<CheckboxSlots>
{
    /// <summary>
    /// Gets or sets content to be rendered inside the checkbox.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the icon to be used for indicating a checked state of the checkbox.
    /// </summary>
    [Parameter] public string? CheckIcon { get; set; }

    /// <summary>
    /// Gets or sets the CSS class names for the checkbox slots.
    /// </summary>
    [Parameter] public CheckboxSlots? Classes { get; set; }

    [CascadingParameter] internal CheckboxGroupContext? Context { get; set; }

    private protected override string? RootClass =>
        TwMerge.Merge( Checkbox.GetStyles( this ) );

    private string WrapperClass =>
        TwMerge.Merge( Checkbox.GetWrapperStyles( this ) );

    private string IconClass =>
        TwMerge.Merge( Checkbox.GetIconStyles( this ) );

    private string LabelClass =>
        TwMerge.Merge( Checkbox.GetLabelStyles( this ) );

    private readonly RenderFragment _renderCheckIcon;

    private bool _checked;
    private bool _disabled;
    private bool _readonly;

    /// <summary>
    /// Initializes a new instance of the <see cref="LumexCheckbox"/>.
    /// </summary>
    public LumexCheckbox()
    {
        _renderCheckIcon = RenderCheckIcon;
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync( ParameterView parameters )
    {
        await base.SetParametersAsync( parameters );

        Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color ) 
            ? color
            : Context?.Owner.Color ?? ThemeColor.Primary;

        Size = parameters.TryGetValue<Size>( nameof( Size ), out var size )
            ? size
            : Context?.Owner.Size ?? Size.Medium;

        if( parameters.TryGetValue<Radius>( nameof( Radius ), out var radius ) )
        {
            Radius = radius;
        }
        else if( Context is not null )
        {
            Radius = Context.Owner.Radius;
        }
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _checked = CurrentValue;
        _disabled = Disabled || ( Context?.Owner.Disabled ?? false );
        _readonly = ReadOnly || ( Context?.Owner.ReadOnly ?? false );
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString( string? value, out bool result )
    {
        throw new NotSupportedException(
            $"This component does not parse string inputs. " +
            $"Bind to the '{nameof( CurrentValue )}' property, not '{nameof( CurrentValueAsString )}'." );
    }

    internal bool GetDisabledState() => _disabled;

    private Task OnChangeAsync( ChangeEventArgs args )
    {
        if( _disabled || _readonly )
        {
            return Task.CompletedTask;
        }

        return SetCurrentValueAsync( (bool)args.Value! );
    }
}