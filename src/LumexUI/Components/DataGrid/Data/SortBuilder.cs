using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents a sort order specification used within <see cref="LumexDataGrid{T}"/>.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
[ExcludeFromCodeCoverage( Justification = "Taken from the Blazor QuickGrid." )]
public sealed class SortBuilder<T>
{
    private const string ExpressionNotRepresentableMessage = "The supplied expression can't be represented as a property name for sorting. Only simple member expressions, such as @(x => x.SomeProperty), can be converted to property names.";

    private readonly Func<IQueryable<T>, bool, IOrderedQueryable<T>> _first;
    private List<Func<IOrderedQueryable<T>, bool, IOrderedQueryable<T>>>? _then;

    private (LambdaExpression, bool) _firstExpression;
    private List<(LambdaExpression, bool)>? _thenExpressions;

    private IReadOnlyCollection<SortDescriptor>? _cachedPropertyListAscending;
    private IReadOnlyCollection<SortDescriptor>? _cachedPropertyListDescending;

    internal SortBuilder(
        Func<IQueryable<T>, bool, IOrderedQueryable<T>> first,
        (LambdaExpression, bool) firstExpression )
    {
        _first = first;
        _firstExpression = firstExpression;
        _then = default;
        _thenExpressions = default;
    }

    /// <summary>
    /// Produces a <see cref="SortBuilder{T}"/> instance that sorts according to the specified <paramref name="expression"/>, ascending.
    /// </summary>
    /// <typeparam name="U">The type of the expression's value.</typeparam>
    /// <param name="expression">An expression defining how a set of <typeparamref name="T"/> instances are to be sorted.</param>
    /// <returns>A <see cref="SortBuilder{T}"/> instance representing the specified sorting rule.</returns>
    public static SortBuilder<T> ByAscending<U>( Expression<Func<T, U>> expression )
        => new( ( queryable, asc ) => asc ? queryable.OrderBy( expression ) : queryable.OrderByDescending( expression ),
            (expression, true) );

    /// <summary>
    /// Produces a <see cref="SortBuilder{T}"/> instance that sorts according to the specified <paramref name="expression"/>, descending.
    /// </summary>
    /// <typeparam name="U">The type of the expression's value.</typeparam>
    /// <param name="expression">An expression defining how a set of <typeparamref name="T"/> instances are to be sorted.</param>
    /// <returns>A <see cref="SortBuilder{T}"/> instance representing the specified sorting rule.</returns>
    public static SortBuilder<T> ByDescending<U>( Expression<Func<T, U>> expression )
        => new( ( queryable, asc ) => asc ? queryable.OrderByDescending( expression ) : queryable.OrderBy( expression ),
            (expression, false) );

    /// <summary>
    /// Updates a <see cref="SortBuilder{T}"/> instance by appending a further sorting rule.
    /// </summary>
    /// <typeparam name="U">The type of the expression's value.</typeparam>
    /// <param name="expression">An expression defining how a set of <typeparamref name="T"/> instances are to be sorted.</param>
    /// <returns>A <see cref="SortBuilder{T}"/> instance representing the specified sorting rule.</returns>
    public SortBuilder<T> ThenAscending<U>( Expression<Func<T, U>> expression )
    {
        _then ??= [];
        _thenExpressions ??= [];
        _then.Add( ( queryable, asc ) => asc ? queryable.ThenBy( expression ) : queryable.ThenByDescending( expression ) );
        _thenExpressions.Add( (expression, true) );
        _cachedPropertyListAscending = null;
        _cachedPropertyListDescending = null;
        return this;
    }

    /// <summary>
    /// Updates a <see cref="SortBuilder{T}"/> instance by appending a further sorting rule.
    /// </summary>
    /// <typeparam name="U">The type of the expression's value.</typeparam>
    /// <param name="expression">An expression defining how a set of <typeparamref name="T"/> instances are to be sorted.</param>
    /// <returns>A <see cref="SortBuilder{T}"/> instance representing the specified sorting rule.</returns>
    public SortBuilder<T> ThenDescending<U>( Expression<Func<T, U>> expression )
    {
        _then ??= [];
        _thenExpressions ??= [];
        _then.Add( ( queryable, asc ) => asc ? queryable.ThenByDescending( expression ) : queryable.ThenBy( expression ) );
        _thenExpressions.Add( (expression, false) );
        _cachedPropertyListAscending = null;
        _cachedPropertyListDescending = null;
        return this;
    }

    internal IOrderedQueryable<T> Apply( IQueryable<T> queryable, bool ascending )
    {
        var orderedQueryable = _first( queryable, ascending );

        if( _then is not null )
        {
            foreach( var clause in _then )
            {
                orderedQueryable = clause( orderedQueryable, ascending );
            }
        }

        return orderedQueryable;
    }

    internal IReadOnlyCollection<SortDescriptor> ToPropertyList( bool ascending )
    {
        if( ascending )
        {
            _cachedPropertyListAscending ??= BuildPropertyList( ascending: true );
            return _cachedPropertyListAscending;
        }
        else
        {
            _cachedPropertyListDescending ??= BuildPropertyList( ascending: false );
            return _cachedPropertyListDescending;
        }
    }

    private List<SortDescriptor> BuildPropertyList( bool ascending )
    {
        var result = new List<SortDescriptor>
        {
            new SortDescriptor()
            {
                PropertyName = ToPropertyName(_firstExpression.Item1),
                Direction = (_firstExpression.Item2 ^ ascending) ? SortDirection.Descending : SortDirection.Ascending
            }
        };

        if( _thenExpressions is not null )
        {
            foreach( var (thenLambda, thenAscending) in _thenExpressions )
            {
                result.Add( new SortDescriptor()
                {
                    PropertyName = ToPropertyName( thenLambda ),
                    Direction = ( thenAscending ^ ascending ) ? SortDirection.Descending : SortDirection.Ascending
                } );
            }
        }

        return result;
    }

    // Not sure we really want this level of complexity, but it converts expressions like @(c => c.Medals.Gold) to "Medals.Gold"
    private static string ToPropertyName( LambdaExpression expression )
    {
        if( expression.Body is not MemberExpression body )
        {
            throw new ArgumentException( ExpressionNotRepresentableMessage );
        }

        // Handles cases like @(x => x.Name)
        if( body.Expression is ParameterExpression )
        {
            return body.Member.Name;
        }

        // First work out the length of the string we'll need, so that we can use string.Create
        var length = body.Member.Name.Length;
        var node = body;
        while( node.Expression is not null )
        {
            if( node.Expression is MemberExpression parentMember )
            {
                length += parentMember.Member.Name.Length + 1;
                node = parentMember;
            }
            else if( node.Expression is ParameterExpression )
            {
                break;
            }
            else
            {
                throw new ArgumentException( ExpressionNotRepresentableMessage );
            }
        }

        // Now construct the string
        return string.Create( length, body, ( chars, body ) =>
        {
            var nextPos = chars.Length;
            while( body is not null )
            {
                nextPos -= body.Member.Name.Length;
                body.Member.Name.CopyTo( chars[nextPos..] );
                if( nextPos > 0 )
                {
                    chars[--nextPos] = '.';
                }

                body = ( body.Expression as MemberExpression )!;
            }
        } );
    }
}
