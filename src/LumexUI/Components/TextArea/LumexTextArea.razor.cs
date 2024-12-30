using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

public partial class LumexTextArea : LumexComponentBase
{
	/// <summary>
	/// Gets or sets a value indicating whether the textarea is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the textareas value is readonly.
	/// </summary>
	[Parameter] public bool ReadOnly { get; set; }
	
	/// <summary>
	/// Gets or sets a value indicating whether the textareas value is required.
	/// </summary>
	[Parameter] public bool Required { get; set; }

	/// <summary>
	/// /// Gets or sets a value indicating whether the ValueChanged event will be fired on input or change. <see cref="InputBehavior"/>
	/// </summary>
	[Parameter] public InputBehavior Behavior { get; set; } = InputBehavior.OnChange;

	/// <summary>
	/// Gets or sets a value indicating whether the textarea has full width.
	/// </summary>
	[Parameter] public bool FullWidth { get; set; }

	/// <summary>
	/// Gets or sets the text value.
	/// </summary>
	[Parameter] public string? Value { get; set; }

	/// <summary>
	/// Gets or sets the placeholder to show if the value is empty.
	/// </summary>
	[Parameter] public string? Placeholder { get; set; }

	/// <summary>
	/// Gets or sets Value changed event.
	/// </summary>
	[Parameter] public EventCallback<string> ValueChanged { get; set; }

	/// <summary>
	/// Get the merged style of this instance.
	/// </summary>
	private protected override string? RootClass =>
		TwMerge.Merge( Textarea.GetStyles( this ) );
	
	/// <summary>
	/// Initializes a new instance of the <see cref="LumexTextArea"/>.
	/// </summary>
	public LumexTextArea()
	{
		As = "textarea";
	}
	
	/// <summary>
	/// Event wrapper function.
	/// </summary>
	private void OnValueChanged()
	{
		ValueChanged.InvokeAsync( Value );
	}
}