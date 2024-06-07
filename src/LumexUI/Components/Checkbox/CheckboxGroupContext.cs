using LumexUI.Common;

namespace LumexUI;

internal sealed class CheckboxGroupContext( LumexCheckboxGroup owner ) : IComponentContext<LumexCheckboxGroup>
{
    public LumexCheckboxGroup Owner { get; } = owner;
}
