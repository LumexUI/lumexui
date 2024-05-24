namespace LumexUI.Common;

internal interface ISlotComponent<T> where T : ISlot
{
    T? Classes { get; }
}
