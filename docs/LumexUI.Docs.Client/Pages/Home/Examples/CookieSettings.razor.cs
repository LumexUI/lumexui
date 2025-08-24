using LumexUI.Utilities;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class CookieSettings : ExampleComponentBase
{
	private SwitchSlots _classes = new()
	{
		Base = new ElementClass()
			.Add( "flex-row-reverse" )
			.Add( "gap-4" )
			.Add( "justify-between" )
	};
}