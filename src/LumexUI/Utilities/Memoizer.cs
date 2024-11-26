namespace LumexUI.Utilities;

internal class Memoizer<T>
{
    private bool _isMemoized;
    private MemoEntry _cachedMemoEntry;

    public T Memoize( Func<T> callback, object?[] dependencies )
    {
        if( _isMemoized )
        {
            ref var memoEntry = ref _cachedMemoEntry;
            if( DependenciesUnchanged( memoEntry.Dependencies, dependencies ) )
            {
                return memoEntry.Value;
            }
        }

        // Compute and cache new value
        var value = callback();
        _cachedMemoEntry = new MemoEntry( value, dependencies );
        _isMemoized = true;

        return value;
    }

    private static bool DependenciesUnchanged( object?[] oldDeps, object?[] newDeps )
    {
        return oldDeps?.SequenceEqual( newDeps ) ?? newDeps == null;
    }

    private readonly struct MemoEntry( T value, object?[] deps )
    {
        public readonly T Value = value;
        public readonly object?[] Dependencies = deps;
    }
}
