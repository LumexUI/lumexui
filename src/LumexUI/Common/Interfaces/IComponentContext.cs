namespace LumexUI.Common;

internal interface IComponentContext<out T> where T : LumexComponentBase
{
    T Owner { get; }
}
