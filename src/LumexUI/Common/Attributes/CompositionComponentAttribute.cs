// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Common;

/// <summary>
/// Specifies that a class is a composition component and associates it with an aggregator type.
/// </summary>
/// <remarks>
/// This attribute is used to indicate that the decorated class is part of a composition and is aggregated by a specific type.
/// </remarks>
[ExcludeFromCodeCoverage]
[AttributeUsage( AttributeTargets.Class )]
public class CompositionComponentAttribute( Type aggregatorType ) : Attribute
{
	/// <summary>
	/// Gets the aggregator type associated with the composition component.
	/// </summary>
	public Type AggregatorType { get; } = aggregatorType;
}
