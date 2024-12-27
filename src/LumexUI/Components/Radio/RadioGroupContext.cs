using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

[CascadingTypeParameter(nameof(TValue))]
internal sealed class RadioGroupContext<TValue>( LumexRadioGroup<TValue> owner, EventCallback<ChangeEventArgs> changeEventCallback ) : IComponentContext<LumexRadioGroup<TValue>>
{
    /// <summary>
    /// The owner of the context.
    /// </summary>
    /// <remarks>
    /// An instance of <see cref="LumexRadioGroup{TValue}"/> will automatically generate this context object and assign itself.  
    /// </remarks>
    public LumexRadioGroup<TValue> Owner { get; } = owner;

    /// <summary>
    /// The callback to be invoked when the value of the radio group changes.
    /// </summary>
    public EventCallback<ChangeEventArgs> ChangeEventCallback { get; } = changeEventCallback;

    /// <summary>
    /// The name of the radio group. This is used to group radios together and gets applied to the name attribute of the radio input.
    /// </summary>
    /// <remarks>
    /// If this is not provided explicitly, the name will be generated automatically by the <see cref="LumexRadioGroup{TValue}"/>.
    /// </remarks>
    public string? GroupName { get; set; }
    
    /// <summary>
    /// The currently-selected value of the radio group. 
    /// </summary>
    /// <remarks>
    /// It can be set in the <see cref="LumexRadioGroup{TValue}.Value"/> parameter, and it will also be updated as the user interacts with the radios. 
    /// </remarks>
    public TValue? CurrentValue => _valueProvider.CurrentValue;
    
    /// <summary>
    /// The provider for the value of the radio group. In this instance, it's <see cref="LumexRadioGroup{TValue}"/>.
    /// </summary>
    private readonly IRadioGroupValueProvider<TValue> _valueProvider = owner;
}