using LumexUI.Common;

namespace LumexUI;

internal class PopoverContext( LumexPopover owner ) : IComponentContext<LumexPopover>
{
	public LumexPopover Owner { get; } = owner;
}
