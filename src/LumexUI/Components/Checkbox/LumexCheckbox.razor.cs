// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a checkbox input.
/// </summary>
public partial class LumexCheckbox : LumexBooleanInputBase, ISlotComponent<CheckboxSlots>
{
	/// <summary>
	/// Gets or sets the content to render as icon when the checkbox is checked.
	/// </summary>
	[Parameter] public RenderFragment? IconContent { get; set; }

	/// <summary>
	/// Gets or sets the border radius of the checkbox.
	/// </summary>
	/// <remarks>
	/// The default is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets the CSS class names for the checkbox slots.
	/// </summary>
	[Parameter] public CheckboxSlots? Classes { get; set; }

	[CascadingParameter] internal CheckboxGroupContext? Context { get; set; }

	private protected override string? RootClass =>
		TwMerge.Merge( Checkbox.GetStyles( this ) );

	private string? WrapperClass =>
		TwMerge.Merge( Checkbox.GetWrapperStyles( this ) );

	private string? IconClass =>
		TwMerge.Merge( Checkbox.GetIconStyles( this ) );

	private string? LabelClass =>
		TwMerge.Merge( Checkbox.GetLabelStyles( this ) );

	private readonly RenderFragment _renderCheckIcon;

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
	protected internal override bool GetDisabledState() =>
		Disabled || ( Context?.Owner.Disabled ?? false );

	/// <inheritdoc />
	protected internal override bool GetReadOnlyState() =>
		ReadOnly || ( Context?.Owner.ReadOnly ?? false );
}
