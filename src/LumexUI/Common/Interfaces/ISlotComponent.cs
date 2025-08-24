namespace LumexUI.Common;

internal interface ISlotComponent<T> where T : SlotBase
{
    T? Classes { get; }
}
