using LumexUI.Common;
using LumexUI.DataGrid.Interfaces;

namespace LumexUI;

internal class DataGridState<T>
{
    public SortState Sort { get; }
    public EditState Edit { get; }

    public DataGridState()
    {
        Sort = new SortState();
        Edit = new EditState();
    }

    internal class SortState
    {
        public LumexColumnBase<T>? Column { get; private set; }
        public SortDirection Direction { get; private set; }
        public bool Ascending { get; private set; }

        public void Update( LumexColumnBase<T> column, SortDirection direction )
        {
            var ascending = direction switch
            {
                SortDirection.Ascending => true,
                SortDirection.Descending => false,
                SortDirection.Auto => Column != column || !Ascending,
                _ => throw new NotSupportedException( $"Unknown sort direction {direction}" ),
            };

            Column = column;
            Direction = direction;
            Ascending = ascending;
        }
    }

    internal class EditState
    {
        public IEditableColumn? Column { get; private set; }
        public T? Item { get; private set; }
        public bool Editing => Column is not null && Item is not null;

        public void Update( IEditableColumn? column, T? item )
        {
            Column = column;
            Item = item;
        }

        public bool IsCellEditing( IEditableColumn column, T item )
        {
            return Equals( column, Column ) && Equals( item, Item );
        }
    }
}
