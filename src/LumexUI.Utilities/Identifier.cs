// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Utilities;

public static class Identifier
{
	private static readonly Random _rnd = new();

	/// <summary>
	/// Generates a new small Id. For example, 'f127d9edf14385adb'.
	/// </summary>
	/// <remarks>HTML id must start with a letter.</remarks>
	/// <returns>A <see cref="string"/> that represents the generated ID.</returns>
	public static string New( int length = 8 )
	{
		if( length > 16 )
		{
			throw new ArgumentOutOfRangeException( nameof( length ), "length must be less than 16" );
		}

		if( length <= 8 )
		{
			return $"f{_rnd.Next():x}";
		}

		return $"f{_rnd.Next():x}{_rnd.Next():x}"[..length];
	}
}
