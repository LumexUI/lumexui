using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// A component representing a <see cref="LumexDataGrid{T}"/> column whose cells display a checkbox.
/// </summary>
/// <remarks>
/// For internal use only.
/// </remarks>
/// <typeparam name="T">The type of data represented by each row in the grid.</typeparam>
[SuppressMessage( "Style", "IDE1006:Naming Styles", Justification = "For internal use only." )]
public partial class _CheckboxColumn<T> : LumexColumnBase<T>
{
    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public override SortBuilder<T>? SortBy
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    private async Task SelectAllItemsAsync( bool selected )
    {
        var selectedItems = DataGrid.SelectedItems;

        if( selected )
        {
            if( DataGrid.Data is not null )
            {
                var selectableItems = DataGrid.Data
                    .Where( i => !DataGrid.DisabledItems.Contains( i ) );

                selectedItems = new HashSet<T>( selectableItems );
            }
        }
        else
        {
            selectedItems.Clear();
        }

        await DataGrid.SelectedItemsChanged.InvokeAsync( selectedItems );
    }

    private async Task SelectItemAsync( T item, bool selected )
    {
        var selectedItems = DataGrid.SelectedItems;
        if( DataGrid.SelectionMode is SelectionMode.Multiple )
        {
            SelectItemCore();
        }
        else if( DataGrid.SelectionMode is SelectionMode.Single )
        {
            selectedItems.Clear();
            SelectItemCore();
        }

        await DataGrid.SelectedItemsChanged.InvokeAsync( selectedItems );

        void SelectItemCore()
        {
            if( selected )
            {
                selectedItems.Add( item );
            }
            else
            {
                selectedItems.Remove( item );
            }
        }
    }

    private bool AreAllItemsSelected()
    {
        if( DataGrid.Data is not null )
        {
            var selectableItems = DataGrid.Data
                .Where( i => !DataGrid.DisabledItems.Contains( i ) );

            return selectableItems.Count() == DataGrid.SelectedItems.Count;
        }

        return false;
    }

    private bool IsItemSelected( T item )
    {
        return DataGrid.SelectedItems.Contains( item );
    }
}
