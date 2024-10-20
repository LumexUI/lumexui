using LumexUI.Common;

namespace LumexUI;

internal sealed class AccordionContext( LumexAccordion owner ) : IComponentContext<LumexAccordion>
{
    public readonly List<LumexAccordionItem> _items = [];

    public LumexAccordion Owner { get; } = owner;

    public void Register( LumexAccordionItem item )
    {
        _items.Add( item );

        if( Owner.Expanded )
        {
            Owner.ExpandedItems.Add( item.Id );
        }
    }

    public void Unregister( LumexAccordionItem item )
    {
        _items.Remove( item );
    }

    public bool IsLast( LumexAccordionItem item )
    {
        return item == _items[^1];
    }

    public ValueTask ToggleExpansionAsync( LumexAccordionItem item )
    {
        if( Owner.SelectionMode is SelectionMode.Single )
        {
            if( !Owner.ExpandedItems.Contains( item.Id ) )
            {
                return CollapseAllButThisAsync( item );
            }

            Owner.ExpandedItems.Remove( item.Id );
        }

        return ValueTask.CompletedTask;
    }

    private async ValueTask CollapseAllButThisAsync( LumexAccordionItem item )
    {
        foreach( var accordionItem in _items )
        {
            if( accordionItem == item 
                || accordionItem.Disabled
                || !accordionItem.GetExpandedState() )
            {
                continue;
            }

            Owner.ExpandedItems.Remove( accordionItem.Id );
            await accordionItem.CollapseAsync();
        }
    }
}
