// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that provides a consistent field layout with label, content, description, and error message.
/// </summary>
public partial class LumexField : LumexComponentBase, ISlotComponent<FieldSlots>
{
	/// <summary>
	/// Gets or sets the label for the field.
	/// </summary>
	[Parameter] public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the description for the field.
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the error message for the field.
	/// This message is displayed only when the field is invalid.
	/// </summary>
	[Parameter] public string? ErrorMessage { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the field is invalid.
	/// </summary>
	[Parameter] public bool Invalid { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the field is required.
	/// </summary>
	[Parameter] public bool Required { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the field is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets the orientation of the field layout.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Orientation.Vertical"/>
	/// </remarks>
	[Parameter] public Orientation Orientation { get; set; } = Orientation.Vertical;

	/// <summary>
	/// Gets or sets the content to be rendered inside the field.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the field slots.
	/// </summary>
	[Parameter] public FieldSlots? Classes { get; set; }

	private protected override string? RootClass => TwMerge.Merge( Field.GetStyles( this ) );
	private string? LabelClass => TwMerge.Merge( Field.GetLabelStyles( this ) );
	private string? ContentClass => TwMerge.Merge( Field.GetContentStyles( this ) );
	private string? LabelWrapperClass => TwMerge.Merge( Field.GetLabelWrapperStyles( this ) );
	private string? HelperClass => TwMerge.Merge( Field.GetHelperStyles( this ) );
	private string? DescriptionClass => TwMerge.Merge( Field.GetDescriptionStyles( this ) );
	private string? ErrorMessageClass => TwMerge.Merge( Field.GetErrorMessageStyles( this ) );

	private bool HasHelper =>
		!string.IsNullOrEmpty( Description ) ||
		!string.IsNullOrEmpty( ErrorMessage );

	private bool HasLabelOrHelper =>
		!string.IsNullOrEmpty( Label ) ||
		HasHelper;

	private string? ResolvedErrorMessage => ErrorMessage;

	private readonly RenderFragment _renderVerticalLayout;
	private readonly RenderFragment _renderHorizontalLayout;
	private readonly RenderFragment _renderHelper;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexField"/>.
	/// </summary>
	public LumexField()
	{
		_renderVerticalLayout = RenderVerticalLayout;
		_renderHorizontalLayout = RenderHorizontalLayout;
		_renderHelper = RenderHelper;
	}
}
