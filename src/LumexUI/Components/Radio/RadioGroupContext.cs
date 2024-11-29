using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

internal sealed class RadioGroupContext<TValue>( LumexRadioGroup<TValue> owner, EventCallback<ChangeEventArgs> changeEventCallback ) : IComponentContext<LumexRadioGroup<TValue>>
{
    private readonly ILumexRadioValueProvider<TValue> _valueProvider;
    
    public LumexRadioGroup<TValue> Owner { get; } = owner;

    public EventCallback<ChangeEventArgs> ChangeEventCallback { get; } = changeEventCallback;

    // Mutable properties that may change any time an InputRadioGroup is rendered
    public string? GroupName { get; set; }
    
    public TValue? CurrentValue => _valueProvider.CurrentValue;
}