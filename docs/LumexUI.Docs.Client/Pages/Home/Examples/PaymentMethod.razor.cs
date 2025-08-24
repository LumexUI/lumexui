using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class PaymentMethod : ExampleComponentBase
{
	private RadioSlots RadioClasses => new()
	{
		Base = ElementClass.Empty()
			.Add( "flex-1 max-w-none p-4 m-0 justify-center" )
			.Add( "rounded-medium border-2" )
			.Add( "transition-colors" )
			.Add( _colorMap[ThemeColor] ),
		ControlWrapper = "hidden",
		LabelWrapper = "m-0"
	};

	private readonly Dictionary<ThemeColor, string> _colorMap = new()
	{
		[ThemeColor.Default] = "bg-surface1 border-default-100 hover:bg-surface2 data-[selected=true]:border-default data-[selected=true]:bg-surface2",
		[ThemeColor.Primary] = "bg-primary/10 border-primary/15 hover:bg-primary/15 data-[selected=true]:border-primary data-[selected=true]:bg-primary/15",
		[ThemeColor.Secondary] = "bg-secondary/10 border-secondary/15 hover:bg-secondary/15 data-[selected=true]:border-secondary data-[selected=true]:bg-secondary/15",
		[ThemeColor.Success] = "bg-success/10 border-success/15 hover:bg-success/15 data-[selected=true]:border-success data-[selected=true]:bg-success/15",
		[ThemeColor.Warning] = "bg-warning/5 border-warning/15 hover:bg-warning/15 data-[selected=true]:border-warning data-[selected=true]:bg-warning/15",
		[ThemeColor.Danger] = "bg-danger/10 border-danger/15 hover:bg-danger/15 data-[selected=true]:border-danger data-[selected=true]:bg-danger/15",
		[ThemeColor.Info] = "bg-info/10 border-info/15 hover:bg-info/15 data-[selected=true]:border-info data-[selected=true]:bg-info/15",
	};
}