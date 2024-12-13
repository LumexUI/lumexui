using LumexUI.Common;

namespace LumexUI;

internal class SelectContext<TValue>( LumexSelect<TValue> owner ) : IComponentContext<LumexSelect<TValue>>
{
    public LumexSelect<TValue> Owner { get; } = owner;
    public List<LumexSelectItem<TValue>> Items { get; } = [];
    public HashSet<LumexSelectItem<TValue>> SelectedItems { get; } = [];

    // Just for a component context API consistency.
    // Chore: make it prettier, more robust.
    public void Register( LumexSelectItem<TValue> item )
    {
        Items.Add( item );
    }

    // Just for a component context API consistency.
    // Chore: make it prettier, more robust.
    public void Unregister( LumexSelectItem<TValue> item )
    {
        Items.Remove( item );
    }

    public void SetSelectedItems( ICollection<TValue> selectedValues )
    {
        var set = selectedValues.ToHashSet();
        var selectedItems = Items.Where( item => set.Contains( item.Value ) ).ToHashSet();

        SelectedItems.RemoveWhere( item => !selectedItems.Contains( item ) );
        SelectedItems.UnionWith( selectedItems );
    }
}
