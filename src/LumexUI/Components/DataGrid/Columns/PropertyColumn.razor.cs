using System.Linq.Expressions;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a <see cref="LumexDataGrid{T}"/> column whose cells display a single value.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
/// <typeparam name="P">The type of the value being displayed in the column's cells.</typeparam>
public partial class PropertyColumn<T, P> : LumexColumnBase<T>
{
    /// <summary>
    /// Gets or sets the content to be rendered for each cell in the column.
    /// </summary>
    [Parameter] public RenderFragment<T>? Content { get; set; }

    /// <summary>
    /// Gets or sets the value to be displayed in this column's cells.
    /// </summary>
    [Parameter, EditorRequired] public Expression<Func<T, P>> Property { get; set; } = default!;

    /// <summary>
    /// Gets or sets a format string for the column's cells value.
    /// </summary>
    /// <remarks>
    /// Requires the <typeparamref name="P"/> type to implement <see cref="IFormattable" />.
    /// </remarks>
    [Parameter] public string? Format { get; set; }

    /// <inheritdoc/>
    public override SortBuilder<T>? SortBy
    {
        get => _sortBuilder;
        set => throw new NotSupportedException(
            $"PropertyColumn generates this member internally. For custom sorting rules, see '{typeof( TemplateColumn<T> )}'." );
    }

    internal bool PropertyHasChanged { get; private set; }

    private Expression<Func<T, P>>? _lastAssignedProperty;
    private Func<T, string?>? _cellContentFunc;
    private SortBuilder<T>? _sortBuilder;

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        PropertyHasChanged = _lastAssignedProperty?.ToString() != Property.ToString();

        // Only do the pre-processing on the lambda expression if it's changed.
        if( PropertyHasChanged )
        {
            _lastAssignedProperty = Property;
            var compiledPropertyExpession = Property.Compile();

            if( !string.IsNullOrEmpty( Format ) )
            {
                // If the type is nullable, we're interested in formatting the underlying type
                var nullableUnderlyingTypeOrNull = Nullable.GetUnderlyingType( typeof( P ) );
                if( !typeof( IFormattable ).IsAssignableFrom( nullableUnderlyingTypeOrNull ?? typeof( P ) ) )
                {
                    throw new InvalidOperationException(
                        $"{GetType()} requires the type '{typeof( P )}' to implement '{typeof( IFormattable )}'" +
                        $"when the '{nameof( Format )}' parameter is supplied." );
                }

                _cellContentFunc = GetFormattedCellContentFunc( nullableUnderlyingTypeOrNull );
            }
            else
            {
                _cellContentFunc = item => compiledPropertyExpession!( item )?.ToString();
            }

            _sortBuilder = SortBuilder<T>.ByAscending( Property );
        }

        if( Title is null && Property.Body is MemberExpression memberExpression )
        {
            Title = memberExpression.Member.Name;
        }
    }

    /// <summary>
    /// Retrieves the content to be displayed in a column's cell for the specified data item.
    /// </summary>
    /// <param name="item">The data item for which to retrieve the cell content.</param>
    /// <returns>A <see cref="string"/> representing the cell content.</returns>
    protected string? CellContent( T item ) =>
        _cellContentFunc?.Invoke( item );

    private Func<T, string> GetFormattedCellContentFunc( Type? nullableUnderlyingTypeOrNull )
    {
        var toStringMethod = typeof( IFormattable ).GetMethod( "ToString" )!;
        ParameterExpression propVar = Expression.Variable( typeof( P ), "prop" );

        Expression toStringCallTarget = nullableUnderlyingTypeOrNull == null
            ? propVar
            : Expression.Call( propVar, typeof( P ).GetMethod( "GetValueOrDefault", Type.EmptyTypes )! );

        MethodCallExpression toStringCall = Expression.Call(
            toStringCallTarget,
            toStringMethod,
            Expression.Property( Expression.Constant( this ), nameof( Format ) ),
            Expression.Constant( null, typeof( IFormatProvider ) ) );

        Expression conditionalCall = default( P ) == null
            ? Expression.Condition(
                Expression.Equal( propVar, Expression.Constant( null, typeof( P ) ) ),
                Expression.Constant( null, typeof( string ) ),
                toStringCall )
            : toStringCall;

        BlockExpression block = Expression.Block( [propVar],
            Expression.Assign( propVar, Property.Body ),
            conditionalCall );

        return Expression.Lambda<Func<T, string>>( block, Property.Parameters[0] ).Compile();
    }
}
