using LumexUI.Common;

namespace LumexUI;

internal class ListboxContext<T>( LumexListbox<T> owner ) : IComponentContext<LumexListbox<T>>
{
    public LumexListbox<T> Owner { get; } = owner;
}
