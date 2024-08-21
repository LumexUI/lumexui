using LumexUI.Common;

namespace LumexUI;

internal class SelectContext<TValue>( LumexSelect<TValue> owner ) : IComponentContext<LumexSelect<TValue>>
{
    public LumexSelect<TValue> Owner { get; } = owner;
}
