using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Common;

/// <summary>
/// Specifies that a class is a composition component and defines the type of the aggregator component.
/// </summary>
/// <remarks>
/// This attribute is used to indicate that the decorated class is part of a composition and is aggregated by a specific type.
/// </remarks>
[AttributeUsage( AttributeTargets.Class )]
[ExcludeFromCodeCoverage]
public class CompositionComponentAttribute : Attribute
{
    /// <summary>
    /// Gets the type of the aggregator component.
    /// </summary>
    public Type AggregatorType { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CompositionComponentAttribute"/> class with the specified aggregator type.
    /// </summary>
    /// <param name="aggregatorType">The type of the aggregator component.</param>
    public CompositionComponentAttribute( Type aggregatorType )
    {
        AggregatorType = aggregatorType;
    }
}
