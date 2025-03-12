using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Extensions;

[ExcludeFromCodeCoverage]
internal static class DictionaryExtensions
{
	public static Dictionary<TKey, TValue> TakeAllExceptLast<TKey, TValue>( this IReadOnlyDictionary<TKey, TValue> source, int count = 1 )
		where TKey : notnull
	{
		ArgumentNullException.ThrowIfNull( source, nameof( source ) );

		if( count < 1 )
		{
			throw new ArgumentOutOfRangeException( nameof( count ), count, "The count must be greater than one." );
		}

		if( count >= source.Count )
		{
			return [];
		}

		return source
			.Take( source.Count - count )
			.ToDictionary( x => x.Key, x => x.Value );
	}
}
