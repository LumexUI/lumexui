// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Utilities;

public record struct CssBuilder
{
	private string? stringBuffer;
	private string prefix;

	/// <summary>
	/// Sets the prefix value to be appended to all classes added following the this statement. 
	/// When SetPrefix is called it will overwrite any previous prefix set for this instance. 
	/// Prefixes are not applied when using AddValue.
	/// </summary>
	/// <param name="value"></param>
	/// <returns>CssBuilder</returns>
	public CssBuilder SetPrefix( string value )
	{
		prefix = value;
		return this;
	}

	/// <summary>
	/// Creates a CssBuilder used to define conditional CSS classes used in a component.
	/// Call Build() to return the completed CSS Classes as a string. 
	/// </summary>
	/// <param name="value"></param>
	public static CssBuilder Default( string? value ) => new( value );

	/// <summary>
	/// Creates an Empty CssBuilder used to define conditional CSS classes used in a component.
	/// Call Build() to return the completed CSS Classes as a string. 
	/// </summary>
	public static CssBuilder Empty() => new();

	/// <summary>
	/// Creates a CssBuilder used to define conditional CSS classes used in a component.
	/// Call Build() to return the completed CSS Classes as a string. 
	/// </summary>
	/// <param name="value"></param>
	public CssBuilder( string? value )
	{
		stringBuffer = value;
		prefix = string.Empty;
	}

	/// <summary>
	/// Adds a raw string to the builder that will be concatenated with the next class or value added to the builder.
	/// </summary>
	/// <param name="value"></param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddValue( string value )
	{
		stringBuffer += value;
		return this;
	}

	/// <summary>
	/// Adds a CSS Class to the builder with space separator.
	/// </summary>
	/// <param name="value">CSS Class to add</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClass( string? value ) =>
		!string.IsNullOrEmpty( value )
			? AddValue( " " + prefix + value )
			: AddValue( prefix + value );

	/// <summary>
	/// Adds a conditional CSS Class to the builder with space separator.
	/// </summary>
	/// <param name="value">CSS Class to conditionally add.</param>
	/// <param name="when">Condition in which the CSS Class is added.</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClass( string? value, bool when = true ) => when ? AddClass( value ) : this;

	/// <summary>
	/// Adds a conditional CSS Class to the builder with space separator.
	/// </summary>
	/// <param name="value">CSS Class to conditionally add.</param>
	/// <param name="when">Condition in which the CSS Class is added.</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClass( string value, Func<bool> when = null! ) => AddClass( value, when() );

	/// <summary>
	/// Adds a conditional CSS Class to the builder with space separator.
	/// </summary>
	/// <param name="value">Function that returns a CSS Class to conditionally add.</param>
	/// <param name="when">Condition in which the CSS Class is added.</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClass( Func<string> value, bool when = true ) => when ? AddClass( value() ) : this;

	/// <summary>
	/// Adds a conditional CSS Class to the builder with space separator.
	/// </summary>
	/// <param name="value">Function that returns a CSS Class to conditionally add.</param>
	/// <param name="when">Condition in which the CSS Class is added.</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClass( Func<string> value, Func<bool> when = null! ) => AddClass( value, when() );

	/// <summary>
	/// Adds a conditional nested CssBuilder to the builder with space separator.
	/// </summary>
	/// <param name="value">CSS Class to conditionally add.</param>
	/// <param name="when">Condition in which the CSS Class is added.</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClass( CssBuilder builder, bool when = true ) => when ? AddClass( builder.Build() ) : this;

	/// <summary>
	/// Adds a conditional CSS Class to the builder with space separator.
	/// </summary>
	/// <param name="value">CSS Class to conditionally add.</param>
	/// <param name="when">Condition in which the CSS Class is added.</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClass( CssBuilder builder, Func<bool> when = null! ) => AddClass( builder, when() );

	/// <summary>
	/// Adds a conditional CSS Class when it exists in a dictionary to the builder with space separator.
	/// Null safe operation.
	/// </summary>
	/// <param name="additionalAttributes">Additional Attribute splat parameters</param>
	/// <returns>CssBuilder</returns>
	public CssBuilder AddClassFromAttributes( IReadOnlyDictionary<string, object> additionalAttributes ) =>
		additionalAttributes == null ? this :
		additionalAttributes.TryGetValue( "class", out object? c ) && c != null ? AddClass( c.ToString()! ) : this;

	/// <summary>
	/// Finalize the completed CSS Classes as a string.
	/// </summary>
	/// <returns>string</returns>
	public readonly string Build()
	{
		return stringBuffer != null ? stringBuffer.Trim() : string.Empty;
	}

	public readonly override string ToString() => Build();
}