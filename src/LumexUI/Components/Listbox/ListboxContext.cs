using LumexUI.Common;

namespace LumexUI;

internal class ListboxContext<T>( LumexListbox<T> owner ) : IComponentContext<LumexListbox<T>>
{
    public LumexListbox<T> Owner { get; } = owner;
    public List<LumexListboxItem<T>> Items { get; } = [];
    public bool CollectingItems { get; private set; }

    public void Register( LumexListboxItem<T> item )
    {
        if( CollectingItems )
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
        CollectingItems = true;
    }

    public void FinishCollectingItems()
    {
        CollectingItems = false;
    }
}
