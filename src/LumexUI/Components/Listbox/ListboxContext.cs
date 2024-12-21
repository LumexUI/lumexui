using LumexUI.Common;

namespace LumexUI;

internal class ListboxContext<T>( LumexListbox<T> owner ) : IComponentContext<LumexListbox<T>>
{
    private bool _collectingItems;

    public LumexListbox<T> Owner { get; } = owner;
    public List<LumexListboxItem<T>> Items { get; } = [];
    public SelectionMode SelectionMode { get; set; }

    public void Register( LumexListboxItem<T> item )
    {
        if( _collectingItems )
        {
            Items.Add( item );
        }
    }

    public void Unregister( LumexListboxItem<T> item )
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
