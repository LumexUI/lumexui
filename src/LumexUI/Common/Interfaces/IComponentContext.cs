namespace LumexUI.Common;

internal interface IComponentContext<T> where T : LumexComponentBase
{
    T Owner { get; }
}
