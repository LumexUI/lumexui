using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

internal sealed class RadioGroupContext<TValue>( LumexRadioGroup<TValue> owner ) : IComponentContext<LumexRadioGroup<TValue>>
{
    public LumexRadioGroup<TValue> Owner { get; } = owner;
    
    public EventCallback<ChangeEventArgs> ChangeEventCallback { get; }
    
    private readonly ILumexRadioValueProvider<TValue> _valueProvider;

    public TValue? CurrentValue => _valueProvider.CurrentValue;
}