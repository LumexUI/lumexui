namespace LumexUI.Common;

/// <summary>
/// Represents the dimensions with width and height.
/// </summary>
/// <param name="w">The width.</param>
/// <param name="h">The height.</param>
public readonly struct Dimensions( string w, string h )
{
    /// <summary>
    /// Gets the width.
    /// </summary>
    public readonly string W = w;

    /// <summary>
    /// Gets the height.
    /// </summary>
    public readonly string H = h;

    /// <summary>
    /// Initializes a new instance of the <see cref="Dimensions"/> with equal width and height.
    /// </summary>
    /// <param name="size">The size to be used for both width and height.</param>
    public Dimensions( string size ) : this( w: size, h: size ) { }
}
