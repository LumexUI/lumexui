using LumexUI.Utilities;

namespace LumexUI.Styles;

internal class Utils
{
    public readonly static string GroupFocusVisible = ElementClass.Empty()
        .Add( "outline-none" )
        .Add( "group-focus-visible:z-10" )
        .Add( "group-focus-visible:ring-2" )
        .Add( "group-focus-visible:ring-focus" )
        .Add( "group-focus-visible:ring-offset-2" )
        .Add( "group-focus-visible:ring-offset-background" )
        .ToString();
}
