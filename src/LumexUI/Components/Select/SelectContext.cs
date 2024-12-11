using LumexUI.Common;

namespace LumexUI;

internal class SelectContext<T>( LumexSelect<T> owner ) : IComponentContext<LumexSelect<T>>
{
    public LumexSelect<T> Owner { get; } = owner;
}
