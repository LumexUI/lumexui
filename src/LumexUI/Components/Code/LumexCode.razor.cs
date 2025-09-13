// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents an inline code block, typically used to display short code snippets.
/// </summary>
public partial class LumexCode : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the content to be rendered inside the <see cref="LumexCode"/>.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the color of the <see cref="LumexCode"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets the radius of the <see cref="LumexCode"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Small"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Small;

	/// <summary>
	/// Gets or sets the size of the <see cref="LumexCode"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexCode"/>.
	/// </summary>
	public LumexCode()
	{
		As = "code";
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var code = Styles.Code.Style( TwMerge );
		_slots = code( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Radius )] = Radius.ToString(),
		} );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( SlotBase.Base ) => styles( Class ),
			_ => throw new NotImplementedException()
		};
	}
}