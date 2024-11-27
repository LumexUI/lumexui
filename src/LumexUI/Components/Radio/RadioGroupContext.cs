using LumexUI.Common;

namespace LumexUI;

internal sealed class RadioGroupContext( LumexRadioGroup owner ) : IComponentContext<LumexRadioGroup>
{
    public LumexRadioGroup Owner { get; } = owner;
}