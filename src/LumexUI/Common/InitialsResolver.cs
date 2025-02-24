namespace LumexUI.Common;

/// <summary>
/// Represents a method that resolves initials from a given name.
/// </summary>
/// <param name="name">The name from which to generate initials.</param>
/// <returns>A <see langword="string"/> of the resolved initials.</returns>
public delegate string InitialsResolver( string name );
