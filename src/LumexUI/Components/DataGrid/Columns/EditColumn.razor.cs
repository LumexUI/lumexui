// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Linq.Expressions;

using LumexUI.DataGrid.Interfaces;
using LumexUI.Extensions;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a <see cref="LumexDataGrid{T}"/> editable column whose cell allow modifications to data values.
/// </summary>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
/// <typeparam name="P">The type of the value being displayed in the column's cells.</typeparam>
public partial class EditColumn<T, P> : PropertyColumn<T, P>, IEditableColumn
{
    /// <summary>
    /// Gets or sets the content to be rendered for each row in the column during editing.
    /// </summary>
    [Parameter] public RenderFragment<T>? EditContent { get; set; }

    private static readonly string? _inputStyles = ElementStyle.Empty()
        .Add( "position", "absolute" )
        .Add( "width", "85%" )
        .Add( "top", "50%" )
        .Add( "transform", "translateY(-50%)" )
        .ToString();

    private Action<T, string?>? _setTextProperty;
    private Action<T, double?>? _setNumericProperty;

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if( Property.Body is not MemberExpression )
        {
            throw new InvalidOperationException(
                $"{GetType()} requires the property '{nameof( Property.Body )}' to be of " +
                $"type '{nameof( MemberExpression )}' (e.g., 'p => p.SomeProperty')." );
        }

        // Only do the pre-processing on the lambda expression if it's changed.
        if( PropertyHasChanged )
        {
            if( typeof( P ).IsString() )
            {
                _setTextProperty = CreateSetter<string?>( Property );
            }
            else if( typeof( P ).IsNumeric() )
            {
                _setNumericProperty = CreateSetter<double?>( Property );
            }
        }
    }

    // Creates a setter delegate to set the property value
    private static Action<T, V> CreateSetter<V>( Expression<Func<T, P>> memberLambda )
    {
        var memberExpression = (MemberExpression)memberLambda.Body;
        var parameter = Expression.Parameter( typeof( V ), "value" );

        Expression? valueExpression = Expression.Empty();

        if( typeof( P ).IsString() )
        {
            valueExpression = parameter;
        }
        else if( typeof( P ).IsNumeric() )
        {
            valueExpression = Expression.Condition(
                Expression.Property( parameter, "HasValue" ),
                Expression.Convert( Expression.Property( parameter, "Value" ), typeof( P ) ),
                Expression.Default( typeof( P ) )
            );
        }

        var assign = Expression.Assign( memberExpression, valueExpression );
        var lambda = Expression.Lambda<Action<T, V>>( assign, memberLambda.Parameters[0], parameter );

        return lambda.Compile();
    }
}
