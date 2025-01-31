// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents an accordion, allowing content to be expanded and collapsed.
/// </summary>
public partial class LumexAccordion : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the content to render.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the visual variant.
	/// </summary>
	[Parameter] public AccordionVariant Variant { get; set; }

	/// <summary>
	/// Gets or sets the selection mode.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="SelectionMode.Single"/>.
	/// </remarks>
	[Parameter] public SelectionMode SelectionMode { get; set; } = SelectionMode.Single;

	/// <summary>
	/// Gets or sets a value indicating whether the accordion is full width.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>.
	/// </remarks>
	[Parameter] public bool FullWidth { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether the accordion is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the accordion is expanded by default.
	/// </summary>
	[Parameter] public bool Expanded { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether dividers should be shown between accordion items.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>.
	/// </remarks>
	[Parameter] public bool ShowDividers { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether indicators should be shown for accordion items.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>.
	/// </remarks>
	[Parameter] public bool ShowIndicators { get; set; } = true;

	/// <summary>
	/// Gets or sets the collection of item keys that are expanded.
	/// </summary>
	[Parameter] public ICollection<string> ExpandedItems { get; set; } = [];

	/// <summary>
	/// Gets or sets the collection of item keys that are disabled.
	/// </summary>
	[Parameter] public ICollection<string> DisabledItems { get; set; } = [];

	/// <summary>
	/// Gets or sets the CSS classes for individual accordion items.
	/// </summary>
	[Parameter] public AccordionItemSlots? ItemClasses { get; set; }

	private protected override string? RootClass =>
		TwMerge.Merge( Accordion.GetStyles( this ) );

	private readonly AccordionContext _context;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexAccordion"/>.
	/// </summary>
	public LumexAccordion()
	{
		_context = new AccordionContext( this );
	}
}
