using LumexUI.Common;

namespace LumexUI;

internal class ListboxContext<TValue>( LumexListbox<TValue> owner ) : IComponentContext<LumexListbox<TValue>>
{
    private bool _collectingItems;

    public LumexListbox<TValue> Owner { get; } = owner;
    public List<LumexListboxItem<TValue>> Items { get; } = [];
    public SelectionMode SelectionMode { get; set; }

    public void Register( LumexListboxItem<TValue> item )
    {
        if( _collectingItems )
        {
            Items.Add( item );
        }
    }

    public void Unregister( LumexListboxItem<TValue> item )
    {
        Items.Remove( item );
    }

    public void StartCollectingItems()
    {
        Items.Clear();
        _collectingItems = true;
    }

    public void FinishCollectingItems()
    {
        _collectingItems = false;
    }
}
